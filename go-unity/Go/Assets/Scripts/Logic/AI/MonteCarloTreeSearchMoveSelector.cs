using System.Diagnostics;
using Configs;

namespace Logic.AI
{
    public class MonteCarloTreeSearchMoveSelector : MoveSelector
    {
        private readonly ISelectionPolicy selectionPolicy;
        private readonly IPlayoutPolicy playoutPolicy;

        private Node currentNode;
        private Stopwatch stopwatch;

        public MonteCarloTreeSearchMoveSelector()
        {
            selectionPolicy = new RandomSelectionPolicy();
            playoutPolicy = new RandomPlayoutPolicy();
        }

        public override void Init(Game game)
        {
            currentNode = new Node(game.Board.CurrentBoardState);
            stopwatch = new Stopwatch();
            base.Init(game);
        }

        public override bool TryPlaceStone(Board board, Player player, Player otherPlayer, Config config)
        {
            var isValidMoveAvailable =
                new TryGetRandomMoveCommand(Random, board, player, otherPlayer, config)
                    .Execute(out var validRandomMove);

            if (!isValidMoveAvailable) return false;


            stopwatch.Restart();
            bool foundValidMove = false;
            while (IsTimeRemaining(config.Settings.DelayBetweenMovesInMilliseconds))
            {
                var leaf = Selection();
                foundValidMove = TryExpandLeaf(leaf, player, out var child);

                if (!foundValidMove)
                {
                    continue;
                }

                foundValidMove = true;

                var result = Simulation(child);
                BackPropagation(result, child);
            }

            //if we didn't find a valid move in the time remaining (all calls to TryExpand were false).
            var chosenNode = foundValidMove 
                ? selectionPolicy.SelectMove(currentNode, player)
                : new Node(currentNode,(validRandomMove,player));

            AddStoneToCell(board, new Stone(player, otherPlayer),
                board.Cells[chosenNode.Move.position.x, chosenNode.Move.position.y]);

            currentNode = chosenNode;
            return true;
        }

        //choose a move at leaf of tree.
        private Node Selection()
        {
            return selectionPolicy.SelectChild(currentNode, Random);
        }

        //expansion. grow the search tree by generating a new child at the leaf (random move).
        private bool TryExpandLeaf(Node leaf, Player player, out Node child)
        {
            //if no valid move available then just return leaf.
            throw new System.NotImplementedException();
        }

        //simulation. perform a playout from new child. states are NOT added to search tree
        private Player Simulation(Node child)
        {
            return playoutPolicy.PerformPlayout(child);
        }

        //back-propagation. use results of simulation to update all the way up to current state.
        private void BackPropagation(Player winningPlayer, Node child)
        {
            var node = child;
            while (true)
            {
                node.Rollouts++;
                node.SuccessfulRollouts[winningPlayer]++;

                if (node.Parent == null || node.Parent == currentNode) break;
                node = node.Parent;
            }

            throw new System.NotImplementedException();
        }

        private bool IsTimeRemaining(float maxDuration)
        {
            return stopwatch.Elapsed.Milliseconds < maxDuration;
        }
    }
}
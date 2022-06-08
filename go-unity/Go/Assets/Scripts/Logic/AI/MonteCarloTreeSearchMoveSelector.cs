using System.Diagnostics;
using Configs;
using Zenject;

namespace Logic.AI
{
    public class MonteCarloTreeSearchMoveSelector : MoveSelector
    {
        [Inject] private Settings settings;
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

        public override bool TryPlaceStone(Board board, Player player, Player otherPlayer)
        {
            currentNode = new Node(board.CurrentBoardState);

            var isValidMoveAvailable =
                new TryGetRandomMoveCommand(Random, board, player)
                    .Execute(out var validRandomMove);

            if (!isValidMoveAvailable) return false;

            stopwatch.Restart();
            bool validMoveExists = false; //amount of similar bools is confusing
            while (IsTimeRemaining(settings.DelayBetweenMovesInMilliseconds))
            {
                var leaf = Selection();
                var foundValidMove = TryExpandLeaf(board, leaf, player, out var child);

                if (!foundValidMove)
                    continue;

                validMoveExists = true;

                var result = Simulation(child);
                BackPropagation(result, child);
            }

            var chosenNode = validMoveExists
                ? selectionPolicy.SelectMove(currentNode, player)
                : new Node(currentNode, (validRandomMove, player));

            AddStoneToCell(board, player.OccupationState,
                board.Cells[chosenNode.Move.position.x, chosenNode.Move.position.y]);


            return true;
        }

        //choose a move at leaf of tree.
        private Node Selection()
        {
            return selectionPolicy.SelectChild(currentNode, Random);
        }

        //expansion. grow the search tree by generating a new child at the leaf (random move).
        private bool TryExpandLeaf(Board board, Node leaf, Player player, out Node child)
        {
            board.SetCellsFromState(leaf.State);
            var foundMove = new TryGetRandomMoveCommand(Random, board, player).Execute(out var position);
            if (!foundMove)
            {
                child = leaf;
                return false;
            }

            child = new Node(leaf, (position, player));
            leaf.Children.Add(child);

            return true;
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
        }

        private bool IsTimeRemaining(float maxDuration)
        {
            return stopwatch.Elapsed.Milliseconds < maxDuration;
        }
    }
}
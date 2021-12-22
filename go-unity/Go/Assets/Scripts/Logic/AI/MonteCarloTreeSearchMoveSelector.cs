using System.Collections.Generic;
using System.Linq;
using Configs;

namespace Logic.AI
{
    public class MonteCarloTreeSearchMoveSelector : MoveSelector
    {
        private ISelectionPolicy selectionPolicy;
        private IPlayoutPolicy playoutPolicy;

        private Node currentNode; // need to create this when first creating board state

        public MonteCarloTreeSearchMoveSelector()
        {
            selectionPolicy = new RandomSelectionPolicy();
            playoutPolicy = new RandomPlayoutPolicy();
        }

        public override void Init()
        {
            //init current node.
            base.Init();
        }

        public override bool TryPlaceStone(Board board, Player player, Player otherPlayer, Config config)
        {
            var isValidMoveAvailable =
                new TryGetRandomMoveCommand(Random, board, player, otherPlayer, config).Execute(out var _);

            if (!isValidMoveAvailable) return false;


            while (IsTimeRemaining())
            {
                var leaf = Selection();
                var child = Expansion(leaf);
                var result = Simulation();
                BackPropagation(result, child);
            }

            // get the move whose node has the highest number of playouts(uct) or highesat ratio (random)
            // include below in method within SelectionPolicy as policy decides what the criteria is.
            //currentnode.children.sort(ratio) instead of tree

            //now need to backtrack up the tree until we find the node whose parent is the current state.

            // AddStoneToCell(board, new Stone(player, otherPlayer),
            // board.Cells[chosenNode.Move.position.x, chosenNode.Move.position.y]);

            return true;
        }

        private Node Selection()
        {
            //selection. chose a random move starting at current state. then continue with random moves until we reach leaf of tree.
            //add back selection policy interface and have a random selection policy implementation. 
            throw new System.NotImplementedException();
        }

        private Node Expansion(Node leaf)
        {
            //expansion. grow the search tree by generating a new child at the leaf.
            throw new System.NotImplementedException();
        }

        private Result Simulation()
        {
            //simulation. perform a playout from new child. states are NOT added search tree
            //use playout policy implementation for this. ??? use the try get random move command in random playout policy to make the simulations?
            //will be interesting to see how many plies deep we go here.
            throw new System.NotImplementedException();
        }

        private void BackPropagation(Result result, Node child)
        {
            //back-propagation. use results of simulation to update all the way up to current state.
            throw new System.NotImplementedException();
        }

        private bool IsTimeRemaining()
        {
            //use stopwatch class? delay in main should deduct time spent here from artificial delay?
            throw new System.NotImplementedException();
        }
    }
}
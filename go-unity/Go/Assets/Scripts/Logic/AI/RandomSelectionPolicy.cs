namespace Logic.AI
{
    public class RandomSelectionPolicy : ISelectionPolicy
    {
        //selection. chose a random move starting at current state. then continue with random moves until we reach leaf of tree.
        public Node SelectChild(Node baseNode)
        {
            //get list of all children of baseNode + its children recursively. then take one of those at random. 
            //if leaf doesn't valid children expansion step will fail.
            throw new System.NotImplementedException();
        }

        public Node SelectMove(Node baseNode)
        {
            //currentnode.children.sort(ratio)
            throw new System.NotImplementedException();
        }
    }
}
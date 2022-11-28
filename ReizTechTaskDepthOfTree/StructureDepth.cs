namespace ReizTechTaskDepthOfTree
{
    public class Branch
    {
        public string name;  //fields
        public List<Branch> child;

        static Branch newBranch(string name)  // 1. Utility method to create a new tree branch
        {
            Branch temp = new Branch();      //creates obj 
            temp.name = name;                //creates NAME
            temp.child = new List<Branch>(); //creates CHILDS 

            return temp; // returns obj
        }

        static int depthOfTree(Branch tree) // 2. method that returns the depth of the tree
        {
            if (tree == null) // Base case
                return 0;
            int maxDepth = 0;
            foreach (Branch point in tree.child) //checking all children
            {
                maxDepth = Math.Max(maxDepth, depthOfTree(point));// finding the max depth, comparing and fixating the result
            }
            return maxDepth + 1;
        }
        /*
         *            A            //tree    
         *         / / \ \
         *         A B C  D        //0;1;2;3
         *         /\  |  |\
         *        E  F G  H I      // 0.0; 0.1 && 2.0; 3.0; 3.1
         *        /\         \
         *        J K         L    //0.0.0; 0.0.1 && 3.1.0
         */
        public static void Main(string[] args)
        {
            Branch tree = newBranch("GrandDad");
            tree.child.Add(newBranch("ADad"));
            tree.child.Add(newBranch("BDad"));
            tree.child.Add(newBranch("CDad"));
            tree.child.Add(newBranch("DDad"));
            tree.child[0].child.Add(newBranch("ESon"));
            tree.child[0].child.Add(newBranch("FSon"));
            tree.child[2].child.Add(newBranch("GSon"));
            tree.child[3].child.Add(newBranch("HSon"));
            tree.child[3].child.Add(newBranch("ISon"));
            tree.child[0].child[0].child.Add(newBranch("JKid"));
            tree.child[0].child[0].child.Add(newBranch("KKid"));
            tree.child[3].child[1].child.Add(newBranch("LKid"));

            Console.Write(depthOfTree(tree));
        }
    }
}

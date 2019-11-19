using System;
/// <summary>
/// This is based on the binary tree found in the book Teach yourself data structures and algorithms 
/// in 24 hours, by Robert Lafore, pp. 297ff.
/// </summary>
namespace bovsclik.Levels
{
    /// <summary>
    /// An ordinary implementation of a tree-class, though without delete-functionality. 
    /// Does not care about unbalancing, since the structure should be small.
    /// </summary>
    public class Tree
    {
        public NodeDungeon rootNode;

        public Tree(NodeDungeon rootNode) 
        {
            this.rootNode = rootNode;
        }
        
        public NodeDungeon FindNode(int nKey)
        {
            NodeDungeon currentNode = rootNode;
            while (currentNode.NKey != nKey) {
                if (nKey < currentNode.NKey) {
                    currentNode = currentNode.LeftChild;
                }
                else {
                    currentNode = currentNode.RightChild;
                }
                if (currentNode == null) {
                    return null;
                }
            }
            return currentNode;
        }
        public void InsertNewNode(int nKey, DungeonData dungeonData) 
        {
            NodeDungeon newNode = new NodeDungeon(dungeonData);
            if (rootNode == null) {
                rootNode = newNode;
            }
            else {
                NodeDungeon currentDungeon = rootNode;
                NodeDungeon parentDungeon;
                while (true) {
                    parentDungeon = currentDungeon;

                    if (nKey < currentDungeon.NKey) {
                        currentDungeon = currentDungeon.LeftChild;
                        if (currentDungeon == null) {
                            parentDungeon.LeftChild = newNode;
                            return;
                        }
                    }
                    else {
                        currentDungeon = currentDungeon.RightChild;
                        if (currentDungeon == null) {
                            parentDungeon.RightChild = newNode;
                            return;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Inorder-traversing only, since the book mentioned above mainly uses it (pp. 317ff).
        /// </summary>
        /// <param name="traverseType"></param>
        public void TraverseNodes(int traverseType, int purpose)
        {
            switch(traverseType) {
                case 0:
                    InOrder(rootNode, purpose);
                    break;
                default:
                    InOrder(rootNode, purpose);
                    break;
            }
        }
        public virtual void InOrder(NodeDungeon rootNodeDungeon, int purpose)
        {
            if (rootNodeDungeon != null) {
                InOrder(rootNodeDungeon.LeftChild, purpose);
                switch (purpose) {
                    case 0:
                        System.Console.WriteLine(rootNodeDungeon.ToString());
                        break;
                    default: // Create room, again, i guess, as a temporary thing. 
                        ;
                        break;
                }
                InOrder(rootNodeDungeon.RightChild, purpose);
            }
        }
        public void DisplayTree()
        {
            throw new NotImplementedException();
        }
    }
}

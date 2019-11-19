using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bovsclik.Levels
{
    public static class LevelCreatorBinaryTree
    {
        public static Level CreateLevel(int height, int width)
        {
            string[,] textRepr = new string[height, width];
            //This has a size of 0 * 100 and placement in the middle to have a starting point for children. 
            DungeonData parentData = new DungeonData {TopX = 0, TopY = 100, Width = 0, Height = 0};
            DungeonData leftData = new DungeonData { TopX = 0, TopY = 0, Width = 250, Height = 100};
            DungeonData rightData = new DungeonData { TopX = 0, TopY = 100, Width = 250, Height = 100 };
            NodeDungeon parentNode = new NodeDungeon(parentData);
            TreeDungeon tree = new TreeDungeon(parentNode);
            tree.InsertNewNode(leftData.TopY, leftData);
            tree.InsertNewNode(rightData.TopY, rightData);
            InsertNewNodeDungeons(tree);

            List<NodeDungeon> dNodes = new List<NodeDungeon>();
            dNodes = tree.GetDungeonNodes(tree.rootNode, dNodes);
            dNodes = CreateDungeonRooms(dNodes);
            textRepr = ConvertDungeonToText(dNodes, height, width);

            Level newLevel = new Level(textRepr);
            return newLevel;

        }
        public static void InsertNewNodeDungeons(TreeDungeon tree)
        {
            for (int i = 0; i < 2; i++) {
                tree.TraverseNodes(0, 2);
            }
        }
        public static string[,] ConvertDungeonToText(List<NodeDungeon> dungeons, int height, int width)
        {
            string[,] level = new string[height, width];
            foreach (NodeDungeon node in dungeons) {
                if (node.DungeonData.Height > 0 && node.DungeonData.Width > 0 && (node.LeftChild != null || node.RightChild != null)) {
                    throw new Exception("ERROR: non-leaf has area.");
                }
                if (node.DungeonData.Height == 0 && node.DungeonData.Width == 0 && node.LeftChild == null && node.RightChild == null) {
                    throw new Exception("ERROR: leaf is without size || nDTH=" + node.DungeonData.Height + 
                        " || nDTW=" + node.DungeonData.Width + " || nLC=" + node.LeftChild + " || nRC=" + node.RightChild + 
                        " || rW=" + node.DungeonData.DungeonRoom.Width + " || rH=" + node.DungeonData.DungeonRoom.Height);
                }
                DungeonData dData = node.DungeonData;
                for (int y = dData.TopY; y < dData.TopY + dData.Height; y++) {
                    for (int x = dData.TopX; x < dData.TopX + dData.Width; x++) {
                        level[y, x] = "X";
                    }
                }
                DungeonRoom dRoom = node.DungeonData.DungeonRoom;
                for (int y = dRoom.TopY; y < dRoom.TopY + dRoom.Height; y++) {
                    for (int x = dRoom.TopX; x < dRoom.TopX + dRoom.Width; x++) {
                        level[y, x] = "R";
                    }
                }
            }
            return level;
        }
        /// <summary> 
        /// Based on http://roguebasin.com/index.php?title=Basic_BSP_Dungeon_generation
        /// </summary>
        /// <param name="nodeDungeons"></param>
        /// <returns></returns>
        public static List<NodeDungeon> CreateDungeonRooms(List<NodeDungeon> nodeDungeons)
        {
            foreach(NodeDungeon node in nodeDungeons) {
                //int MAXHEIGHT = node.DungeonData.Height;
                //int MAXWIDTH = node.DungeonData.Width;
                //int height = Main.randomize.Next(0, MAXHEIGHT);
                //int width = Main.randomize.Next(0, MAXWIDTH);
                //int topX = Main.randomize.Next(node.DungeonData.TopX, node.DungeonData.TopX + MAXWIDTH - width);
                //int topY = Main.randomize.Next(node.DungeonData.TopY, node.DungeonData.TopY + MAXHEIGHT - height);
                //DungeonRoom newRoom = new DungeonRoom {
                //    TopY = topY,
                //    TopX = topX,
                //    Height = height,
                //    Width = width
                //};

                node.DungeonData.DungeonRoom = CreateRoom(node.DungeonData);
            }
            return nodeDungeons;
        }
        
        public static DungeonRoom CreateRoom(DungeonData dData)
        {
            DungeonRoom room = new DungeonRoom();
            int MAXHEIGHT = dData.Height;
            int MAXWIDTH = dData.Width;
            int width;
            int height;
            int topY;
            int topX;

            int size = Main.randomize.Next(0, 100);

            if (size <= 20) { // Small room. 
                height = Main.randomize.Next(0, MAXHEIGHT); 
                width = Main.randomize.Next(0, MAXWIDTH);
            } else if (size > 20 && size <= 50) { // Medium-sized room. 
                int wideOrTall = Main.randomize.Next(0, 1);
                if (wideOrTall == 0) { // Wide
                    height = Main.randomize.Next(1, MAXHEIGHT);
                    width = Main.randomize.Next(MAXWIDTH / 2, MAXWIDTH);
                } else { // Tall
                    height = Main.randomize.Next(MAXHEIGHT / 2, MAXHEIGHT);
                    width = Main.randomize.Next(1, MAXWIDTH);
                }
            } else { // Large room.
                height = Main.randomize.Next(MAXHEIGHT / 2, MAXHEIGHT);
                width = Main.randomize.Next(MAXWIDTH / 2, MAXWIDTH);
            }
            topY = MAXHEIGHT == height ? dData.TopY : (Main.randomize.Next(dData.TopY, dData.TopY + MAXHEIGHT - height));
            topX = MAXWIDTH == width ? dData.TopX : (Main.randomize.Next(dData.TopX, dData.TopX + MAXWIDTH - width));
            room = new DungeonRoom {
                Height = height,
                Width = width,
                TopY = topY,
                TopX = topX,
            };
            return room;
        }
    }
    /// <summary>
    /// More precise/customized implementation of the Tree-class. 
    /// </summary>
    public class TreeDungeon : Tree 
    {
        public TreeDungeon(NodeDungeon rootNode) : base(rootNode)
        {
        }
        public override void InOrder(NodeDungeon rootNodeDungeon, int purpose)
        {
            if (rootNodeDungeon != null) {
                InOrder(rootNodeDungeon.LeftChild, purpose);
                switch (purpose) {
                    case 0: // Create room.
                        ;
                        break;
                    case 1: // Get room from NodeDungeon, for printing. 
                        ;
                        break;
                    case 2: // If room has no children, create new children
                        CreateNewNodeDungeonsFromLeaf(rootNodeDungeon);
                        break;
                    case 3: // Debugging, writes the toString to console.
                        System.Console.WriteLine(rootNodeDungeon.ToString());
                        break;
                    default: // Create room, again, i guess, as a temporary thing. 
                        ;
                        break;
                }
                // This (the switch case) is placed here, in the middle, with the purpose of only
                // poking around with the data once, after we've exhausted the
                // left part of the tree. Or, i might be wrong. Anywhyhow...
                InOrder(rootNodeDungeon.RightChild, purpose);
            }
        }
        public void CreateNewNodeDungeonsFromLeaf(NodeDungeon nodeDungeon)
        {
            if (nodeDungeon.LeftChild == null && nodeDungeon.RightChild == null) {
                int MAXHEIGHT = nodeDungeon.DungeonData.Height;
                int MAXWIDTH = nodeDungeon.DungeonData.Width;
                if (MAXHEIGHT < 4 || MAXWIDTH < 5) { // Too small to make new Dungeon, so ignore.
                    return;
                }
                DungeonData leftChildData = null;
                DungeonData rightChildData = null;
                NodeDungeon leftChild = null;
                NodeDungeon rightChild = null;
                DungeonData nodeData = nodeDungeon.DungeonData;
                int splitDirection = Main.randomize.Next(0, 2);
                if (splitDirection == 0) { // Split vertically: ||
                    int split;
                    if (MAXWIDTH == 6) {
                        split = 3;
                    } else {
                        split = Main.randomize.Next(1, MAXWIDTH);
                    }
                    leftChildData = new DungeonData { TopX = nodeData.TopX, TopY = nodeData.TopY, Width = split, Height = nodeData.Height };
                    rightChildData = new DungeonData {
                        TopX = nodeData.TopX + split,
                        TopY = nodeData.TopY,
                        Width = nodeData.Width - split,
                        Height = nodeData.Height
                    };
                    leftChild = new NodeDungeon(leftChildData);
                    rightChild = new NodeDungeon(rightChildData);
                } else if (splitDirection == 1) { // Split horizontally: ---
                    int split;
                    if (MAXHEIGHT == 6) {
                        split = 3;
                    } else {
                        split = Main.randomize.Next(1, MAXHEIGHT);
                    }
                    leftChildData = new DungeonData { TopX = nodeData.TopX, TopY = nodeData.TopY, Width = nodeData.Width, Height = split };
                    rightChildData = new DungeonData {
                        TopX = nodeData.TopX,
                        TopY = nodeData.TopY + split,
                        Width = nodeData.Width,
                        Height = nodeData.Height - split
                    };
                    leftChild = new NodeDungeon(leftChildData);
                    rightChild = new NodeDungeon(rightChildData);
                }
                nodeDungeon.LeftChild = leftChild;
                nodeDungeon.RightChild = rightChild;
                nodeDungeon.DungeonData = null;
            }
        }
        public List<NodeDungeon> GetDungeonNodes(NodeDungeon node, List<NodeDungeon> nodeDungeons)
        {
            if (node != null) {
                nodeDungeons = GetDungeonNodes(node.LeftChild, nodeDungeons);
                if (node.LeftChild == null && node.RightChild == null) {
                    nodeDungeons.Add(node);
                }
                nodeDungeons = GetDungeonNodes(node.RightChild, nodeDungeons);
            }
            return nodeDungeons;
        }
    }
}

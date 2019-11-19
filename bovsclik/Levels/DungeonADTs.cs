namespace bovsclik.Levels
{
    public class DungeonData
    {
        public int TopX { get; set; }
        public int TopY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public DungeonRoom DungeonRoom { get; set; }
    }
    public class DungeonRoom
    {
        public int TopX { get; set; }
        public int TopY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
    public class NodeDungeon
    {
        public int NKey { get; set; }
        public DungeonData DungeonData { get; set; }
        public NodeDungeon LeftChild { get; set; }
        public NodeDungeon RightChild { get; set; }

        public NodeDungeon(DungeonData dData)
        {
            LeftChild = null;
            RightChild = null;
            DungeonData = dData;
            NKey = DungeonData.TopY;
        }
        public override string ToString()
        {
            return "size=" + (DungeonData == null ? "null" : (DungeonData.Width * DungeonData.Height).ToString()) +
                " NKey=" + NKey + 
                " hasChildren? l: " + (LeftChild == null ? "null" : "CHILD") +
                " --- r:" + (RightChild == null ? "null" : " CHILD");
        }
    }
}

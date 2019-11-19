using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bovsclik
{
    class Player : View.IScreenPrinting
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Mp { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        private int oldX;
        private int oldY;
        public Player()
        {
            Hp = 100;
            Mp = 5;
            X = 50;
            Y = 50;
        }
        /*
         * TODO: this method, i.e. GetKeyPress(Key key) shouldn't directly change the location of 
         * the character. For example, collision detection with walls, battle, interactions etc.
         * must also be checked. Thus, i guess, uh, something. Think this thru!
         * */
        public void GetKeyPress(Key key, Level level) 
        {
            MovePlayer(key, level);
        }
        public void MovePlayer(Key key, Level level) {
            if (key.Equals(Key.Up) && Y > 0) {
                Y--;
            } else if (key.Equals(Key.Down) && Y < level.Height - 1) {
                Y++;
            } else if (key.Equals(Key.Left) && X > 0) {
                X--;
            } else if (key.Equals(Key.Right) && X < level.Width - 1) {
                X++;
            }
        }
        public TextRow[] GetAllText()
        {
            TextRow tr = new TextRow {
                x = X,
                y = Y,
                message = "@"
            };
            throw new NotImplementedException();
        }
    }
}

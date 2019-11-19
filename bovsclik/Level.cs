using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bovsclik
{
    public class Level : View.IScreenPrinting
    {
        public string[,] textRepr { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        private ArrayList enemies;
        public Level()
        {
            ;
        }
        public Level(string[,] textRepr)
        {
            this.textRepr = textRepr;
            Height = 200;
            Width = 250;
        }
        public TextRow[] GetAllText()
        {
            throw new NotImplementedException();
        }
    }
}

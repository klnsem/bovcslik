using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bovsclik
{
    class StartScreen: View.IScreenPrinting
    {
        private TextRow[] screenText;
        public StartScreen()
        {
            CreateIntroPage();
        }
        private void CreateIntroPage()
        {
            TextRow tr1 = new TextRow {
                x = 5,
                y = 5,
                message = "hello darkness my old friend"
            };
            TextRow tr2 = new TextRow {
                x = 10,
                y = 10,
                message = "something something again"
            };
            TextRow tr3 = new TextRow {
                x = 20,
                y = 15,
                message = "######### @ ##"
            };
            screenText = new TextRow[3];
            screenText[0] = tr1;
            screenText[1] = tr2;
            screenText[2] = tr3;
        }

        public TextRow[] GetAllText()
        {
            return screenText;
        }
    }
}

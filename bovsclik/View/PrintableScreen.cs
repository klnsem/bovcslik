using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bovsclik.View
{

    class PrintableScreen
    {
        private List<TextRow> allPrintable = new List<TextRow>();
        public bool FinishedPrintable { get; set; }
        public PrintableScreen()
        {
            FinishedPrintable = false;
        }
    }
}

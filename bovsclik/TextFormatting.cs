using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bovsclik
{
    public enum TextAlignment { NONE, LEFT, CENTER, RIGHT };
    public struct TextRow // Note to self: without constructor seems a tad faster than with. 
    {
        public int x;
        public int y;
        public string message;
        public TextAlignment textAlignment;
    }
    class TextFormatting
    {
        public static TextRow AlignText(TextAlignment alignment, TextRow textRow) 
        {
            if (textRow.message.Length > 50) {
                throw new Exception("Exception: tried to align a row longer" +
                    "than 50 characters.");
            }
            if (alignment == TextAlignment.LEFT) {
                textRow.x = 0;
                textRow.textAlignment = TextAlignment.LEFT;
            }
            if (alignment == TextAlignment.RIGHT) {
                textRow.x = 50 - textRow.message.Length;
                textRow.textAlignment = TextAlignment.RIGHT;
            }
            if (alignment == TextAlignment.CENTER) {
                int charsLeft = 50 - textRow.message.Length;
                textRow.textAlignment = TextAlignment.CENTER;
                if (textRow.message.Length % 2 == 0) {
                    textRow.x = charsLeft / 2;
                }
                else { // Yeah, even + uneven = uneven, so we're making the best of it.
                    textRow.x = charsLeft - 1;
                }
            }

            return textRow;
        }
    }
}

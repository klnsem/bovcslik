using bovsclik.View;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bovsclik
{
    abstract class Viewer
    /// <summary>
    /// Makes it, in theory, possible to use something other than a console;
    /// maybe some nice pixel graphics. Note: it won't happen, but it could!
    /// </summary>
    {
        /// <summary>
        /// Used to print the screen when in game, including a Message.
        /// </summary>
        public abstract void CreateScreen(Player player, Level level, Camera camera, Message message);
        /// <summary>
        /// Used to print the screen when in game.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="level"></param>
        public abstract void CreateScreen(Player player, Level level, Camera camera);
        /// <summary>
        /// Used to print special screens, i.e. intros, endings etc. 
        /// </summary>
        /// <param name="screenPrint"></param>
        public abstract void CreateScreen(IScreenPrinting screenPrint);
        /// <summary>
        /// Used to print a pure, 2D, textarray to the screen. 
        /// </summary>
        /// <param name="textArray"></param>
        public abstract void CreateScreen(string[,] textArray);
        /// <summary>
        /// Used by Main.cs.MainLoop() to decide if user has closed the window. 
        /// </summary>
        /// <returns></returns>
        public abstract bool ScreenOpen();
        public abstract bool HasInput();
        public abstract Key GetPressedKey();
        public abstract bool Quitting();
    }
}

using bovsclik.Levels;
using bovsclik.View;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bovsclik
{
    class Main
    {
        public const int WIDTH = 50;
        public const int HEIGHT = 44;
        private Viewer console;
        private Player player;
        private Level level;
        private Camera camera;
        public static Random randomize;

        public Main()
        {
            Initialize();
            _DEBUG_printIntro();
            MainLoop();
        }
        protected void Initialize()
        {
            console = new SunshineConsoleViewer(new SunshineConsole.ConsoleWindow(HEIGHT, WIDTH, "bovCSlik"));
            player = new Player();
            camera = new Camera(player);
            randomize = new Random();
        }
        protected void StartNewGame()
        {

        }
        protected void _DEBUG_printIntro()
        {
            StartScreen sc = new StartScreen();
            console.CreateScreen(sc);
        }
        protected void MainLoop()
        {
            bool isRunning = true;
            level = LevelCreatorBinaryTree.CreateLevel(200, 250);
            while (console.ScreenOpen() && isRunning) {
                if (console.HasInput()) {
                    Key k = console.GetPressedKey();
                    if (k.Equals(Key.L)) {
                        ;
                    }
                    if (k.Equals(Key.Q)) {
                        isRunning = false;
                    }
                    if (k.Equals(Key.Up) || k.Equals(Key.Down) || k.Equals(Key.Left) || k.Equals(Key.Right)) {
                        // TODO: Replace this with a check against a list, which should be like:
                        // if (listWithPlayerKeys.Contains(k) more or less.
                        player.GetKeyPress(k, level);
                        camera.CameraWantsMovement(player);
                        console.CreateScreen(player, level, camera);
                        //System.Console.WriteLine("topX=" + camera.TopX + " topY=" + camera.TopY + " py=" + camera.PlayerY + 
                        //    " px=" + camera. PlayerX);
                    }
                }

                System.Threading.Thread.Sleep(10);
            }
        }
    }
}

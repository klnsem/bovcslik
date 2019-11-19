using OpenTK.Graphics;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bovsclik.View
{
    class SunshineConsoleViewer : Viewer
    {
        protected SunshineConsole.ConsoleWindow console;
        public SunshineConsoleViewer(SunshineConsole.ConsoleWindow console)
        {
            this.console = console;
        }
        public override void CreateScreen(Player player, Level level, Camera camera, Message message)
        {
            TextRow[] textRows = new TextRow[(player.GetAllText().Length)+(level.GetAllText().Length)+(message.GetAllText().Length)];
            WriteToConsole(textRows);
        }
        public override void CreateScreen(Player player, Level level, Camera camera)
        {
            WriteToConsole(player, level, camera);
        }
        public override void CreateScreen(IScreenPrinting screenPrint)
        {
            WriteToConsole(screenPrint.GetAllText());
        }

        public override void CreateScreen(string[,] textArray) //TODO: remove the code that's in here for debugging.
        {
            //console.Write(0, 0, "butts", Color4.White);
            Random rnd = new Random();
            Color4 color = Color4.White;
            for (int y = 0; y < Main.HEIGHT; y++) {
                for (int x = 0; x < Main.WIDTH; x++) {
                    //System.Console.WriteLine("y=" + y + " x=" + x);
                    switch (textArray[y,x]) {
                        case "0":
                            color = Color4.Green;
                            break;
                        case "1":
                            color = Color4.Blue;
                            break;
                        case "2":
                            color = Color4.Yellow;
                            break;
                        case "3":
                            color = Color4.Orange;
                            break;
                        case "4":
                            color = Color4.Red;
                            break;
                        case "5":
                            color = Color4.Purple;
                            break;
                        case "6":
                            color = Color4.LightCoral;
                            break;
                        case "7":
                            color = Color4.Beige;
                            break;
                        case "8":
                            color = Color4.Salmon;
                            break;
                        case "9":
                            color = Color4.IndianRed;
                            break;
                        default:
                            color = Color4.White;
                            break;
                    }
                    console.Write(y, x, textArray[y, x], color);
                }
            }
            console.WindowUpdate();
        }

        public override Key GetPressedKey()
        {
            return console.GetKey();
        }

        public override bool HasInput()
        {
            return console.KeyPressed;
        }

        public override bool Quitting() //TODO: make it so q doesn't always quit
        {
            if (GetPressedKey() == Key.Q) {
                return true;
            }
            else {
                return false;
            }
        }
        public override bool ScreenOpen()
        {
            return console.WindowUpdate();
        }

        public void WriteToConsole(TextRow[] textRows)
        {
            foreach (TextRow text in textRows) {
                console.Write(text.y, text.x, text.message, Color4.White);
            }
            console.WindowUpdate();
        }
        public void WriteToConsole(TextRow[] textRows, Camera camera) //TODO: DELETE THIS METHOD
        {
            ;
        }

        public void WriteToConsole(Player player, Level level, Camera camera)
        {
            console.HoldUpdates();
            string[,] fullLevel = level.textRepr;
            for (int y = 0; y < Main.HEIGHT; y++) {
                for (int x = 0; x < Main.WIDTH; x++) {
                    if (camera.TopX + x < 0 || camera.TopX + x >= level.Width
                        || camera.TopY + y < 0 || camera.TopY + y >= level.Height) {
                        console.Write(y, x, " ", Color4.Black);
                    }
                    else {
                        //System.Console.WriteLine("y=" + y + " x=" + x + " c.tY=" + camera.TopY + " c.tX=" + camera.TopX + " smb=" + 
                        //    fullLevel[camera.TopY + y - 1, camera.TopX + x - 1]);
                        if (fullLevel[camera.TopY + y, camera.TopX + x].Equals("X")) {
                            console.Write(y, x, fullLevel[camera.TopY + y, camera.TopX + x], Color4.Gray);
                        }
                        else if (fullLevel[camera.TopY + y, camera.TopX + x].Equals("O")) {
                            console.Write(y, x, fullLevel[camera.TopY + y, camera.TopX + x], Color4.Gray);
                        }
                        else if (fullLevel[camera.TopY + y, camera.TopX + x].Equals("_")) {
                            console.Write(y, x, fullLevel[camera.TopY + y, camera.TopX + x], Color4.Gray);
                        } 
                        else if (fullLevel[camera.TopY + y, camera.TopX + x].Equals("R")) {
                            console.Write(y, x, fullLevel[camera.TopY + y, camera.TopX + x], Color4.Green);
                        }                        
                        //console.Write(y, x, fullLevel[camera.TopY + y, camera.TopX + x], Color4.Brown);
                        //if (fullLevel[camera.TopY + y, camera.TopX + x].Equals("X")) {
                        //    console.Write(y, x, fullLevel[camera.TopY + y, camera.TopX + x], Color4.Brown);
                        //} else {
                        //    console.Write(y, x, fullLevel[camera.TopY + y, camera.TopX + x], Color4.White);
                        //}
                    }
                }
            }
            console.Write(player.Y - camera.TopY, player.X - camera.TopX, "@", Color4.Red);
            console.ResumeUpdates();
            console.WindowUpdate();

        }
    }
}

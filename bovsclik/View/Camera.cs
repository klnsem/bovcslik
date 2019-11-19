using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bovsclik.View
{
    class Camera
    {
        public int TopX { get; set; }
        public int TopY { get; set; }
        public int PlayerX { get; set; }
        public int PlayerY { get; set; }
        public Camera(Player player)
        {

            TopX = player.X - (Main.WIDTH / 2);
            TopY = player.Y - (Main.HEIGHT / 2);
        }
        public void CameraWantsMovement(Player player)
        {
            PlayerX = player.X;
            PlayerY = player.Y;
            bool b = false;
            if ((TopX + 6) == PlayerX) {
                b = true;
                TopX--;
            }
            else if ((TopX + Main.WIDTH - 6) == PlayerX) {
                b = true;
                TopX++;
            }
            else if ((TopY + 6) == PlayerY) {
                b = true;
                TopY--;
            }
            else if ((TopY + Main.HEIGHT - 6) == PlayerY) {
                b = true;
                TopY++;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace The_Nights_Of_Lurnia.CameraService
{
    static class Camera
    {
        public static Vector2 Position;
        public static int MoveSpeed;

        static Camera()
        {
            Position = new Vector2(0,0);
            MoveSpeed = 16;
        }

        public static void MoveUp()
        {
            Position.Y -= MoveSpeed;
        }
        public static void MoveDown()
        {
            Position.Y += MoveSpeed;
        }
        public static void MoveLeft()
        {
            Position.X -= MoveSpeed;
        }
        public static void MoveRight()
        {
            Position.X += MoveSpeed;
        }

    }
}

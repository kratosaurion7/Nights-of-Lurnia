using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using The_Nights_Of_Lurnia.Map;

namespace The_Nights_Of_Lurnia.Camera
{
    public class Camera
    {
        private static Vector2 cameraPosition;
        public static Vector2 CameraPosition
        {
            get { return Camera.cameraPosition; }
            set { Camera.cameraPosition = value; }
        }

        private static float moveSpeed;
        public static float MoveSpeed
        {
            get { return Camera.moveSpeed; }
            set { Camera.moveSpeed = value; }
        }

        /// <summary>
        /// Create a new Camera and place it at the default location.
        /// </summary>
        public Camera()
        {
            cameraPosition = new Vector2(32, 32);
            moveSpeed = 32;
        }

        /// <summary>
        /// Create a new Camera and place it at the specified location.
        /// </summary>
        /// <param name="posX">Starting position X</param>
        /// <param name="posY">Starting position Y</param>
        public Camera(int posX, int posY)
        {
            cameraPosition = new Vector2(posX, posY);
            moveSpeed = 32;
        }

        /// <summary>
        /// Create a new Camera and place it at the specified location while specifying a move speed.
        /// </summary>
        /// <param name="posX">Starting position X</param>
        /// <param name="posY">Starting position Y</param>
        /// <param name="pMoveSpeed">Move speed in pixels of the camera.</param>
        public Camera(int posX, int posY, float pMoveSpeed)
        {
            cameraPosition = new Vector2(posX, posY);
            moveSpeed = pMoveSpeed;

        }


    }
}

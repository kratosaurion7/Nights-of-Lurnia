using Microsoft.Xna.Framework;

namespace The_Nights_Of_Lurnia.CameraService
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

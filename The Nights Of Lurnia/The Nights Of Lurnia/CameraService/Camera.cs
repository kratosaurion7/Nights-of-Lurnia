using Microsoft.Xna.Framework;
using The_Nights_Of_Lurnia.Map;

namespace The_Nights_Of_Lurnia.CameraService
{
    public class Camera
    {
        // All integers are in Tiles and not in pixels.
        // The camera does not bother with pixels or anything.

        private Vector2 _cameraPosition;
        public Vector2 CameraPosition
        {
            get { return _cameraPosition; }
            set { _cameraPosition = value; }
        }

        private int _moveSpeed; // How many tiles per movement will be passed.
        public int MoveSpeed
        {
            get { return _moveSpeed; }
            set { _moveSpeed = value; }
        }

        private int _cameraHeight;
        public int CameraHeight
        {
            get { return _cameraHeight; }
            set { _cameraHeight = value; }
        }

        private int _cameraWidth;
        public int CameraWidth
        {
            get { return _cameraWidth; }
            set { _cameraWidth = value; }
        }

        private Zone _parentZone;

        /// <summary>
        /// Create a new Camera and place it at the default location.
        /// </summary>
        /// <param name="parentZone">Zone containing the camera.</param>
        public Camera(Zone parentZone)
        {
            _parentZone = parentZone;

            _cameraPosition = new Vector2(0, 0); // Start the position at default (0,0)
            _moveSpeed = _parentZone.TileHeight; // Movespeed equal to the height/width of a tile

            _cameraHeight = _parentZone.ZoneHeight;
            _cameraWidth = _parentZone.ZoneWidth;

        }

        /// <summary>
        /// Create a new Camera and place it at the specified location.
        /// </summary>
        /// <param name="parentZone">Zone containing the camera.</param>
        /// <param name="posX">Starting position tile X.</param>
        /// <param name="posY">Starting position tile Y.</param>
        public Camera(Zone parentZone, int posX, int posY)
        {
            _parentZone = parentZone;

            _cameraPosition = new Vector2(posX, posY);
            _moveSpeed = 32;

            _cameraHeight = _parentZone.ZoneHeight;
            _cameraWidth = _parentZone.ZoneWidth;

        }

        /// <summary>
        /// Create a new Camera and place it at the specified location while specifying a move speed.
        /// </summary>
        /// <param name="parentZone">Zone containing the camera.</param>
        /// <param name="posX">Starting position X</param>
        /// <param name="posY">Starting position Y</param>
        /// <param name="cameraHeight">Height in tiles of the Camera field of view.</param>
        /// <param name="cameraWidth">Width in tiles of the Camera field of view.</param>
        public Camera(Zone parentZone, int posX, int posY, int cameraHeight, int cameraWidth)
        {
            _parentZone = parentZone;
            _cameraHeight = cameraHeight;
            _cameraWidth = cameraWidth;
            _cameraPosition = new Vector2(posX, posY);

        }

        public void MoveLeft()
        {
            _cameraPosition.X -= _moveSpeed;
        }

        public void MoveRight()
        {
            _cameraPosition.X += _moveSpeed;
        }

        public void MoveUp()
        {
            _cameraPosition.Y -= _moveSpeed;
        }

        public void MoveDown()
        {
            _cameraPosition.Y += _moveSpeed;
        }


    }
}

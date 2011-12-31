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
using The_Nights_Of_Lurnia.CameraService;

namespace The_Nights_Of_Lurnia.Map
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Zone : Microsoft.Xna.Framework.DrawableGameComponent
    {
        // Services
        private SpriteBatch spriteBatch;

        // Zone properties
        private int zoneWidth; // Width & Height in absolute units. NOT by pixel
        private int zoneHeight;

        private int[,] tileValues; // Texture values of each tile

        private Tile[,] zoneTiles; // Array of instanced tiles

        // Tile values
        private int tileWidth; // Width & Height in pixels of each tiles.
        private int tileHeight;

        public int ZoneWidth
        {
            get { return zoneWidth; }
            set { zoneWidth = value; }
        }

        public int ZoneHeight
        {
            get { return zoneHeight; }
            set { zoneHeight = value; }
        }

        public int TileWidth
        {
            get { return tileWidth; }
            set { tileWidth = value; }
        }

        public int TileHeight
        {
            get { return tileHeight; }
            set { tileHeight = value; }
        }

        // Camera
        private Camera gameCam;


        // DEBUG Stuff
        static Random randomMaker = new Random();

        public Zone(Game game, int width, int height)
            : base(game)
        {
            // Zone Values
            ZoneWidth = width;
            ZoneHeight = height;
        }


        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // Query services
            spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            gameCam = (Camera) Game.Services.GetService(typeof (Camera));

            // Create Zone
            CreateTiles();
            FillRandomValues();

            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            for (int i = (int)gameCam.CameraPosition.Y; i < gameCam.CameraPosition.Y + gameCam.CameraHeight; i++)
            {// Doing for each row : 
                for (int j = (int)gameCam.CameraPosition.X; j < gameCam.CameraPosition.X + gameCam.CameraWidth; j++)
                {// Doing for each column : 
                    /* A problem could arise here. The draw from the tile uses
                     * gameTime, the gameTime stamp from this procedure. If the 
                     * treatement in this Draw function is big/huge the gameTime
                     * stamp is going to be the same for every calls inside this procedure
                     * only going to change at the next Draw() of Zone. Mistiming
                     * may happen. Of course if gameTime is a reference to the 
                     * stamp of the game and it is updated asyncronously the problem
                     * will not happen.
                     */
                    Vector2 tileNextPosition = new Vector2(j * tileWidth, i * tileHeight);

                    switch (tileValues[j,i])
                    {
                        case 0:
                            zoneTiles[j, i].Draw(gameTime, new Rectangle(0,0,32,32), tileNextPosition);
                            break;
                        case 1:
                            zoneTiles[j, i].Draw(gameTime, new Rectangle(32, 0, 32, 32), tileNextPosition);
                            break;
                        case 2:
                            zoneTiles[j, i].Draw(gameTime, new Rectangle(64, 0, 32, 32), tileNextPosition);
                            break;
                        case 3:
                            zoneTiles[j, i].Draw(gameTime, new Rectangle(96, 0, 32, 32), tileNextPosition);
                            break;
                        case 4:
                            zoneTiles[j, i].Draw(gameTime, new Rectangle(128, 0, 32, 32), tileNextPosition);
                            break;
                    }
                }
            }
            base.Draw(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < ZoneWidth; i++)
            {// Doing for each row : 
                for (int j = 0; j < ZoneHeight; j++)
                {// Doing for each column : 
                    /* Same problem as the above Draw() function.
                     * Mistiming due to the possibly byvalue nature of 
                     * the gameTime parameter opposed to referenced.
                     */
                    zoneTiles[j, i].Update(gameTime);
                }
            }


            base.Update(gameTime);
        }

        private void CreateTiles()
        {
            // Array dimensions
            tileValues = new int[ZoneWidth, ZoneHeight];
            zoneTiles = new Tile[ZoneWidth, ZoneHeight];

            // Give the tiles a Width & Height. Temporary value at 32
            TileWidth = 32;
            TileHeight = 32;

            for (int i = 0; i < ZoneHeight; i++)
            {// Doing for each row : 
                for (int j = 0; j < ZoneWidth; j++)
                {// Doing for each column : 
                    // Create tile
                    Tile newTile = new Tile(Game, this, new Vector2(j * TileWidth, i * TileHeight));

                    // Associate tile with sprite
                    newTile.LoadContent(Game.Content, "simple");
                    newTile.Initialize(); // Have to babysit again
                    // Place the tile in the array
                    zoneTiles[j, i] = newTile;
                }
            }
        }

        private void FillRandomValues()
        {
            for (int i = 0; i < ZoneHeight; i++)
            {// Doing for each row : 
                for (int j = 0; j < ZoneWidth; j++)
                {// Doing for each column : 
                    tileValues[j, i] = randomMaker.Next(0, 4);

                }
            }

        }

        public void ReCreateMap()
        {
            FillRandomValues();
            
        }
    }
}

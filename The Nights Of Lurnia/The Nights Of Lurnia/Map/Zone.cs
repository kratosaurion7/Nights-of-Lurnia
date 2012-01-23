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
        private int zoneWidth; // Width & Height in tile units. NOT by pixel
        private int zoneHeight;

        private int[,] tileValues; // Texture values of each tile

        private Tile[,] zoneTiles; // Array of instanced tiles

        private Spritesheet simpleSpritesheet; 

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
            simpleSpritesheet = (Spritesheet) Game.Services.GetService(typeof (Spritesheet));

            // Create Zone
            CreateTiles();
            FillRandomValues();

            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            // Position in Tiles(because of the x / 32) of the first Tile in the upper left corner. 
            int TileSize = tileHeight;
            Vector2 firstTilePosition = new Vector2(Camera.Position.X / TileSize, Camera.Position.Y / TileSize);

            // Offset is used to draw only portions of a tile.
            Vector2 squareOffset = new Vector2(Camera.Position.X % TileSize, Camera.Position.Y % TileSize);

            for (int y = 0; y < zoneHeight; y++)
            {
                for (int x = 0; x < zoneWidth; x++)
                {
                    Rectangle tileNextPosition = new Rectangle((x*tileWidth) - (int)squareOffset.X,
                                                               (y*tileHeight) - (int)squareOffset.Y,
                                                               tileHeight,
                                                               tileWidth);

                        switch (tileValues[x + (int)firstTilePosition.X, y + (int)firstTilePosition.Y])
                        {
                            case 0:
                                zoneTiles[x, y].Draw(gameTime, new Rectangle(0, 0, tileHeight, tileWidth), tileNextPosition);
                                break;
                            case 1:
                                zoneTiles[x, y].Draw(gameTime, new Rectangle(32, 0, tileHeight, tileWidth), tileNextPosition);
                                break;
                            case 2:
                                zoneTiles[x, y].Draw(gameTime, new Rectangle(64, 0, tileHeight, tileWidth), tileNextPosition);
                                break;
                            case 3:
                                zoneTiles[x, y].Draw(gameTime, new Rectangle(96, 0, tileHeight, tileWidth), tileNextPosition);
                                break;
                            case 4:
                                zoneTiles[x, y].Draw(gameTime, new Rectangle(128, 0, tileHeight, tileWidth), tileNextPosition);
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

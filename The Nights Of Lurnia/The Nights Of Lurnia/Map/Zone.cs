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

        // DEBUG Stuff
        Random randomMaker = new Random();

        public Zone(Game game, int width, int height)
            : base(game)
        {
            // Zone Values
            zoneWidth = width;
            zoneHeight = height;

        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // Query services
            spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));


            // Create Zone
            CreateTestGrid();
            fillRandomValues();

            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            for (int i = 0; i < zoneWidth; i++)
            {// Doing for each row : 
                for (int j = 0; j < zoneHeight; j++)
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
                    switch (tileValues[j,i])
                    {
                        case 0:
                            zoneTiles[j, i].Draw(gameTime, new Rectangle(0,0,32,32));
                            break;
                        case 1:
                            zoneTiles[j, i].Draw(gameTime, new Rectangle(32, 0, 32, 32));
                            break;
                        case 2:
                            zoneTiles[j, i].Draw(gameTime, new Rectangle(64, 0, 32, 32));
                            break;
                        case 3:
                            zoneTiles[j, i].Draw(gameTime, new Rectangle(96, 0, 32, 32));
                            break;
                        case 4:
                            zoneTiles[j, i].Draw(gameTime, new Rectangle(128, 0, 32, 32));
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
            for (int i = 0; i < zoneWidth; i++)
            {// Doing for each row : 
                for (int j = 0; j < zoneHeight; j++)
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

        private void CreateTestGrid()
        {
            // Array dimensions
            tileValues = new int[zoneWidth, zoneHeight];
            zoneTiles = new Tile[zoneWidth, zoneHeight];

            // Give the tiles a Width & Height. Temporary value at 32
            tileWidth = 32;
            tileHeight = 32;

            for (int i = 0; i < zoneHeight; i++)
            {// Doing for each row : 
                for (int j = 0; j < zoneWidth; j++)
                {// Doing for each column : 
                    // Create tile
                    Tile newTile = new Tile(Game, this, new Vector2(j * tileWidth, i * tileHeight));

                    // Associate tile with sprite
                    newTile.LoadContent(Game.Content, "simple");
                    newTile.Initialize(); // Have to babysit again
                    // Place the tile in the array
                    zoneTiles[j, i] = newTile;
                }
            }
        }

        private void fillRandomValues()
        {
            for (int i = 0; i < zoneHeight; i++)
            {// Doing for each row : 
                for (int j = 0; j < zoneWidth; j++)
                {// Doing for each column : 
                    tileValues[j, i] = randomMaker.Next(0, 4);

                }
            }

        }
    }
}

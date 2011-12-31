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
    public class Tile : Microsoft.Xna.Framework.DrawableGameComponent
    {

        // Services
        private SpriteBatch spriteBatch;

        private Texture2D backgroundTexture;
        private Zone parentZone;
        private Vector2 location;

        private Rectangle tileBounds;

        public Tile(Game game, Zone ParentZone, Vector2 tileLocation)
            : base(game)
        {
            // TODO: Construct any child components here
            parentZone = ParentZone;
            location = tileLocation;

        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));

            base.Initialize();

        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            backgroundTexture = theContentManager.Load<Texture2D>(theAssetName);
            tileBounds = new Rectangle((int)location.X,(int)location.Y,
                backgroundTexture.Width,backgroundTexture.Height);

        }

        public void Draw(GameTime gameTime, Rectangle sourceRectangle, Vector2 drawPosition)
        {
            //spriteBatch.Draw(backgroundTexture,tileBounds,Color.White);
            spriteBatch.Draw(backgroundTexture, drawPosition, sourceRectangle, Color.White);
            base.Draw(gameTime);

        }

    }
}

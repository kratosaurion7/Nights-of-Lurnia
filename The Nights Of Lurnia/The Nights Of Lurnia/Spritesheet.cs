using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace The_Nights_Of_Lurnia
{
    class Spritesheet
    {
        public Dictionary<int, Rectangle> SpriteSheetIndexes { get; private set; }

        public Spritesheet()
        {
            //AddStartingValues();
        }

        private void AddStartingValues()
        {
            Rectangle grass = new Rectangle(0, 0, 32, 32);
            Rectangle blackStone = new Rectangle(32, 0, 32, 32);
            Rectangle wood = new Rectangle(64,0,32,32);
            Rectangle ice = new Rectangle(96,0,32,32);
            Rectangle unavailable = new Rectangle(128,0,32,32);

            SpriteSheetIndexes.Add(0,grass);
            SpriteSheetIndexes.Add(1,blackStone);
            SpriteSheetIndexes.Add(2,wood);
            SpriteSheetIndexes.Add(3,ice);
            SpriteSheetIndexes.Add(4,unavailable);

        }

    }
}

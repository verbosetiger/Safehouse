using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Safehouse
{
    public class Zombie : Sprite
    {
        private int hitDamage;

        public Zombie()
        {

        }

        public override void Load(Texture2D texture)
        {
            this.texture = texture;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}

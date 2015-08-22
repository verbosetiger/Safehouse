using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Safehouse
{
    public abstract class Sprite
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 scale;
        protected int width;
        protected int height;
        protected int health;
        protected bool ignoreDamage;


        public virtual void Load(Texture2D texture)
        {
            this.texture = texture;
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);

        public int GetHeight()
        {
            return height;
        }

        public int GetWidth()
        {
            return width;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }
    }
}

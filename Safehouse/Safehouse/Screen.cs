using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Safehouse
{
    /*  
     * IS THIS CLASS ACTUALLY NEEDED?
     * 
     * */
    public class Screen
    {
        Level level;

        public Screen(Level level)
        {
            this.level = level;
        }

        public virtual void Initiailize()
        {
            level.Initialize();
        }

        public void Load(ContentManager content)
        {
            level.Load(content);
        }

        public virtual void Update(GameTime gameTime)
        {
            level.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            level.Draw(spritebatch);
        }
    }
}

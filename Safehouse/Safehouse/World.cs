using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Safehouse
{
    public class World
    {
        private List<Actor> actors;

        public World()
        {
            actors = new List<Actor>();
        }

        public void AddActor(Actor actor)
        {
            actors.Add(actor);
        }

        public void Update(GameTime gametime, GameTime levelTime)
        {
            foreach (Actor actor in actors)
            {
                actor.Update(gametime, this);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Actor actor in actors)
            {
                actor.Draw(spriteBatch);
            }
        }
    }
}

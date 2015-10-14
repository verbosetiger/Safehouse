using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Safehouse
{
    public enum LevelState
    {
        PREGAME,
        RUNNING,
        PAUSED,
        POSTGAME,
    }

    public class Level
    {
        protected GameTime elapsedLevelTime;
        protected LevelState levelState;
        protected World world;

        public Level()
        {

        }

        public void Initialize()
        {
            elapsedLevelTime = new GameTime();
            levelState = LevelState.PREGAME;
            world = new World();
        }

        public void Load(ContentManager content)
        {
            
        }

        public void Update(GameTime gameTime)
        {
            switch(levelState)
            { 
                case LevelState.PREGAME:
                    {

                        break;
                    }
                case LevelState.RUNNING:
                    {
                        elapsedLevelTime.ElapsedGameTime += gameTime.ElapsedGameTime;
                        world.Update(gameTime, elapsedLevelTime);
                        break;
                    }
                case LevelState.PAUSED:
                    {
                        break;
                    }
                case LevelState.POSTGAME:
                    {
                        break;
                    }
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            world.Draw(spritebatch);
        }
    }
}

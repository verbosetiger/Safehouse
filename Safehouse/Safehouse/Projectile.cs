using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Safehouse
{
    public class Projectile : Sprite
    {
        private int speed;
        private Vector2 direction;

        //the player index of the player that shot this projectile
        //allows for the player who shot this projectile to be determined
        PlayerIndex playerIndex;

        public Projectile(Vector2 position, int speed, Vector2 direction, 
            PlayerIndex playerIndex)
        {
            ignoreDamage = true;
            this.position = position;
            scale = new Vector2(2, 2);
            health = 1;
            this.speed = speed;
            this.direction = direction;
            this.playerIndex = playerIndex;
        }

        public override void Load(Texture2D texture)
        {
            this.texture = texture;
            this.width = texture.Width;
            this.height = texture.Height;
        }

        public override void Update(GameTime gameTime)
        {
            position += (direction * speed);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public PlayerIndex GetPlayerIndex(PlayerIndex playerIndex)
        {
            return playerIndex;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Safehouse
{
    public class Player : Sprite, IObservable<Projectile>
    {
        private float shotDamage;
        private float projectileSpeed;
        private const float shotCooldown = 800;
        private float timeSinceShot;
        private int movementSpeed;

        private PlayerIndex playerIndex;

        private float deadzoneX = 0.0f;
        private float deadzoneY = 0.0f;

        private Vector2 movementVector;
        private Vector2 aimVector;

        private float aimLength;
        private List<IObserver<Projectile>> observers;

        public Player()
        {
            ignoreDamage = false;
            health = 100;
            playerIndex = PlayerIndex.One;
            movementSpeed = 8;
            movementVector = new Vector2(0, 0);
            projectileSpeed = 3.0f;
            aimVector = new Vector2(0, 0);
            shotDamage = 1;
            aimLength = 0.0f;
            timeSinceShot = 0.0f;
            observers = new List<IObserver<Projectile>>();
            scale = new Vector2(2.5f, 2.5f);
        }

        public override void Load(Texture2D texture)
        {
            base.Load(texture);
        }

        public override void Update(GameTime gametime)
        {
            GamePadState padCurrentState = GamePad.GetState(playerIndex);

            //gets the current state of the movemement thumbstick
            if (padCurrentState.ThumbSticks.Left.X > deadzoneX || padCurrentState.ThumbSticks.Left.X < deadzoneX)
            {
                movementVector.X = movementSpeed * padCurrentState.ThumbSticks.Left.X;
            }
            else
            {
                movementVector.X = 0.0f;
            }

            if (padCurrentState.ThumbSticks.Left.Y > deadzoneY || padCurrentState.ThumbSticks.Left.Y < -deadzoneY)
            {
                movementVector.Y = movementSpeed * padCurrentState.ThumbSticks.Left.Y;
            }
            else
            {
                movementVector.Y = 0.0f;
            }

            movementVector.Y = -movementVector.Y;
            position += movementVector;

            //Updates the time since the last shot
            timeSinceShot += gametime.ElapsedGameTime.Milliseconds;

            //gets the position of the aim thumbstick
            aimVector = padCurrentState.ThumbSticks.Right;

            aimLength = aimVector.Length();

            if (aimVector.Length() > 0.8f && padCurrentState.Triggers.Right > 0.9f)
            {
                if (timeSinceShot > shotCooldown)
                {
                    timeSinceShot = 0.0f;
                    aimVector.Y = -aimVector.Y;

                    Projectile projectile = new Projectile(this.position, projectileSpeed, aimVector, playerIndex);

                    for (int i = 0; i < observers.Count; i++)
                    {
                        observers[i].Notify(projectile);
                    }
                }
            }
            
        }

        public void Subscribe(IObserver<Projectile> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void DetatchObserver(IObserver<Projectile> observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.position, null, null, null, 0f, scale, Color.White, SpriteEffects.None, 0f);
        }

        public void SetPlayerIndex(PlayerIndex playerIndex)
        {
            this.playerIndex = playerIndex;
        }

        public PlayerIndex GetPlayerIndex()
        {
            return playerIndex;
        }

        public float GetAimLength()
        {
            return aimLength;
        }
    }
}

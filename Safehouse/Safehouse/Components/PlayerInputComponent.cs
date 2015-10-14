using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Safehouse.Commands;

namespace Safehouse
{
    public class PlayerInputComponent : InputComponent
    {
        private PlayerIndex playerIndex; 

        public PlayerInputComponent(PlayerIndex playerIndex)
        {
            this.playerIndex = playerIndex;
        }

        public void HandleInput(GameTime gameTime, World world, 
            Actor currentActor)
        {
            Vector2 leftThumbstick = GamePad.GetState(playerIndex).ThumbSticks.Left;
            Vector2 rightThumbstick = GamePad.GetState(playerIndex).ThumbSticks.Right;

            if (leftThumbstick.X != 0 || leftThumbstick.Y != 0)
            {
                currentActor.ExCommand(new MoveCommand(leftThumbstick, currentActor.GetSpeed(), currentActor.GetPosition()));
            }

            if (rightThumbstick.X != 0 || rightThumbstick.Y != 0)
            {
                
            }
            

        }
    }
}

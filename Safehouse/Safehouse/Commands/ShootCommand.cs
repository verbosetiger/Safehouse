using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Safehouse.Commands
{
    class ShootCommand : ICommand
    {
        private Vector2 shotDirection;

        public ShootCommand(Vector2 direction)
        {
            this.shotDirection = direction;
        }

        /*
         * 
         * */
        public void Execute(Actor actor)
        {

        }

        /*
         * Shoot command must cause bullet to despawn
         * */
        public ICommand Undo()
        {
            return new ShootCommand(new Vector2(0, 0));
        }
    }
}

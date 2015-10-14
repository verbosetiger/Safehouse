using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Safehouse.Commands
{
    public class MoveCommand : ICommand
    {
        private Vector2 previousPosition;
        private Vector2 newPosition;

        private float speed;

        /*
         * Allows the object to move at a speed in a direction
         * */
        public MoveCommand(Vector2 direction, float speed, Vector2 currentPos)
        {
            previousPosition = new Vector2();
            newPosition = new Vector2();

            previousPosition = currentPos;
            newPosition = currentPos + (direction * speed);
        }

        /*
         * Moves the actor to an aboslute position
         * */
        public MoveCommand(Vector2 position)
        {
            previousPosition = new Vector2(0, 0);
            newPosition = new Vector2();
        }

        public void Execute(Actor currentActor)
        {
            currentActor.SetPosition(newPosition);
        }

        public ICommand Undo(Actor actor)
        {
            return new MoveCommand(previousPosition);
        }
    }
}

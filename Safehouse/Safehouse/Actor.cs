using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Safehouse
{
    public class Actor 
    {
        //Actor Components
        private InputComponent inputComponent;
        private AIComponent aiComponent;
        private CollisionComponent collisonComponent;
        private PhysicsComponent physicsComponent;
        private SpawnComponent spawnComponent;
        private GraphicsComponent graphicsComponent;

        //Actor shared state
        private Vector2 position;
        private Vector2 size;
        private Vector2 orientation;
        private float speed;

        //Actor command stream and command history
        Queue<ICommand> commandStream;
        List<ICommand> commandHistory;

        public Actor(Vector2 position, Vector2 size,
            Vector2 orientation, InputComponent input = null, 
            AIComponent ai = null, CollisionComponent collision = null,
            PhysicsComponent physics = null, SpawnComponent spawn = null, 
            GraphicsComponent graphics = null)
        {
            inputComponent = input;
            aiComponent = ai;
            collisonComponent = collision;
            physicsComponent = physics;
            spawnComponent = spawn;
            graphicsComponent = graphics;

            this.position = position;
            this.size = size;
            this.orientation = orientation;

            commandStream = new Queue<ICommand>();
            commandHistory = new List<ICommand>();
        }

        public void ExCommand(ICommand command)
        {
            command.Execute(this);
        }

        public void Update(GameTime gameTime, World world)
        {
            if (inputComponent != null)
            {
                
            }
            if (aiComponent != null)
            {

            }
            if (collisonComponent != null)
            {

            }
            if (physicsComponent != null)
            {

            }
            if (spawnComponent != null)
            {

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (graphicsComponent != null)
            {

            }
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public Vector2 GetPosition()
        {
            return this.position;
        }

        public void SetOrientation(Vector2 orientation)
        {
            this.orientation = orientation;
        }

        public Vector2 GetOrientation()
        {
            return orientation;
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        public float GetSpeed()
        {
            return speed;
        }
    }
}

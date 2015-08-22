using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Safehouse
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        TextureManager textureManager;
        Player player;
        Zombie enemy;

        //number of gamepads connected
        int padsConnected = 0;
        SpriteFont font;

        string stickLeft = "Left Stick Position: ";
        string stickRight = "Right Stick Position: ";

        enum GameState
        {
            NoController = 0,
            Playing = 1,
            ControllerDisconected = 2,
            GameOver = 3,
        }

        //the state of the game
        int gameState = 1;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //Gets the number of controllers that are connected 
            for (int i = 0; i < 4; i++)
            {
                bool test = false;

                switch (i)
                {
                    case 0:
                        {
                            test = GamePad.GetCapabilities(PlayerIndex.One).IsConnected;
                            break;
                        }
                    case 1:
                        {
                            test = GamePad.GetCapabilities(PlayerIndex.Two).IsConnected;
                            break;
                        }
                    case 2:
                        {
                            test = GamePad.GetCapabilities(PlayerIndex.Three).IsConnected;
                            break;
                        }
                    case 3:
                        {
                            test = GamePad.GetCapabilities(PlayerIndex.Four).IsConnected;
                            break;
                        }
                }

                if (test == true)
                {
                    padsConnected++;
                }
            }

            if (padsConnected == 0)
            {
                gameState = (int)GameState.NoController;
            }

            player = new Player();
            player.SetPlayerIndex(PlayerIndex.One);
            player.SetPosition(new Vector2(400, 200));

            enemy = new Zombie();

            textureManager = new TextureManager();
            textureManager.Initialize(Content);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            textureManager.Load("Player", "Player");
            textureManager.Load("Zombie", "Zombie");
            textureManager.Load("Bullet", "Projectile");

            player.Load(textureManager.GetTexture("Player"));
            enemy.Load(textureManager.GetTexture("Zombie"));

            font = Content.Load<SpriteFont>("Kootenay");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            switch (gameState)
            {
                case (int)GameState.NoController:
                    {
                        break;
                    }
                case (int)GameState.Playing:
                    {
                        //Main game logic
                        player.Update(gameTime);

                        break;
                    }
                case (int)GameState.GameOver:
                    {
                        break;
                    }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            player.Draw(spriteBatch);

            spriteBatch.DrawString(font, 
                "Vector Length: " + player.GetAimLength(), new Vector2(20, 20), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

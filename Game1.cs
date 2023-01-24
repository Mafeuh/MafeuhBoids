using MafeuhBoids.Boids;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MafeuhBoids
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static Texture2D Texture1Pixel;
        public static SpriteFont Font;

        private String command;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //Window.IsBorderless = true;
        }

        protected override void Initialize()
        {
            _graphics.ApplyChanges();

            //Window.TextInput += ProcessTextInput;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Ship.ShipTexture = Content.Load<Texture2D>("Textures/ship");
            Texture1Pixel = Content.Load<Texture2D>("Textures/1px");
            Font = Content.Load<SpriteFont>("Fonts/Font");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Simulation.CurrentSimulation.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Simulation.CurrentSimulation.BackgroundColor);

            _spriteBatch.Begin();


            Simulation.CurrentSimulation.Draw(_spriteBatch);

            if (Simulation.CurrentSimulation.PromptShowed)
            {
                _spriteBatch.Draw(
                    Texture1Pixel,
                    new Rectangle(
                        40,
                        _graphics.PreferredBackBufferWidth - 80,
                        _graphics.PreferredBackBufferHeight - 80,
                        40
                    ),
                    null,
                    Color.White,
                    0f,
                    new Vector2(0),
                    SpriteEffects.None, 
                    0.01f
                );
                _spriteBatch.DrawString(
                    Font,
                    command,
                    new Vector2(45, _graphics.PreferredBackBufferHeight - 75),
                    Color.Black,
                    0f,
                    new Vector2(0),
                    1f,
                    SpriteEffects.None,
                    0.005f);
            }

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }






        private void ProcessTextInput(object sender, TextInputEventArgs e)
        {
            if (e.Key != Keys.Space &&
                e.Key != Keys.Up &&
                e.Key != Keys.Down &&
                e.Key != Keys.Left &&
                e.Key != Keys.Right)
            {
                Simulation.CurrentSimulation.OpenPrompt();
            }
            switch (e.Key)
            {
                default:
                    if (Char.IsLetterOrDigit(e.Character) || e.Key == Keys.Space)
                        command += e.Character;
                    break;
                case Keys.Enter:
                    new InputAnalyzer(command).Analyze();
                    Simulation.CurrentSimulation.ClosePrompt();
                    break;
                case Keys.Back:
                    if (command.Length > 0)
                    {
                        command = command.Remove(command.Length - 1);
                    }
                    break;
                case Keys.Escape:
                    Exit();
                    break;
            }
        }
    }
}

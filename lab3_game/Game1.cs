using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace lab3_game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D cloudTexture;
        Texture2D myTexture;
        Vector2[] scaleClound;
        Vector2[] cloudPos;
        Vector2 spritePosition = Vector2.Zero;
        int frame = 3;
        Rectangle flower = new Rectangle(192, 192, 64, 64);
        Rectangle Tree = new Rectangle(0, 64 * 3, 128, 128);
        Rectangle BigTree = new Rectangle(64 * 4, 64 * 2, 256, 265);
        Rectangle Bush = new Rectangle(18 * 3, 0, 64, 64);
        Rectangle Sign = new Rectangle(64 * 3, 0, 64, 64);
        int[] speed;
        
        Random r = new Random();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            myTexture = Content.Load<Texture2D>("NatureSprite");
            cloudTexture = Content.Load<Texture2D>("Cloud_sprite");
            // TODO: use this.Content to load your game content here

            speed = new int[4];
            cloudPos = new Vector2[4];
            scaleClound = new Vector2[4];
            for(int i=0;i<4;i++)
            {
                scaleClound[i].X = r.Next(1, 3);
                scaleClound[i].Y = scaleClound[i].X;
                cloudPos[i].Y = r.Next(0, _graphics.GraphicsDevice.Viewport.Height - cloudTexture.Height);
                speed[i] = r.Next(3, 7);
            }
            
        }

        protected override void UnloadContent()
        {
            
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            for(int i=0;i<4;i++)
            {
                cloudPos[i].X = cloudPos[i].X + speed[i];
                if (cloudPos[i].X > _graphics.GraphicsDevice.Viewport.Width)
                {
                    cloudPos[i].X = 0;
                    cloudPos[i].Y = r.Next(0, _graphics.GraphicsDevice.Viewport.Height - cloudTexture.Height);
                    scaleClound[i].X = r.Next(1, 3);
                    scaleClound[i].Y = scaleClound[i].X;
                }
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(85,133,50));
            _spriteBatch.Begin();
            _spriteBatch.Draw(myTexture, new Vector2(64, 160), Sign, Color.White);
            _spriteBatch.Draw(myTexture, new Vector2(64, 32), Bush, Color.White);
            _spriteBatch.Draw(myTexture, new Vector2(64, 88), Bush, Color.White);
            _spriteBatch.Draw(myTexture, new Vector2(64, 64*5), Bush, Color.White);
            _spriteBatch.Draw(myTexture, new Vector2(64, 64*4), Bush, Color.White);
            _spriteBatch.Draw(myTexture, new Vector2(300,332), Tree, Color.White);
            _spriteBatch.Draw(myTexture, new Vector2(300, 32), Tree, Color.White);
            _spriteBatch.Draw(myTexture, new Vector2(300, 64 * 3), flower, Color.White);
            _spriteBatch.Draw(myTexture, new Vector2(300, 64 * 4), flower, Color.White);
            _spriteBatch.Draw(myTexture, new Vector2(364, 64 * 3), flower, Color.White);
            _spriteBatch.Draw(myTexture, new Vector2(364, 64 * 4), flower, Color.White);
            _spriteBatch.Draw(myTexture, new Vector2(64*7, 64*2), BigTree, Color.White);

            for (int i = 0; i < 4; i++)
            {
                _spriteBatch.Draw(cloudTexture, cloudPos[i], null, Color.White, 0, Vector2.Zero, scaleClound[i], 0, 0);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

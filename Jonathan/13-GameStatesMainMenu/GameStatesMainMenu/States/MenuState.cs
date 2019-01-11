﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStatesMainMenu.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameStatesMainMenu.States
{
    public class MenuState : State
    {
        private List<Component> _components;


        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) 
            : base(game, graphicsDevice, content)
        {
            Texture2D buttonTexture = _content.Load<Texture2D>("Controls/Button");
            SpriteFont buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            Button newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "New Game",
            };
            newGameButton.Click += NewGameButton_Click;

            Button loadGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Load Game",
            };
            loadGameButton.Click += LoadGameButton_Click;

            Button quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 300),
                Text = "Quit",
            };
            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>
            {
                newGameButton,
                loadGameButton,
                quitGameButton,
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (Component component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load Game");
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // remove sprites if they're bit beeded
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Component component in _components)
            {
                component.Update(gameTime);
            }
        }
    }
}

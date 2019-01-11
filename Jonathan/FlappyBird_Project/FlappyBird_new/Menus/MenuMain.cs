using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird_new
{
    public class MenuMain : MenuBase
    {
        // FIELDS
        private Sprite logo;
        private Button startButton;
        private Button quitButton;

        // CONSTRUCTOR
        public MenuMain()
            : base()
        {
            this.logo = new Sprite("logo", (Settings.SCREEN_WIDTH - 96) / 2, 75);
            this.startButton = new Button((Settings.SCREEN_WIDTH - 40) / 2, 140, 5);
            this.quitButton = new Button((Settings.SCREEN_WIDTH - 40) / 2, 140 + 14 + 5, 2);
        }

        // METHODS

        // UPDATE & DRAW
        public override void Update(GameTime gameTime, Input input, Game1 game)
        {
            base.Update(gameTime, input, game);

            this.startButton.Update(gameTime, input);
            this.quitButton.Update(gameTime, input);

            if (this.startButton.IsPressed())
                game.ChangeMenu(Menu.GAME);
            if (this.quitButton.IsPressed())
                game.Exit();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            this.logo.Draw(spriteBatch);
            this.startButton.Draw(spriteBatch);
            this.quitButton.Draw(spriteBatch);
        }
    }
}

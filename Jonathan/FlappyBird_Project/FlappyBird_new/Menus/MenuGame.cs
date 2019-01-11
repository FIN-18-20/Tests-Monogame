using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird_new
{
    public class MenuGame : MenuBase
    {
        // CONST
        private const int HOLE_HEIGHT = 50;

        // FIELDS
        private Sprite getReady;
        private List<Pipe> pipes;
        private Bird player;
        private bool start;
        private int timer;
        private Random random;

        private int score;
        private int highscore;
        private bool newHighscore;
        private Sprite newScore;
        private int baseScoreX;
        private int baseScoreY;

        private bool gameover;
        private bool setRotation;
        private Sprite gameOver;
        private Sprite scoreBox;
        private AnimatedSprite medal;
        private Button retryButton;
        private Button menuButton;

        // CONSTRUCTOR
        public MenuGame()
            : base()
        {
            this.getReady = new Sprite("getready", (Settings.SCREEN_WIDTH - 87) / 2, 75);
            this.pipes = new List<Pipe>();
            this.player = new Bird(31, 100);
            this.start = false;
            this.timer = 0;
            this.random = new Random();

            this.score = 0;
            this.highscore = 0;
            this.newHighscore = false;

            this.gameover = false;
            this.setRotation = false;
            this.gameOver = new Sprite("gameover", (Settings.SCREEN_WIDTH - 94) / 2, 75);
            int scoreBoxX = (Settings.SCREEN_WIDTH - 113) / 2;
            int scoreBoxY = 109;
            this.scoreBox = new Sprite("score_box", scoreBoxX, scoreBoxY);
            this.medal = new AnimatedSprite("medals", 22, 22, 0, SheetOrientation.HORIZONTAL, scoreBoxX + 13, scoreBoxY + 21);
            this.newScore = new Sprite("new", scoreBoxX + 85 - 16 - 2, scoreBoxY + 29);

            this.baseScoreX = scoreBoxX + 95;
            this.baseScoreY = scoreBoxY + 17;

            this.retryButton = new Button(scoreBoxX, scoreBoxY + 58 + 15, 1);
            this.menuButton = new Button(scoreBoxX + 113 - 40, scoreBoxY + 58 + 15, 0);
        }

        // METHODS
        public void GameOver(GameTime gameTime)
        {
            Resources.Sounds["pipe_hit2"].Play();
            this.player.SetMaxRotation();
            this.setRotation = true;
            this.player.Update(gameTime, null);

            int medalIndex = -1;

            if (score >= 40)
                medalIndex = 0;
            else if (score >= 30)
                medalIndex = 3;
            else if (score >= 20)
                medalIndex = 2;
            else if (score >= 10)
                medalIndex = 1;

            this.medal.SetIndex(medalIndex);

            this.highscore = HighScore.GetHighScore();

            if (this.score > this.highscore)
            {
                this.newHighscore = true;
                this.highscore = this.score;
                HighScore.SetHighScore(this.score);
            }
        }

        // UPDATE & DRAW
        public override void Update(GameTime gameTime, Input input, Game1 game)
        {
            base.Update(gameTime, input, game);
            if (!gameover)
            {
                this.ground.Update(gameTime, input);
                foreach (Pipe pipe in new List<Pipe>(this.pipes))
                {
                    pipe.Update(gameTime, input);
                    if (pipe.ToDelete())
                        this.pipes.Remove(pipe);
                    if (this.player.CollisionWith(pipe))
                    {
                        //this.gameover = true;
                        Resources.Sounds["pipe_hit"].Play();
                        break;
                    }
                    if (pipe.GetPipeType() == PipeType.TOP && !pipe.IsPassed() && this.player.X > pipe.Right)
                    {
                        pipe.SetPassed();
                        this.score += 1;
                        Resources.Sounds["pipe_pass"].Play();
                    }
                }
                if (this.player.CollisionWith(this.ground))
                {
                    this.gameover = true;
                    this.GameOver(gameTime);
                }
                else
                    this.player.Update(gameTime, input);

                this.timer += gameTime.ElapsedGameTime.Milliseconds;

                if (!this.start)
                {
                    if (this.timer >= 3000)
                    {
                        this.start = true;
                        this.timer = 2000;
                        this.player.ActiveGravity();
                    }
                }
                else // CREATE PIPES
                {
                    if (this.timer >= 1)
                    {
                        this.timer = 0;

                        int topPipeY = this.random.Next(-95, 1);
                        int botPipeY = topPipeY + 135 + HOLE_HEIGHT;

                        this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, topPipeY, PipeType.TOP));
                        this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, botPipeY, PipeType.BOT));
                    }
                }
            }
            else if (!this.setRotation)
            {
                if (!this.player.CollisionWith(this.ground))
                    this.player.Update(gameTime, null);
                else
                {
                    this.GameOver(gameTime);
                }
            }
            else
            {
                this.retryButton.Update(gameTime, input);
                if (this.retryButton.IsPressed())
                    game.ChangeMenu(Menu.GAME);
                this.menuButton.Update(gameTime, input);
                if (this.menuButton.IsPressed())
                    game.ChangeMenu(Menu.MAIN);
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.background.Draw(spriteBatch);
            foreach (Pipe pipe in this.pipes)
                pipe.Draw(spriteBatch);
            if (!this.start && !this.setRotation)
                this.getReady.Draw(spriteBatch);
            else if (!this.setRotation)
            {
                int nb = 1;
                if (score > 0)
                    nb = ((int)Math.Floor(Math.Log10(score)) + 1);

                Number.Draw(spriteBatch, NumberSize.LARGE, (Settings.SCREEN_WIDTH - (nb * Number.LARGE_NUMBER_WIDTH)) / 2, 75, score);
            }
            this.ground.Draw(spriteBatch);
            this.player.Draw(spriteBatch);
            if (this.setRotation)
            {
                this.gameOver.Draw(spriteBatch);
                this.scoreBox.Draw(spriteBatch);
                this.medal.Draw(spriteBatch);
                this.retryButton.Draw(spriteBatch);
                this.menuButton.Draw(spriteBatch);

                int nb = 0;
                if (score > 0)
                    nb = (int)Math.Floor(Math.Log10(score));

                int nb2 = 0;
                if (highscore > 0)
                    nb2 = (int)Math.Floor(Math.Log10(highscore));

                Number.Draw(spriteBatch, NumberSize.LARGE, this.baseScoreX - (nb * Number.LARGE_NUMBER_WIDTH), this.baseScoreY, score);
                Number.Draw(spriteBatch, NumberSize.LARGE, this.baseScoreX - (nb2 * Number.LARGE_NUMBER_WIDTH), this.baseScoreY + 21, highscore);

                if (this.newHighscore)
                    this.newScore.Draw(spriteBatch);
            }
        }
    }
}

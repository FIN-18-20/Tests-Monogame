﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace MarioBros
{
    public class Level
    {
        Game1 game;
        public Mario mario;
        public Fireball fireball;
        public ThrowingStar throwingStar;
        public List<Fireball> levelFireballs = new List<Fireball>();
        public List<Fireball> deadFireballs = new List<Fireball>();
        public List<ThrowingStar> levelThrowingStars = new List<ThrowingStar>();
        public List<ThrowingStar> deadThrowingStars = new List<ThrowingStar>();
        public LevelBuilder builder;
        public List<Enemy> levelEnemies = new List<Enemy>();
        public List<Pipe> levelPipes = new List<Pipe>();
        public List<Block> levelBlocks = new List<Block>();
        public List<Spike> levelSpikes = new List<Spike>();
        public List<Trampoline> levelTrampolines = new List<Trampoline>();
        public List<ICollectable> levelItems = new List<ICollectable>();
        public List<KeyValuePair<IAnimatedSprite, Vector2>> levelBackgroundObjects = new List<KeyValuePair<IAnimatedSprite, Vector2>>();
        public CollisionDetector collision;
        bool isVictory = false;
        public bool isUnderground = false;
        public Vector2 exitPosition { get; set; }
        public IAnimatedSprite exitPole { get; set; }
        public Vector2 checkpoint;

        public Level(string fileName)
        {
            this.game = Game1.GetInstance();
            builder = new LevelBuilder(this);
            mario = builder.Build(fileName);
            game.gameCamera.LookAt(mario.position);
            collision = new CollisionDetector(mario, game);
            exitPole = new GateSprite(Game1.gameContent.Load<Texture2D>("Items/gateFramedFinal"), 2, 23);
            game.gameHUD.Time = ValueHolder.startingTime;
        }

        public void Update(GameTime gameTime)
        {
            game.background.CurrentSprite.Update(gameTime);
            foreach (KeyValuePair<IAnimatedSprite, Vector2> backgroundObject in levelBackgroundObjects)
            {
                backgroundObject.Key.Update(gameTime);
            }
            foreach (Trampoline trampolineDrawer in levelTrampolines)
            {
                if (game.gameCamera.InCameraView(trampolineDrawer.GetBoundingBox()))
                {
                    trampolineDrawer.Update(gameTime);
                }
            }
            foreach (Enemy enemy in levelEnemies)
            {
                if (game.gameCamera.InCameraView(enemy.GetBoundingBox()))
                {
                    enemy.Update(gameTime);
                }
            }
            foreach (ICollectable item in levelItems)
            {
                if (game.gameCamera.InCameraView(item.GetBoundingBox()))
                {
                    item.Update(gameTime);
                }
            }
            foreach (Block blockUpdater in levelBlocks)
            {
                if (game.gameCamera.InCameraView(blockUpdater.GetBoundingBox()))
                {
                    blockUpdater.Update(gameTime);
                }
            }
            foreach (Pipe pipeUpdater in levelPipes)
            {
                if (game.gameCamera.InCameraView(pipeUpdater.GetBoundingBox()))
                {
                    pipeUpdater.Update(gameTime);
                }
            }
            if (game.gameCamera.InCameraView(exitPole.GetBoundingBox(exitPosition)))
            {
                exitPole.Update(gameTime);
            }
            foreach (Spike spike in levelSpikes)
            {
                if (game.gameCamera.InCameraView(spike.GetBoundingBox()))
                {
                    spike.Update(gameTime);
                }
            }
            foreach (Fireball fireball in levelFireballs)
            {
                fireball.Update(gameTime);
                if (fireball.fireballLifespan == 0)
                {
                    deadFireballs.Add(fireball);
                    if (mario.fireballCount > 0)
                    {
                        mario.fireballCount--;
                    }
                }
            }
            foreach (Fireball fireball in deadFireballs)
            {
                levelFireballs.Remove(fireball);
            }
            foreach (ThrowingStar throwingStar in levelThrowingStars)
            {
                throwingStar.Update(gameTime);
                if (throwingStar.throwingStarLifespan == 0)
                {
                    deadThrowingStars.Add(throwingStar);
                    if (mario.throwingStarCount > 0)
                    {
                        mario.throwingStarCount--;
                    }
                }
            }
            foreach (ThrowingStar throwingStar in deadThrowingStars)
            {
                levelThrowingStars.Remove(throwingStar);
            }

            collision.Detect(mario, levelFireballs, levelThrowingStars, levelEnemies, levelBlocks, levelItems, levelPipes, levelSpikes, levelTrampolines);

            mario.Update(gameTime);
            if (mario.position.X < 0)
            {
                mario.position.X = 0;
            }
            if (mario.position.X > exitPosition.X && !isVictory && !isUnderground)
            {
                game.gameState = new VictoryGameState();
                exitPole = new GateSprite(Game1.gameContent.Load<Texture2D>("Items/gateBroken"), 1, 1);
                isVictory = true;
            }
            game.gameCamera.LookAt(mario.position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<IAnimatedSprite, Vector2> backgroundObject in levelBackgroundObjects)
            {
                backgroundObject.Key.Draw(spriteBatch, backgroundObject.Value, Color.White);
            }
            foreach (ICollectable item in levelItems)
            {
                if (game.gameCamera.InCameraView(item.GetBoundingBox()))
                {
                    item.Draw(spriteBatch);
                }
            }
            foreach (Enemy enemy in levelEnemies)
            {
                if (game.gameCamera.InCameraView(enemy.GetBoundingBox()))
                {
                    enemy.Draw(spriteBatch);
                }
            }
            foreach (Fireball fireball in levelFireballs)
            {
                if (game.gameCamera.InCameraView(fireball.GetBoundingBox()))
                {
                    fireball.Draw(spriteBatch);
                }
            }
            foreach (ThrowingStar throwingStar in levelThrowingStars)
            {
                if (game.gameCamera.InCameraView(throwingStar.GetBoundingBox()))
                {
                    throwingStar.Draw(spriteBatch);
                }
            }
            foreach (Block blockDrawer in levelBlocks)
            {
                if (game.gameCamera.InCameraView(blockDrawer.GetBoundingBox()))
                {
                    blockDrawer.Draw(spriteBatch, blockDrawer.position);
                }
            }
            foreach (Spike spikeDrawer in levelSpikes)
            {
                if (game.gameCamera.InCameraView(spikeDrawer.GetBoundingBox()))
                {
                    spikeDrawer.Draw(spriteBatch);
                }
            }
            foreach (Trampoline trampolineDrawer in levelTrampolines)
            {
                if (game.gameCamera.InCameraView(trampolineDrawer.GetBoundingBox()))
                {
                    trampolineDrawer.Draw(spriteBatch);
                }
            }
            if (!game.isTitle)
            {
                mario.Draw(spriteBatch);
            }
            if (game.gameCamera.InCameraView(exitPole.GetBoundingBox(exitPosition)))
            {
                exitPole.Draw(spriteBatch, exitPosition, Color.White);
            }
            foreach (Pipe pipeDrawer in levelPipes)
            {
                if (game.gameCamera.InCameraView(pipeDrawer.GetBoundingBox()))
                {
                    pipeDrawer.Draw(spriteBatch, pipeDrawer.position);
                }
            }
        }
    }
}
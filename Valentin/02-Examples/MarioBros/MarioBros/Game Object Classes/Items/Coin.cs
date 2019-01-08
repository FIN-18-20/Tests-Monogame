﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public class Coin : ICollectable
    {
        public IAnimatedSprite sprite { get; set; }
        public bool isSpawning { get; set; }
        public Vector2 position { get; set; }
        public Vector2 velocity { get; set; }
        public ICollectablePhysicsState physState { get; set; }
        ISpriteFactory factory = new SpriteFactory();
        int spawnTimer = 5;
        Vector2 spawnAdjust = new Vector2(0, 20);

        public Coin(Vector2 location)
        {
            this.sprite = sprite;
            position = location;
            isSpawning = false;
            sprite = factory.build(SpriteFactory.sprites.coin);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isSpawning)
            {
                if (spawnTimer > 0)
                {
                    sprite.Draw(spriteBatch, position, Color.White);
                }
            }
            else
            {
                sprite.Draw(spriteBatch, position, Color.White);
            }
        }
        public void GoLeft()
        {
        }
        public void GoRight()
        {
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            if (isSpawning)
            {
                spawnTimer--;
            }
        }

        public Rectangle GetBoundingBox()
        {
            return sprite.GetBoundingBox(position);
        }

        public void Spawn()
        {
            Game1.GetInstance().level.levelItems.Add(this);
            SoundManager.coinCollect.Play();
            Game1.GetInstance().gameHUD.Coins++;
            position = position - spawnAdjust;
            isSpawning = true;
        }
    }
}
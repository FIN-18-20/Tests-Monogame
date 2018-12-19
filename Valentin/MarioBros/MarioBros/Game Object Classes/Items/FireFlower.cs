﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public class FireFlower : ICollectable
    {
        public IAnimatedSprite sprite { get; set; }
        public bool isSpawning { get; set; }
        private int spawnTimer = 0;
        public Vector2 position { get; set; }
        public Vector2 velocity { get; set; }
        public ICollectablePhysicsState physState { get; set; }
        ISpriteFactory factory = new SpriteFactory();

        public FireFlower(Vector2 location)
        {
            this.sprite = sprite;
            position = location;
            isSpawning = false;
            sprite = factory.build(SpriteFactory.sprites.fireFlower);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position, Color.White);
        }
        public void GoLeft()
        {
        }
        public void GoRight()
        {
        }
        public void Update(GameTime gameTime)
        {
            if (!isSpawning)
            {
                sprite.Update(gameTime);
            }
            else
            {
                position = new Vector2(position.X, position.Y - (float)ValueHolder.itemSpawnRate);
                spawnTimer--;
                if (spawnTimer == 0)
                {
                    isSpawning = false;
                }
            }
        }

        public Rectangle GetBoundingBox()
        {
            return sprite.GetBoundingBox(position);
        }

        public void Spawn()
        {
            isSpawning = true;
            Game1.GetInstance().level.levelItems.Add(this);
            spawnTimer = ValueHolder.itemSpawnTimer;
            SoundManager.itemSpawn.Play();
        }
    }
}
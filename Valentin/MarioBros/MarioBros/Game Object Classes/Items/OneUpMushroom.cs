﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public class OneUpMushroom : ICollectable
    {
        public IAnimatedSprite sprite { get; set; }
        public bool isSpawning { get; set; }
        private int spawnTimer = 0;
        private bool left = false;
        public Vector2 position { get; set; }
        public Vector2 velocity { get; set; }
        public ICollectablePhysicsState physState { get; set; }
        ISpriteFactory factory = new SpriteFactory();

        public OneUpMushroom(Vector2 location)
        {
            this.sprite = sprite;
            position = location;
            isSpawning = false;
            sprite = factory.build(SpriteFactory.sprites.oneUpMushroom);
            physState = new ItemGroundState(this);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position, Color.White);
        }
        public void GoLeft()
        {
            position = new Vector2(position.X - 1, position.Y);
            left = true;
        }
        public void GoRight()
        {
            position = new Vector2(position.X + 1, position.Y);
            left = false;
        }
        public void Update(GameTime gameTime)
        {
            if (!isSpawning)
            {
                position = new Vector2(position.X, position.Y + 1);
                sprite.Update(gameTime);
                physState.Update(this, gameTime);
                if (left)
                {
                    GoLeft();
                }
                else
                {
                    GoRight();
                }
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
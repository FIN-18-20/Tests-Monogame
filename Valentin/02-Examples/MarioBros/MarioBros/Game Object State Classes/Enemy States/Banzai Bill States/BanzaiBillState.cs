﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace MarioBros
{
    public class BanzaiBillState : IEnemyState
    {
        IAnimatedSprite sprite;
        ISpriteFactory factory;
        SoundEffectInstance launch;
        bool sfxPlayed = false;

        public BanzaiBillState()
        {
            factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.banzaiBill);
            launch = SoundManager.launch.CreateInstance();
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }
        public void TakeDamage(Enemy hurtEnemy)
        {
            if (!hurtEnemy.isDead)
            {
                sprite = factory.build(SpriteFactory.sprites.deadBanzaiBill);
                hurtEnemy.isDead = true;
            }
        }
        public void GoLeft(Enemy enemy)
        {
            enemy.position.X -= 3;
        }
        public void GoRight(Enemy enemy)
        {
            enemy.position.X += 2;
        }
        public void Update(Enemy enemy, GameTime gameTime)
        {
            //bill glides over everything but mario
            if (!enemy.isDead)
            {
                enemy.isMagic = true;
                enemy.GoLeft();
            }
            else
            {
                enemy.GoRight();
                enemy.position.Y += 2;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (!sfxPlayed)
            {
                launch.Play();
                sfxPlayed = true;
            }
            sprite.Draw(spriteBatch, location, Color.White);
        }
    }
}
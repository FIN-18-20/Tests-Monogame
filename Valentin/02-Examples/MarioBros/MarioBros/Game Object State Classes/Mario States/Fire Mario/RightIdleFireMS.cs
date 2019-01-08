﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public class RightIdleFireMS : IMarioState
    {
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }

        public RightIdleFireMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.rightIdleMarioFire);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            mario.TransitionState(mario.state, new RightIdleSmallMS(mario));
        }
        public void Up()
        {
            mario.state = new RightJumpingFireMS(mario);
        }
        public void Down()
        {
            mario.state = new RightCrouchingFireMS(mario);
        }
        public void GoLeft()
        {
            mario.state = new LeftIdleFireMS(mario);
        }
        public void GoRight()
        {
            mario.state = new RightMovingFireMS(mario);
        }
        public void Idle()
        {

        }
        public void Land()
        {

        }
        public void Fall()
        {
        }
        public void MakeBigMario()
        {
            mario.state = new RightIdleBigMS(mario);
        }
        public void MakeSmallMario()
        {
            mario.state = new RightIdleSmallMS(mario);
        }
        public void MakeFireMario()
        {
            // null
        }
        public void MakeFireballMario()
        {
            mario.state = new RightFireballFireMS(mario);
        }
        public void MakeNinjaMario()
        {

        }
        public void MakeDeadMario()
        {
            mario.state = new DeadMS(mario);
        }
        public void Flip() { }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Sprite.Draw(spriteBatch, location, color);
        }
    }
}
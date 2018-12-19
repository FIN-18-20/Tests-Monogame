﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public class EnemyGroundState : IEnemyPhysicsState
    {
        private Vector2 oldPos;
        private float positionDifference = .5f;

        public EnemyGroundState(Enemy item)
        {
            item.velocity = new Vector2(item.velocity.X, 0);
            oldPos = item.position;
        }
        public void Update(Enemy enemy, GameTime gameTime)
        {
            if ((enemy.position.Y - oldPos.Y) > positionDifference)
            {
                enemy.physState = new EnemyFallingState(enemy);
            }
            oldPos = enemy.position;
        }
    }
}
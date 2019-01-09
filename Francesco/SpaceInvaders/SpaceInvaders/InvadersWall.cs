using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpaceInvaders
{
    class InvadersWall
    {
        SpriteSheet _spriteSheet;
        Point _position;

        private const int WIDTH = 5;
        private const int HEIGHT = 5;
        private const int SPACE_BETWEEN = 60;

        private bool[,] _aliveInvaders;

        public InvadersWall(SpriteSheet spriteSheet, Point position)
        {
            _spriteSheet = spriteSheet;
            _position = position;

            _aliveInvaders = new bool[WIDTH, HEIGHT];
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    _aliveInvaders[i, j] = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < HEIGHT; i++)
            {
                for(int j = 0; j < WIDTH; j++)
                {
                    _spriteSheet.Draw(_spriteSheet.INVADER, new Vector2(_position.X + j * (_spriteSheet.INVADER.Width + SPACE_BETWEEN), 
                        _position.Y + i * (_spriteSheet.INVADER.Height + SPACE_BETWEEN)));
                }
            }
        }

        public bool IsInvaderAlive(int x, int y)
        {
            int j = (x - _position.X) / ((_spriteSheet.INVADER.Width + SPACE_BETWEEN));
            int i = (y - _position.Y) / ((_spriteSheet.INVADER.Height + SPACE_BETWEEN));
            return _aliveInvaders[i, j];
        }
    }
}

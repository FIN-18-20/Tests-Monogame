using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace XBlast2018
{
    public class PlayerTextures
    {
        Players _player;
        List<Texture2D> _textures;
        int _spriteIndex;
        Directions _previousDirection;

        ContentManager _content;

        public PlayerTextures(Players player, ContentManager contentManager)
        {
            _player = player;
            _textures = new List<Texture2D>();
            _content = contentManager;
            _previousDirection = Directions.S;

            int baseIndex = (int)_player * 12;
            int playerIndex = (int)_player + 1;

            int imageIndex;
            string imageName;

            for(int i = 0; i < 4; i++)
            {
                for (int sprite = 0; sprite < 3; sprite++)
                {
                    imageIndex = baseIndex + i * 3 + sprite;
                    imageName = imageIndex.ToString("000") + "_P" + playerIndex + "_" + (Directions)(i) + sprite;
                    _textures.Add(_content.Load<Texture2D>("images/player/" + imageName));
                }
            }
            imageIndex = baseIndex + 12;
            imageName = imageIndex.ToString("000") + "_P" + playerIndex + "_losing-life";
            _textures.Add(_content.Load<Texture2D>("images/player/" + imageName));

            imageIndex++;
            imageName = imageIndex.ToString("000") + "_P" + playerIndex + "_dying";
            _textures.Add(_content.Load<Texture2D>("images/player/" + imageName));
        }

        public Texture2D GetTexture(Directions direction, int spriteIndex = -1)
        {
            if (spriteIndex == -1)
                spriteIndex = _spriteIndex;

            if (spriteIndex < 0)
                spriteIndex = 0;
            if (spriteIndex > 30)
                spriteIndex = 30;
            
            int baseIndex = (int)_player * 12;
            int directionIndex = (int)direction * 3;

            _spriteIndex++;
            _spriteIndex %= 30;

            if(direction == Directions.Idle)
                return _textures[baseIndex + (int)_previousDirection* 3];
            else
            {
                _previousDirection = direction;
                return _textures[baseIndex + directionIndex + (2 - spriteIndex / 10)];
            }

        }
    }

    public enum Directions
    {
        N,
        E,
        S,
        W,
        Idle
    }

    public enum Players
    {
        PLAYER1,
        PLAYER2,
        PLAYER3,
        PLAYER4
    }
}

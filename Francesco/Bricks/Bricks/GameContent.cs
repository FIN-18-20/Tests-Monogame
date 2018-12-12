using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Bricks
{
    class GameContent
    {
        public Texture2D BrickImg { get; set; }
        public Texture2D PaddleImg { get; set; }
        public Texture2D BallImg { get; set; }
        public Texture2D PixelImg { get; set; }
        public SoundEffect StartSound { get; set; }
        public SoundEffect BrickSound { get; set; }
        public SoundEffect PaddleBounceSound { get; set; }
        public SoundEffect WallBounceSound { get; set; }
        public SoundEffect MissSound { get; set; }
        public SpriteFont LabelFont { get; set; }

        public GameContent(ContentManager content)
        {
            /*  Load images */
            BallImg = content.Load<Texture2D>("Ball");
            PixelImg = content.Load<Texture2D>("Pixel");
            PaddleImg = content.Load<Texture2D>("Paddle");
            BrickImg = content.Load<Texture2D>("Brick");

            /*  Load sounds */
            StartSound = content.Load<SoundEffect>("StartSound");
            BrickSound = content.Load<SoundEffect>("BrickSound");
            PaddleBounceSound = content.Load<SoundEffect>("PaddleBounceSound");
            WallBounceSound = content.Load<SoundEffect>("WallBounceSound");
            MissSound = content.Load<SoundEffect>("MissSound");

            /*  Load fonts  */
            LabelFont = content.Load<SpriteFont>("CenturyGothic20");
        }
    }
}

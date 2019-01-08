using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

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
        public List<Song> MusicList { get; set; }

        public GameContent(ContentManager content)
        {
            /*  Load images */
            BallImg = content.Load<Texture2D>("Images/ball");
            PixelImg = content.Load<Texture2D>("Images/pixel");
            PaddleImg = content.Load<Texture2D>("Images/Paddle");
            BrickImg = content.Load<Texture2D>("Images/brick");

            /*  Load sounds */
            StartSound = content.Load<SoundEffect>("Sounds/StartSound");
            BrickSound = content.Load<SoundEffect>("Sounds/BrickSound");
            PaddleBounceSound = content.Load<SoundEffect>("Sounds/PaddleBounceSound");
            WallBounceSound = content.Load<SoundEffect>("Sounds/WallBounceSound");
            MissSound = content.Load<SoundEffect>("Sounds/MissSound");

            /*  Load fonts  */
            LabelFont = content.Load<SpriteFont>("Fonts/CenturyGothic20");

            /*  Load music  */
            MusicList = new List<Song>();
            MusicList.Add(content.Load<Song>("Music/NikyNine-Road"));
            MusicList.Add(content.Load<Song>("Music/MikeNoise-LowEarthOrbit"));
            MusicList.Add(content.Load<Song>("Music/MitchMurder-RavagedSkies"));
        }
    }
}

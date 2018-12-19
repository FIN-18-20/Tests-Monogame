﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    public class Achievement
    {
        public bool isUnlocked { get; set; }
        public Texture2D image { get; set; }
        public Texture2D greyImage { get; set; }
        public int unlockCheck { get; set; }
        public int unlockMark { get; set; }
    }
}

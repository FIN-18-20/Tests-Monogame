using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FlappyBird_new
{
    public class Ground : GameObject
    {
        // FIELDS
        private int baseX;
        private int currentOffset;
        private int timer;

        // CONSTRUCTOR
        public Ground(int x, int y)
            : base(x, y, new Sprite("ground"))
        {
            this.baseX = x;
            this.currentOffset = 0;
            this.timer = 0;
        }

        // METHODS
        
        // UPDATE
        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);

            this.timer += gameTime.ElapsedGameTime.Milliseconds;

            while (this.timer >= 16)
            {
                this.timer -= 16;
                this.currentOffset += 1;

                if (this.currentOffset >= 7)
                    this.currentOffset = 0;

                this.hitbox.X = this.baseX - (this.currentOffset * Settings.PIXEL_RATIO);
            }
        }
    }
}

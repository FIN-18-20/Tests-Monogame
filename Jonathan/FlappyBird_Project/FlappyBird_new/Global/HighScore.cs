using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FlappyBird_new
{
    public class HighScore
    {
        // STATIC FIELDS
        private static string fileName = "highscore";

        // STATIC METHODS
        public static int GetHighScore()
        {
            int score = 0;

            try
            {
                using (BinaryReader reader = new BinaryReader(new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read)))
                    score = reader.ReadInt32();
            }
            catch (EndOfStreamException)
            {
                return 0;
            }

            return score;
        }

        public static void SetHighScore(int score)
        {
            using (BinaryWriter writer = new BinaryWriter(new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write)))
                writer.Write(score);
        }
    }
}

using StoreHighscoresXML.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StoreHighscoresXML.Managers
{
    class ScoreManager
    {
        private static string _fileName = "scores.xml"; // pas de chemin spécial spécifié donc sera dans le dossier bin

        public List<Score> Highscores { get; private set; }

        public List<Score> Scores { get; private set; }

        public ScoreManager()
            : this(new List<Score>())
        {

        }

        public ScoreManager(List<Score> scores)
        {
            Scores = scores;

            UpdateHighscores();
        }

        public void Add(Score score)
        {
            Scores.Add(score);

            Scores = Scores.OrderByDescending(c => c.Value).ToList(); // ordre décroissant

            UpdateHighscores();
        }

        public static ScoreManager Load()
        {
            // S'il n'y a aucun fichier à load on crée une nouvelle instance de ScoreManager
            if (!File.Exists(_fileName))
                return new ScoreManager();

            // Autrement on load le fichier
            using (StreamReader reader = new StreamReader(new FileStream(_fileName, FileMode.Open)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Score>));

                List<Score> scores = (List<Score>)serializer.Deserialize(reader);

                return new ScoreManager(scores);
            }
        }

        public void UpdateHighscores()
        {
            Highscores = Scores.Take(5).ToList(); // prend les 5 premiers éléments
        }

        public static void Save(ScoreManager scoreManager)
        {
            // Override le fichier s'il existe déjà
            using (StreamWriter writer = new StreamWriter(new FileStream(_fileName, FileMode.Create)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Score>));

                serializer.Serialize(writer, scoreManager.Scores);
            }
        }
    }
}

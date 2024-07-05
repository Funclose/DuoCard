using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace DuoCards
{
    public class Statistics
    {
        public int SessionId { get; set; }
        public int CorrectAnswers { get; private set; }
        public int IncorrectAnswers { get; private set; }
        public int HintsUsed { get; private set; }

        public Statistics(int sessionId)
        {
            SessionId = sessionId;
            CorrectAnswers = 0;
            IncorrectAnswers = 0;
            HintsUsed = 0;
        }

        public void IncrementCorrectAnswers()
        {
            CorrectAnswers++;
        }

        public void IncrementIncorrectAnswers()
        {
            IncorrectAnswers++;
        }

        public void IncrementHintsUsed()
        {
            HintsUsed++;
        }

        public void SaveToFile()
        {
            string path = $"Statistics_{SessionId}.json";
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(path, json);
        }

        public static int GetNextSessionId()
        {
            int sessionId = 1;
            while (File.Exists($"Statistics_{sessionId}.json"))
            {
                sessionId++;
            }
            return sessionId;
        }
    }
}

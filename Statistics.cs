using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace DuoCards
{
    public class SessionStatistics
    {
        public List<Statistics> Sessions { get; set; }

        public SessionStatistics()
        {
            Sessions = new List<Statistics>();
        }

        public void AddSession(Statistics session)
        {
            Sessions.Add(session);
        }

        public void SaveToFile()
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText("AllStatistics.json", json);
        }

        public static SessionStatistics LoadFromFile()
        {
            if (File.Exists("AllStatistics.json"))
            {
                string json = File.ReadAllText("AllStatistics.json");
                return JsonConvert.DeserializeObject<SessionStatistics>(json);
            }
            return new SessionStatistics();
        }

        public int GetNextSessionId()
        {
            return Sessions.Count + 1;
        }
    }
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

        
    }
}

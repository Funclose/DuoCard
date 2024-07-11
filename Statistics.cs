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
        public int SessionId {  get; set; }
        public SessionStatistics()
        {
            Sessions = new List<Statistics>();
            SessionId = 0;
        }
        public int getID()
        {
            return SessionId;
        }
        public void AddSession(Statistics session)
        {
            Sessions.Add(session);
        }

        public void SaveToFile()
        {
            string json = JsonConvert.SerializeObject(Sessions, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@".\AllStatistics.json", json);
        }

        public void LoadFromFile()
        {
            if (File.Exists(@".\AllStatistics.json"))
            {
                List<Statistics> newList= new List<Statistics>();
                string json = File.ReadAllText(@".\AllStatistics.json");
                newList = JsonConvert.DeserializeObject<List<Statistics>>(json);
                Sessions = newList;
                SessionId = Sessions.Count();
            }
        }
        public void ShowAllStat()
        {
            foreach (Statistics session in Sessions)
            {
                Console.WriteLine(session);
            }
        }
        public void ShowMyStat()
        {
            Console.WriteLine(Sessions[Sessions.Count - 1]);
        }
        public int GetNextSessionId()
        {
            return Sessions.Count + 1;
        }
    }

    public class Statistics
    {
        public int SessionId { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
        public int HintsUsed { get; set; }
        public TimeSpan Time { get; set; }

        public Statistics(int sessionId)
        {
            SessionId = sessionId;
            CorrectAnswers = 0;
            IncorrectAnswers = 0;
            HintsUsed = 0;
            Time = TimeSpan.FromSeconds(1);
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

        public override string ToString()
        {
            return $"Session: {SessionId}, Correct answers: {CorrectAnswers}, Incorrect answers: {IncorrectAnswers}, Hints used: {HintsUsed}, Time spent {Time} ";
        }
    }
}

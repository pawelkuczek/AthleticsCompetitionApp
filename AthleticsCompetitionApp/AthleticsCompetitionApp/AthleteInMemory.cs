using System.Diagnostics;

namespace AthleticsCompetitionApp
{
    public class AthleteInMemory : AthleteBase

    {
        public override event NewAthleteCreatedDelegate NewAthleteCreated;
        public AthleteInMemory(string name, string surname) : base(name, surname) { }

        private List<double> athleteScores = new List<double>();
        private double result100meterRun { get; set; }
        private double resultLongJump { get; set; }
        private double resultShotPut { get; set; }

        protected internal int EventsWon { get; set; }

        public void NewAthleteCreatedMessage()
        {
            ShotEventNewAthleteCreated();
        }
        public override void Add100meterRunResult(double result)
        {

            if (result >= 9.4 && result <= 20)
            {
                this.athleteScores.Add(20 - result);
                this.result100meterRun = result;
            }
            else
            {
                throw new Exception("Nieprawidłowa wartość. Podaj prawidłową wartość np. 12,25. Akceptowany przedział: 9,4 - 20");
            }
        }

        public override void Add100meterRunResult(string result)
        {
            double.TryParse(result, out double resultParsed);
            this.Add100meterRunResult(resultParsed);

        }

        public override void AddLongJumpResult(double result)
        {
            if (result >= 2 && result <= 9.5)
            {
                this.athleteScores.Add(result);
                this.resultLongJump = result;
            }
            else
            {
                throw new Exception("Nieprawidłowa wartość. Podaj prawidłową wartość np. 7,55. Akceptowany przedział: 2 - 9,5");
            }
        }



        public override void AddLongJumpResult(string result)
        {
            double.TryParse(result, out double resultParsed);
            this.AddLongJumpResult(resultParsed);

        }

        public override void AddShotPutResult(double result)
        {
            if (result >= 6 && result <= 24.5)
            {
                this.athleteScores.Add(result);
                this.resultShotPut = result;
            }
            else
            {
                throw new Exception("Nieprawidłowa wartość. Podaj prawidłową wartość np. 15,40. Akceptowany przedział: 6 - 24,5");
            }
        }

        public override void AddShotPutResult(string result)
        {
            double.TryParse(result, out double resultParsed);
            this.AddShotPutResult(resultParsed);
        }

        public override void ShowAthletesScoreboardFromMemory(List<AthleteInMemory> athletes, string date, string place)
        {
            var index = 1;
            Console.WriteLine("");
            Console.WriteLine($"Wyniki Zawodów lekkoatletycznych - {place}, {date}");
            Console.WriteLine("-------------------------------");
            foreach (var athlete in athletes)
            {
                Console.WriteLine($"Miejsce {index}: {athlete.Name} {athlete.Surname} - {athlete.GetAthleteResults().Score:f2} pkt, wygrane konkurencje - {athlete.GetAthleteResults().EventsWon}");
                Console.WriteLine($"[ Bieg na 100m - {athlete.GetAthleteResults().Athlete100mRunResult}s | Skok w dal - {athlete.GetAthleteResults().AthleteLongJumpResult}m | Pchnięcie kulą - {athlete.GetAthleteResults().AthleteShotPutResult}m ]");
                Console.WriteLine("-------------------------------");
                index++;
            }
        }

        public override AthleteResults GetAthleteResults()
        {
            var athleteResults = new AthleteResults();
            athleteResults.Athlete100mRunResult += this.result100meterRun;
            athleteResults.AthleteLongJumpResult += this.resultLongJump;
            athleteResults.AthleteShotPutResult += this.resultShotPut;
            athleteResults.EventsWon += this.EventsWon;

            foreach (var number in this.athleteScores)
            {
                athleteResults.Score += number;
            }

            return athleteResults;
        }
        private void ShotEventNewAthleteCreated()
        {
            if (NewAthleteCreated != null)
            {
                NewAthleteCreated(this, new EventArgs());
            }
        }
    }
}

using System.Diagnostics;

namespace AthleticsCompetitionApp
{
    public class AthleteInMemory : AthleteBase

    {

        public override event Athlete100mRunResultAddedDelegate Athlete100mRunResultAdded;

        public override event AthleteLongJumpResultAddedDelegate AthleteLongJumpResultAdded;

        public override event AthleteShotPutResultAddedDelegate AthleteShotPutResultAdded;

        public override event AthleteResultsSavedToFileDelegate AthleteResultsSavedToFile;
        public AthleteInMemory(string name, string surname) : base(name, surname) { }

        private List<double> athleteScores = new List<double>();
        private double result100meterRun { get; set; }
        private double resultLongJump { get; set; }
        private double resultShotPut { get; set; }
        public override void Add100meterRunResult(double result)
        {
            //switch (result)
            //{
            //    case >= 9.4 and <= 9.99:
            //        this.athleteScores.Add(10);
            //        break;
            //    case >= 10 and < 10.5:
            //        this.athleteScores.Add(9);
            //        break;
            //    case >= 10.5 and < 10.9:
            //        this.athleteScores.Add(8);
            //        break;
            //    case >= 10.9 and < 11.3:
            //        this.athleteScores.Add(7);
            //        break;
            //    case >= 11.3 and < 12:
            //        this.athleteScores.Add(6);
            //        break;
            //    case >= 12 and < 13:
            //        this.athleteScores.Add(5);
            //        break;
            //    case >= 13 and < 14:
            //        this.athleteScores.Add(4);
            //        break;
            //    case >= 14 and < 15:
            //        this.athleteScores.Add(3);
            //        break;
            //    case >= 15 and < 16:
            //        this.athleteScores.Add(2);
            //        break;
            //    case >= 16 and <= 20:
            //        this.athleteScores.Add(1);
            //        break;
            //    default:
            //        throw new Exception("Nieprawidłowa wartość. Podaj prawidłową wartość np. 12,25. Akceptowany przedział: 9,4 - 20");
            //}
            if (result >= 9.4 && result <= 20)
            {
                this.result100meterRun = 20 - result;
                ShotEventAthlete100mRunResultAdded();
            }
            else
            {
                throw new Exception("Nieprawidłowa wartość. Podaj prawidłową wartość np. 12,25. Akceptowany przedział: 9,4 - 20");
            }
        }

        public override void Add100meterRunResult(string result)
        {
            if (double.TryParse(result, out double resultParsed))
            {
                this.Add100meterRunResult(resultParsed);
            }
            else
            {
                throw new Exception("Nieprawidłowa wartość. Podaj prawidłową wartość np. 12,25. Akceptowany przedział: 9,4 - 20");
            }
        }

        public override void AddLongJumpResult(double result)
        {
            if (result >= 2 && result <= 9.5)
            {
                this.athleteScores.Add(result);
                this.resultLongJump = result;
                ShotEventAthleteLongJumpResultAdded();
            }
            else
            {
                throw new Exception("Nieprawidłowa wartość. Podaj prawidłową wartość np. 7,55. Akceptowany przedział: 2 - 9,5");
            }
        }



        public override void AddLongJumpResult(string result)
        {
            if (double.TryParse(result, out double resultParsed))
            {
                this.AddLongJumpResult(resultParsed);
            }
            else
            {
                throw new Exception("Nieprawidłowa wartość. Podaj prawidłową wartość np. 7,55. Akceptowany przedział: 2 - 9,5");
            }
        }

        public override void AddShotPutResult(double result)
        {
            if (result >= 6 && result <= 24.5)
            {
                this.athleteScores.Add(result);
                this.resultShotPut = result;
                ShotEventAthleteShotPutResultAdded();
            }
            else
            {
                throw new Exception("Nieprawidłowa wartość. Podaj prawidłową wartość np. 15,40. Akceptowany przedział: 6 - 24,5");
            }
        }

        public override void AddShotPutResult(string result)
        {
            if (double.TryParse(result, out double resultParsed))
            {
                this.AddShotPutResult(resultParsed);
            }
            else
            {
                throw new Exception("Nieprawidłowa wartość pchnięcia kulą. Podaj prawidłową wartość np. 16,33");
            }
        }

        public override AthleteResults GetAthleteResults()
        {
            var athleteResults = new AthleteResults();
            athleteResults.Athlete100mRunResult += this.result100meterRun;
            athleteResults.AthleteLongJumpResult += this.resultLongJump;
            athleteResults.AthleteShotPutResult += this.resultShotPut;

            foreach (var number in this.athleteScores)
            {
                athleteResults.Score += number;
            }

            return athleteResults;
        }

        private void ShotEventAthlete100mRunResultAdded()
        {
            if (Athlete100mRunResultAdded != null)
            {
                Athlete100mRunResultAdded(this, new EventArgs());
            }
        }
        private void ShotEventAthleteLongJumpResultAdded()
        {
            if (AthleteLongJumpResultAdded != null)
            {
                AthleteLongJumpResultAdded(this, new EventArgs());
            }
        }

        private void ShotEventAthleteShotPutResultAdded()
        {
            if (AthleteShotPutResultAdded != null)
            {
                AthleteShotPutResultAdded(this, new EventArgs());
            }
        }

        protected void ShotEventSaveAthleteResultsToFile()
        {
            if (AthleteResultsSavedToFile != null)
            {
                AthleteResultsSavedToFile(this, new EventArgs());
            }
        }
    }
}

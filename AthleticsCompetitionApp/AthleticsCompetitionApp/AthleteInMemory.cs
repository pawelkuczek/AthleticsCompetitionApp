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

        private List<int> athleteScores = new List<int>();
        private double result100meterRun { get; set; }
        private double resultLongJump { get; set; }
        private double resultShotPut { get; set; }
        public override void Add100meterRunResult(double result)
        {
            if (result < 10.2)
            {
                this.athleteScores.Add(10);
                this.result100meterRun = result;
                ShotEventAthlete100mRunResultAdded();
            }
            else if (result >= 10.2 && result < 10.5)
            {
                this.athleteScores.Add(9);
                this.result100meterRun = result;
                ShotEventAthlete100mRunResultAdded();
            }
            else if (result >= 10.5 && result < 10.9)
            {
                this.athleteScores.Add(8);
                this.result100meterRun = result;
                ShotEventAthlete100mRunResultAdded();
            }
            else if (result >= 10.9 && result < 11.3)
            {
                this.athleteScores.Add(7);
                this.result100meterRun = result;
                ShotEventAthlete100mRunResultAdded();
            }
            else if (result >= 11.3)
            {
                this.athleteScores.Add(6);
                this.result100meterRun = result;
                ShotEventAthlete100mRunResultAdded();
            }
            else
            {
                throw new Exception("Invalid 100m run result");
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
                throw new Exception("Invalid 100m run result");
            }
        }

        public override void AddLongJumpResult(double result)
        {
            if (result >= 8.6)
            {
                this.athleteScores.Add(10);
                this.resultLongJump = result;
                ShotEventAthleteLongJumpResultAdded();
            }
            else if (result < 8.6 && result >= 8.3)
            {
                this.athleteScores.Add(9);
                this.resultLongJump = result;
                ShotEventAthleteLongJumpResultAdded();
            }
            else if (result < 8.3 && result >= 8)
            {
                this.athleteScores.Add(8);
                this.resultLongJump = result;
                ShotEventAthleteLongJumpResultAdded();
            }
            else if (result < 8 && result >= 7.7)
            {
                this.athleteScores.Add(7);
                this.resultLongJump = result;
                ShotEventAthleteLongJumpResultAdded();
            }
            else if (result < 7.7)
            {
                this.athleteScores.Add(6);
                this.resultLongJump = result;
                ShotEventAthleteLongJumpResultAdded();
            }
            else
            {
                throw new Exception("Invalid long jump result");
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
                throw new Exception("Invalid long jump result");
            }
        }

        public override void AddShotPutResult(double result)
        {

            if (result >= 23)
            {
                this.athleteScores.Add(10);
                this.resultShotPut = result;
                ShotEventAthleteShotPutResultAdded();
            }
            else if (result < 23 && result >= 22.7)
            {
                this.athleteScores.Add(9);
                this.resultShotPut = result;
                ShotEventAthleteShotPutResultAdded();
            }
            else if (result < 22.7 && result >= 22.4)
            {
                this.athleteScores.Add(8);
                this.resultShotPut = result;
                ShotEventAthleteShotPutResultAdded();
            }
            else if (result < 22.4 && result >= 22.1)
            {
                this.athleteScores.Add(7);
                this.resultShotPut = result;
                ShotEventAthleteShotPutResultAdded();
            }
            else if (result < 22.1)
            {
                this.athleteScores.Add(6);
                this.resultShotPut = result;
                ShotEventAthleteShotPutResultAdded();
            }
            else
            {
                throw new Exception("Invalid shot put result");
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
                throw new Exception("Invalid shot put result");
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

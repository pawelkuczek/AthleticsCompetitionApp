namespace AthleticsCompetitionApp
{
    public abstract class AthleteBase : IAthlete
    {
        public delegate void Athlete100mRunResultAddedDelegate(object sender, EventArgs args);

        public abstract event Athlete100mRunResultAddedDelegate Athlete100mRunResultAdded;

        public delegate void AthleteLongJumpResultAddedDelegate(object sender, EventArgs args);

        public abstract event AthleteLongJumpResultAddedDelegate AthleteLongJumpResultAdded;

        public delegate void AthleteShotPutResultAddedDelegate(object sender, EventArgs args);

        public abstract event AthleteShotPutResultAddedDelegate AthleteShotPutResultAdded;

        public delegate void AthleteResultsSavedToFileDelegate(object sender, EventArgs args);

        public abstract event AthleteResultsSavedToFileDelegate AthleteResultsSavedToFile;
        public AthleteBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
        public string Name { get; set; }
        public string Surname { get; set; }

        public abstract void Add100meterRunResult(double result);

        public abstract void Add100meterRunResult(string result);

        public abstract void AddLongJumpResult(double result);


        public abstract void AddLongJumpResult(string result);


        public abstract void AddShotPutResult(double result);

        public abstract void AddShotPutResult(string result);



        public abstract AthleteResults GetAthleteResults();
    }
}

﻿namespace AthleticsCompetitionApp
{
    public abstract class AthleteBase : IAthlete
    {
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
    }
}

namespace AthleticsCompetitionApp
{
    public interface IAthlete
    {
        string Name { get; }
        string Surname { get; }

        public void Add100meterRunResult(double result);
        public void Add100meterRunResult(string result);

        public void AddLongJumpResult(double result);
        public void AddLongJumpResult(string result);
        public void AddShotPutResult(double result);

        public void AddShotPutResult(string result);

    }
}

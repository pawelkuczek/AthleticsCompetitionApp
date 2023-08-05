
using System.Xml.Schema;

namespace AthleticsCompetitionApp
{
    public class AthleteResults
    {
        public int Score { get; set; }
        public double Athlete100mRunResult { get; set; }
        public double AthleteLongJumpResult { get; set; }
        public double AthleteShotPutResult { get; set; }

        public char AthleteClassification
        {
            get
            {
                switch (this.Score)
                {
                    case var score when score >= 27:
                        return 'A';
                    case var score when score >= 24:
                        return 'B';
                    case var score when score >= 21:
                        return 'C';
                    case var score when score >= 18:
                        return 'D';
                    default:
                        return 'E';

                }
            }
        }

        public AthleteResults()
        {
            this.Score = 0;
            this.Athlete100mRunResult = 0;
            this.AthleteLongJumpResult = 0;
            this.AthleteShotPutResult = 0;

        }
    }
}


using System.Xml.Schema;

namespace AthleticsCompetitionApp
{
    public class AthleteResults
    {
        public double Score { get; protected internal set; }
        public double EventsWon { get; protected internal set; }
        public double Athlete100mRunResult { get; protected internal set; }
        public double AthleteLongJumpResult { get; protected internal set; }
        public double AthleteShotPutResult { get; protected internal set; }

        public AthleteResults()
        {
            this.Score = 0;
            this.EventsWon = 0; 
            this.Athlete100mRunResult = 0;
            this.AthleteLongJumpResult = 0;
            this.AthleteShotPutResult = 0;
        }
    }
}

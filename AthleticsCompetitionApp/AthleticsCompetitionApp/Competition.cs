namespace AthleticsCompetitionApp
{

    public class Competition
    {

        public void CheckIfDateIsCorrect(string date)
        {
            if (!DateTime.TryParse(date, out DateTime dateParsed))
            {
                throw new Exception("Nieprawidłowy format daty. Podaj prawidłową datę, np. 06.08.2023");
            }

        }

        public void CheckIFValueContainsOnlyLetters(string value)
        {
            if (!value.All(char.IsLetter))
            {
                throw new Exception("Nieprawidłowa wartość. Należy używać tylko liter.");
            }

        }
        public void Check100mRunWinner(List<AthleteInMemory> athletes)
        {
            athletes.Sort((a1, a2) => a1.GetAthleteResults().Athlete100mRunResult.CompareTo(a2.GetAthleteResults().Athlete100mRunResult));
            athletes[0].EventsWon += 1;
        }

        public void Check100mRunWinner(List<AthleteInFile> athletes)
        {
            athletes.Sort((a1, a2) => a1.GetAthleteResults().Athlete100mRunResult.CompareTo(a2.GetAthleteResults().Athlete100mRunResult));
            athletes[0].EventsWon += 1;
        }

        public void CheckLongJumpWinner(List<AthleteInMemory> athletes)
        {
            athletes.Sort((a1, a2) => a1.GetAthleteResults().AthleteLongJumpResult.CompareTo(a2.GetAthleteResults().AthleteLongJumpResult));
            athletes.Reverse();
            athletes[0].EventsWon += 1;
        }

        public void CheckLongJumpWinner(List<AthleteInFile> athletes)
        {
            athletes.Sort((a1, a2) => a1.GetAthleteResults().AthleteLongJumpResult.CompareTo(a2.GetAthleteResults().AthleteLongJumpResult));
            athletes.Reverse();
            athletes[0].EventsWon += 1;
        }

        public void CheckShotPutWinner(List<AthleteInMemory> athletes)
        {
            athletes.Sort((a1, a2) => a1.GetAthleteResults().AthleteShotPutResult.CompareTo(a2.GetAthleteResults().AthleteShotPutResult));
            athletes.Reverse();
            athletes[0].EventsWon += 1;
        }

        public void CheckShotPutWinner(List<AthleteInFile> athletes)
        {
            athletes.Sort((a1, a2) => a1.GetAthleteResults().AthleteShotPutResult.CompareTo(a2.GetAthleteResults().AthleteShotPutResult));
            athletes.Reverse();
            athletes[0].EventsWon += 1;
        }


        public void SortAthletesByScore(List<AthleteInMemory> athletes)
        {
            athletes.Sort((a1, a2) => a1.GetAthleteResults().Score.CompareTo(a2.GetAthleteResults().Score));
            athletes.Reverse();
        }

        public void SortAthletesByScore(List<AthleteInFile> athletes)
        {
            athletes.Sort((a1, a2) => a1.GetAthleteResults().Score.CompareTo(a2.GetAthleteResults().Score));
            athletes.Reverse();
        }
    }
}

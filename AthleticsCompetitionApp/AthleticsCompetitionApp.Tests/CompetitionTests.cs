namespace AthleticsCompetitionApp.Tests
{
    public class CompetitionTests
    {
        private Competition competition = new Competition();

        [Test]
        public void WhenCheckIfDateIsCorrectCalled_ShouldReturnException()
        {
            //act

            var ex = Assert.Throws<Exception>(() => competition.CheckIfDateIsCorrect("date"));

            //assert
            Assert.AreEqual("Nieprawidłowy format daty. Podaj prawidłową datę, np. 06.08.2023", ex.Message);
        }

        [Test]
        public void WhenCheckIFValueContainsOnlyLettersCalled_ShouldReturnCorrectException()
        {
            //act
            var ex = Assert.Throws<Exception>(() => competition.CheckIFValueContainsOnlyLetters("value2"));

            //assert
            Assert.AreEqual("Nieprawidłowa wartość. Należy używać tylko liter.", ex.Message);
        }

        [Test]
        public void WhenCheck100mRunWinnerCalled_ShouldReturnCorrectValues()
        {
            //arrange
            List<AthleteInMemory> athletes = new List<AthleteInMemory>()
            {
                new AthleteInMemory("Asafa", "Powell"), new AthleteInMemory("Usain", "Bolt")
        };

            //act
            athletes[0].Add100meterRunResult(9.72);
            athletes[1].Add100meterRunResult(9.58);
            competition.Check100mRunWinner(athletes);

            //assert
            Assert.AreEqual("Usain", athletes[0].Name);
        }

        [Test]
        public void WhenCheckLongJumpWinnerCalled_ShouldReturnCorrectValues()
        {
            //arrange
            List<AthleteInMemory> athletes2 = new List<AthleteInMemory>()
            {
                new AthleteInMemory("Carl", "Lewis"), new AthleteInMemory("Mike", "Powell")
        };
            //act
            athletes2[0].AddLongJumpResult(8.91);
            athletes2[1].AddLongJumpResult(8.95);
            competition.CheckLongJumpWinner(athletes2);

            //assert
            Assert.AreEqual("Mike", athletes2[0].Name);
        }

        [Test]
        public void WhenShotPutWinnerCalled_ShouldReturnCorrectValues()
        {
            //arrange
            List<AthleteInMemory> athletes3 = new List<AthleteInMemory>()
            {
                new AthleteInMemory("Joe", "Kovacs"), new AthleteInMemory("Ryan", "Crouser")
        };
            //act
            athletes3[0].AddShotPutResult(23.23);
            athletes3[1].AddShotPutResult(23.56);
            competition.CheckShotPutWinner(athletes3);

            //assert
            Assert.AreEqual("Ryan", athletes3[0].Name);
        }

        [Test]
        public void WhenSortAthletesByScoreCalled_ShouldReturnCorrectValues()
        {
            //arrange
            List<AthleteInMemory> athletes4 = new List<AthleteInMemory>()
            {
                new AthleteInMemory("Joe", "Kovacs"), new AthleteInMemory("Ryan", "Crouser")
        };
            //act
            athletes4[0].Add100meterRunResult(9.72);
            athletes4[1].Add100meterRunResult(9.58);
            athletes4[0].AddLongJumpResult(8.91);
            athletes4[1].AddLongJumpResult(8.95);
            athletes4[0].AddShotPutResult(23.23);
            athletes4[1].AddShotPutResult(23.56);
            competition.SortAthletesByScore(athletes4);

            //asserts
            Assert.AreEqual("Ryan", athletes4[0].Name);
            Assert.AreEqual("Crouser", athletes4[0].Surname);
            Assert.AreEqual(42.93.ToString(), athletes4[0].GetAthleteResults().Score.ToString("N2"));
        }
    }
}
namespace AthleticsCompetitionApp.Tests
{
    public class AthleteInMemoryTests
    {

        [Test]
        public void WhenAdd100meterRunResultCalled_ShouldReturnCorrectValues()
        {
            //arrange
            var athlete = new AthleteInMemory("Usain", "Bolt");
            var athlete2 = new AthleteInMemory("Asafa", "Powell");

            //act

            athlete.Add100meterRunResult(9.58);
            athlete2.Add100meterRunResult("10,72");
            var athleteResults = athlete.GetAthleteResults();
            var athlete2Results = athlete2.GetAthleteResults();
            var result100m = athleteResults.Athlete100mRunResult;
            var pointValue = athleteResults.Score;
            var result100m2 = athlete2Results.Athlete100mRunResult;
            var pointValue2 = athlete2Results.Score;


            //assert
            Assert.AreEqual(9.58, result100m);
            Assert.AreEqual(10.42, pointValue);
            Assert.AreEqual(10.72, result100m2);
            Assert.AreEqual(9.28, pointValue2);

        }

        [Test]
        public void WhenAddLongJumpRunResultCalled_ShouldReturnCorrectValues()
        {
            //arrange
            var athlete = new AthleteInMemory("Mike", "Powell");
            var athlete2 = new AthleteInMemory("Carl", "Lewis");

            //act

            athlete.AddLongJumpResult(8.95);
            athlete2.AddLongJumpResult("7,82");
            var athleteResults = athlete.GetAthleteResults();
            var athlete2Results = athlete2.GetAthleteResults();
            var resultLongJump = athleteResults.AthleteLongJumpResult;
            var pointValue = athleteResults.Score;
            var resultLongJump2 = athlete2Results.AthleteLongJumpResult;
            var pointValue2 = athlete2Results.Score;

            //assert
            Assert.AreEqual(8.95, resultLongJump);
            Assert.AreEqual(8.95, pointValue);
            Assert.AreEqual(7.82, resultLongJump2);
            Assert.AreEqual(7.82, pointValue2);

        }

        [Test]
        public void WhenAddShotPutResulttCalled_ShouldReturnCorrectValues()
        {
            //arrange
            var athlete = new AthleteInMemory("Ryan", "Crouser");
            var athlete2 = new AthleteInMemory("Tomasz", "Majewski");

            //act
            athlete.AddShotPutResult(23.56);
            athlete2.AddShotPutResult("21,51");
            var athleteResults = athlete.GetAthleteResults();
            var athlete2Results = athlete2.GetAthleteResults();
            var resultShotPut = athleteResults.AthleteShotPutResult;
            var pointValue = athleteResults.Score;
            var resultShotPut2 = athlete2Results.AthleteShotPutResult;
            var pointValue2 = athlete2Results.Score;

            //assert
            Assert.AreEqual(23.56, resultShotPut);
            Assert.AreEqual(23.56, pointValue);
            Assert.AreEqual(21.51, resultShotPut2);
            Assert.AreEqual(21.51, pointValue2);

        }

        [Test]
        public void WhenGetAthleteResultsCalled_ShouldReturnCorrectValues()
        {
            //arrange
            var athlete = new AthleteInMemory("Usain", "Bolt");

            //act
            athlete.Add100meterRunResult(9.58);
            athlete.AddLongJumpResult(8.17);
            athlete.AddShotPutResult(15.78);
            var athleteResults = athlete.GetAthleteResults();

            //assert
            Assert.AreEqual(9.58, athleteResults.Athlete100mRunResult);
            Assert.AreEqual(8.17, athleteResults.AthleteLongJumpResult);
            Assert.AreEqual(15.78, athleteResults.AthleteShotPutResult);
            Assert.AreEqual(34.37, athleteResults.Score);

        }
    }
}
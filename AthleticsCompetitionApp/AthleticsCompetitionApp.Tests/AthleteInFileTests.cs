namespace AthleticsCompetitionApp.Tests
{
    public class AthleteInFileTests
    {
        [Test]
        public void WhenAdd100meterRunResultCalled_ShouldReturnCorrectValues()
        {
            //arrange
            var athlete = new AthleteInFile("Usain", "Bolt");
            const string fileName = "athletes_results.txt";



            //act

            athlete.Add100meterRunResult(9.88);
            athlete.AddLongJumpResult(8.92);
            athlete.AddShotPutResult(22.55);
            athlete.SaveAthleteResultsToFile();


            //assert
            using (var reader = File.OpenText(fileName))
            {
                var lines = reader.ReadToEnd();
                Assert.AreEqual("Wyniki zawodnika: Usain Bolt\r\nBieg na 100m: 9,88s\r\nSkok w dal: 8,92m\r\nPchnięcie kulą: 22,55m\r\nIlość punktów: 28 pkt\r\nKlasa zawodnika: A\r\n---------------------\r\n", lines);
            }

        }

    }
}
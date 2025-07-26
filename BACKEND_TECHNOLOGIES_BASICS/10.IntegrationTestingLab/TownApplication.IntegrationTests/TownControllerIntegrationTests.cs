namespace TownApplication.IntegrationTests
{
    public class TownControllerIntegrationTests
    {
        private readonly TownController _controller;

        public TownControllerIntegrationTests()
        {
            _controller = new TownController();
            _controller.ResetDatabase();
        }

        [Fact]
        public void AddTown_ValidInput_ShouldAddTown()
        {
            // TODO: This test checks if the AddTown method correctly adds a town with valid inputs.

            // Arrange: Prepare the data for the test.
            // 1. Define a town name that is valid (e.g., not too long, not empty).
            // 2. Define a valid population number (positive integer).
            // Replace the placeholder values with actual valid data.
            // Ensure the name is within the valid length
            var validTownName = "Sofia";
            var population = 1000000;

            // Act: Perform the action to be tested.
            // Call the AddTown method on the _controller with the arranged data.
            _controller.AddTown(validTownName, population);

            // Assert: Verify the outcome of the action.
            // 1. Check if the town was actually added to the database.
            // 2. Verify that the town's data in the database matches the data provided.
            // Use Assert.NotNull to ensure the town is found in the database.
            // Use Assert.Equal to compare the expected and actual population values.
            var result = _controller.GetTownByName(validTownName);
            Assert.NotNull(result);
            Assert.StrictEqual(population, result.Population);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("AB")]
        [InlineData("    ")]
        public void AddTown_InvalidName_ShouldThrowArgumentException(string invalidName)
        {
            // TODO: This test verifies that the AddTown method throws an ArgumentException for invalid names.

            // Arrange: Set up the test data.
            // 1. The 'invalidName' parameter is provided by the InlineData attributes.
            // 2. Define a population number that is valid (e.g., positive integer).
            // Replace the placeholder value with actual valid data.
            var townName = invalidName;
            var population = 1000;

            // Act & Assert: Execute the test and check for expected outcomes.
            // 1. Call the AddTown method with the invalid name and check that it throws an ArgumentException.
            // 2. Verify that the exception message is as expected.
            var ex = Assert.Throws<ArgumentException>(() => _controller.AddTown(townName, population));
            Assert.Equal(ex.Message, "Invalid town name.");
            
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void AddTown_InvalidPopulation_ShouldThrowArgumentException(int invalidPopulation)
        {
            // TODO: This test ensures that the AddTown method correctly handles invalid population values.

            // Arrange: Prepare the test data.
            // 1. Define a valid town name.
            // 2. The 'invalidPopulation' parameter is provided by the InlineData attributes.
            // Replace the placeholder value with actual valid data.
            string townName = "Sofia";
            var population = invalidPopulation;

            // Act: Execute the action to be tested.
            // Wrap the call to AddTown in an Action delegate to use with Assert.Throws.

            //var action = () => _controller.AddTown(townName, population);

            // Assert: Verify the outcome of the action.
            // Check if an ArgumentException is thrown and validate the exception message.

            //var ex = Assert.Throws<ArgumentException>(action);
            //Assert.Equal(ex.Message, "Population must be a positive number.");

            try
            {
                _controller.AddTown(townName, population);
                Assert.Fail("Expected exception was not thrown");
            }
            catch(Exception ex)
            {
                Assert.Equal(ex.Message, "Population must be a positive number.");
                Assert.IsType<ArgumentException>(ex);
                
            }

        }

        [Fact]
        public void AddTown_DuplicateTownName_DoesNotAddDuplicateTown()
        {
            // TODO: This test verifies that the AddTown method does not add a duplicate town.

            // Arrange: Set up the test data.
            // 1. Define a town name to use for testing.
            // 2. Define a population number for the town.
            // Use the same name for both additions to simulate a duplicate entry.
            string townName = "Plovdiv";
            int population = 2000;

            // Add a town initially to set up the duplicate scenario.
            _controller.AddTown(townName, population);

            // Act: Try to add the same town again.
            _controller.AddTown(townName, population);

            // Assert: Verify that a duplicate town was not added.
            // 1. Check the total number of towns in the database.
            // 2. Ensure that the count is still 1, indicating no duplicate was added.
            var result = _controller.ListTowns();
            Assert.True(result.Count == 1);
            var item = result[0];
            Assert.Equal(population, item.Population);
            Assert.Equal(townName, item.Name);
        }

        [Fact]
        public void UpdateTown_ShouldUpdatePopulation()
        {
            // TODO: This test checks if the UpdateTown method correctly updates the population of a town.

            // Arrange: Set up the initial state and the data for the test.
            // 1. Define a town name and an initial population number.
            // 2. Add the town to the database.
            // 3. Define an updated population number.
            string townName = "Varna";
            int population = 20000;
            int updatedPopulation = 24000;

            _controller.AddTown(townName, population);

            // Act: Perform the update action.
            // 1. Retrieve the town to be updated.
            // 2. Call the UpdateTown method with the new population value.
            var townId = _controller.GetTownByName(townName).Id;
            
            _controller.UpdateTown(townId, updatedPopulation);

            // Assert: Verify that the town's population was updated.
            // 1. Retrieve the town again and check if the population matches the updated value.
            // 2. Use Assert.NotNull to ensure the town is found in the database.
            // 3. Use Assert.Equal to check if the population is updated as expected.
            var updatedTown = _controller.GetTownByName(townName);
            Assert.NotNull(updatedTown);
            Assert.Equal(updatedTown.Population, updatedPopulation);
        }

        [Fact]
        public void DeleteTown_ShouldDeleteTown()
        {
            // TODO: This test ensures that the DeleteTown method correctly removes a town from the database.

            // Arrange: Prepare the data and initial state for the test.
            // 1. Define a town name and population number.
            // 2. Add the town to the database to set up the deletion scenario.
            var townName = "Burgas";
            var population = 45000;
            _controller.AddTown(townName , population);

            // Act: Perform the deletion action.
            // 1. Retrieve the town to be deleted.
            // 2. Call the DeleteTown method with the town's ID
            var addedTown = _controller.GetTownByName(townName);
            _controller.DeleteTown(addedTown.Id);

            // Assert: Verify that the town was successfully deleted.
            // 1. Attempt to retrieve the deleted town and check that it no longer exists in the database.
            // 2. Use Assert.Null to ensure that the town is not found.
            Assert.Null(_controller.GetTownByName(townName));
        }

        [Fact]
        public void ListTowns_ShouldReturnTowns()
        {
            // TODO: This test checks if the ListTowns method correctly returns a list of all towns in the database.

            // Arrange: Prepare the data for the test.
            // 1. Add several towns to the database to create a list of towns.
            // Each town should have a unique name and a valid population number.
            var townsToAdd = new List<string> {"Plovdiv", "Sofia", "Varna"};

            foreach (var town in townsToAdd)
            {
                _controller.AddTown(town, town.Length * 1000);
            }

            // Act: Retrieve the list of towns from the database.
            var townsInDb = _controller.ListTowns();

            // Assert: Verify the correctness of the retrieved list.
            // 1. Check if the number of towns in the list matches the number of towns added.
            // 2. Verify that each added town is present in the list.
            Assert.Equal(townsInDb.Count, townsToAdd.Count);

            foreach (var town in townsToAdd)
            {
                var existingTown = townsInDb.FirstOrDefault(x => x.Name == town);
                Assert.NotNull(existingTown);
                Assert.Equal(town.Length * 1000, existingTown.Population);
            }
        }
    }
}

namespace WebServicesTesting.Utils
{
    public static class TestDataGenerator
    {
        public static string GenerateRandomEmail()
        {
            return $"user{Guid.NewGuid()}@test.com";
        }
    }
}

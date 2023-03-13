namespace RFord.Projects.FluentContentSecurityPolicy.Tests
{
    public class BuilderTests
    {
        [Theory]
        [ClassData(typeof(TestData))]
        public void EnsureCompleteValues(
            IContentSecurityPolicy policy,
            IDictionary<string, HashSet<string>> expectedDirectives
        )
        {
            string resultantString = policy.Evaluate();

            string[] directives = resultantString.Split(';').Select(x => x.Trim()).ToArray();
            foreach (string directiveString in directives)
            {
                string[] parts = directiveString.Split(' ');
                var directive = parts.First();
                var values = parts.Skip(1).ToHashSet();

                var expectedValues = expectedDirectives[directive];

                Assert.Equal(expectedValues, values);
            }
        }
    }
}

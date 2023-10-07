
using Xunit;

namespace Triangler.Tests
{
    public class TriangleCalculatorTests
    {
        [Theory]
        [InlineData("5", "5", "5", "равносторонний")]
        [InlineData("5", "5", "3", "равнобедренный")]
        [InlineData("5", "4", "3", "разносторонний")]
        [InlineData("5", "1", "1", "не треугольник")]
        public void CheckTriangleTypeIdentification(string aLength, string bLength, string cLength, string expected)
        {
            string typeResult = TriangleCalculator.CalculateTriangle(aLength, bLength, cLength).triangleType;

            Assert.Equal(expected, typeResult);
        }

        [Theory]
        [InlineData("5", "5", "5", 5.0, 5.0, 5.0)]

        public void CheckSideLengthValidization(string aLength, string bLength, string cLength, float aExpected, float bExpected , float cExpected)
        {
            (float, float, float) typeResult = TriangleCalculator.CalculateTriangle(aLength, bLength, cLength).validazedValues;

            Assert.Equal(aExpected, typeResult.Item1);
            Assert.Equal(bExpected, typeResult.Item2);
            Assert.Equal(cExpected, typeResult.Item3);
        }
    }
}


using Xunit;

namespace Triangler.Tests
{
    public class TriangleCalculatorTests
    {
        [Theory]
        [InlineData("5", "5", "5", "равносторонний")]

        [InlineData("5", "5", "3", "равнобедренный")]
        [InlineData("3", "5", "5", "равнобедренный")]
        [InlineData("5", "3", "5", "равнобедренный")]

        [InlineData("5", "4", "3", "разносторонний")]
        [InlineData("5", "3", "4", "разносторонний")]
        [InlineData("3", "4", "5", "разносторонний")]
        [InlineData("3", "5", "4", "разносторонний")]
        [InlineData("4", "5", "3", "разносторонний")]
        [InlineData("4", "3", "5", "разносторонний")]

        [InlineData("5", "1", "1", "не треугольник")]
        [InlineData("1", "5", "1", "не треугольник")]
        [InlineData("1", "1", "5", "не треугольник")]

        [InlineData("0", "0", "0", "")]
        public void CheckTriangleTypeIdentification(string aLength, string bLength, string cLength, string expected)
        {
            var result = TriangleCalculator.CalculateTriangle(aLength, bLength, cLength);

            Assert.Equal(expected, result.triangleType);
        }

        [Theory]
        [InlineData("5", "5", "5", 5.0, 5.0, 5.0)]
        [InlineData("5", "5", "5asdasd", 5.0, 5.0, 0)]
        [InlineData("5", "5asdasd", "5", 5.0, 0, 5.0)]
        [InlineData("5asdasd", "5", "5", 0, 5.0, 5.0)]
        [InlineData("0", "0", "0", 0, 0, 0)]
        [InlineData("-2", "-2", "-2", 2, 2, 2)]
        public void CheckSideLengthValidization(string aLength, string bLength, string cLength, float aExpected, float bExpected , float cExpected)
        {
            (float, float, float) typeResult = TriangleCalculator.CalculateTriangle(aLength, bLength, cLength).validazedValues;

            Assert.Equal(aExpected, typeResult.Item1);
            Assert.Equal(bExpected, typeResult.Item2);
            Assert.Equal(cExpected, typeResult.Item3);
        }
    }
}

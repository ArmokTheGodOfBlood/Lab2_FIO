
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

        [InlineData("-2", "1", "1", "равнобедренный")]
        [InlineData("1", "-2", "1", "равнобедренный")]
        [InlineData("1", "1", "-2", "равнобедренный")]
        [InlineData("-2", "3", "1", "разносторонний")]
        [InlineData("1", "-2", "3", "разносторонний")]
        [InlineData("3", "1", "-2", "разносторонний")]
        [InlineData("-2", "-2", "-2", "равносторонний")]

        public void CheckTriangleTypeForCorrectValues(string aLength, string bLength, string cLength ,string expecteType)
        {
            var result = TriangleCalculator.CalculateTriangle(aLength, bLength, cLength);

            Assert.Equal(expecteType, result.triangleType);

            Assert.True((result.pointCoordinates[0].Item1 <= 100) && (result.pointCoordinates[0].Item2 <= 100));
            Assert.True((result.pointCoordinates[0].Item1 >= 0) && (result.pointCoordinates[0].Item2 >= 0));

            Assert.True((result.pointCoordinates[1].Item1 <= 100) && (result.pointCoordinates[1].Item2 <= 100));
            Assert.True((result.pointCoordinates[1].Item1 >= 0) && (result.pointCoordinates[1].Item2 >= 0));

            Assert.True((result.pointCoordinates[2].Item1 <= 100) && (result.pointCoordinates[2].Item2 <= 100));
            Assert.True((result.pointCoordinates[2].Item1 >= 0) && (result.pointCoordinates[2].Item2 >= 0));

            var aCalculatedLength = Math.Sqrt(
                (result.pointCoordinates[2].Item1 - result.pointCoordinates[1].Item1)*(result.pointCoordinates[2].Item1 - result.pointCoordinates[1].Item1)
                +
                (result.pointCoordinates[2].Item2 - result.pointCoordinates[1].Item2) * (result.pointCoordinates[2].Item2 - result.pointCoordinates[1].Item2)
                );
            var bCalculatedLength = Math.Sqrt(
                (result.pointCoordinates[2].Item1 - result.pointCoordinates[0].Item1) * (result.pointCoordinates[2].Item1 - result.pointCoordinates[0].Item1)
                +
                (result.pointCoordinates[2].Item2 - result.pointCoordinates[0].Item2) * (result.pointCoordinates[2].Item2 - result.pointCoordinates[0].Item2)
                );
            //Assert.Equal(aCalculatedLength / bCalculatedLength, result.validazedValues.a / result.validazedValues.b);
            //проверяю отношение сторон
            //видимо, не очень правильно
        }

        [Theory]
        [InlineData("5", "1", "1", "не треугольник")]
        [InlineData("1", "5", "1", "не треугольник")]
        [InlineData("1", "1", "5", "не треугольник")]
        public void CheckTriangleForCorectNonTriangleValues(string aLength, string bLength, string cLength, string expecteType)
        {
            var result = TriangleCalculator.CalculateTriangle(aLength, bLength, cLength);

            Assert.Equal(expecteType, result.triangleType);
            Assert.Equal(new (int, int)[] { (-1, -1), (-1, -1), (-1, -1) }, result.pointCoordinates);
        }

        [Theory]
        [InlineData("0", "1", "1", "")]
        [InlineData("1", "0", "1", "")]
        [InlineData("1", "1", "0", "")]

        [InlineData("aaa", "1", "1", "")]
        [InlineData("1", "aaa", "1", "")]
        [InlineData("1", "1", "aaa", "")]

        [InlineData("", "1", "1", "")]
        [InlineData("1", " ", "1", "")]
        [InlineData("1", "1", " ", "")]
        
        [InlineData(null, "1", "1", "")]
        [InlineData("1", null, "1", "")]
        [InlineData("1", "1", null, "")]
        public void CheckTriangleTypeIdentification1(string aLength, string bLength, string cLength, string expecteType)
        {
            var result = TriangleCalculator.CalculateTriangle(aLength, bLength, cLength);

            Assert.Equal(expecteType, result.triangleType);
            Assert.Equal(new (int, int)[] { (-2, -2), (-2, -2), (-2, -2) }, result.pointCoordinates);
        }
    }

    internal record struct NewStruct(int Item1, int Item2, int Item3)
    {
        public static implicit operator (int, int, int)(NewStruct value)
        {
            return (value.Item1, value.Item2, value.Item3);
        }

        public static implicit operator NewStruct((int, int, int) value)
        {
            return new NewStruct(value.Item1, value.Item2, value.Item3);
        }
    }
}

namespace FigureLibrary.Core.Tests
{
    public class CircleTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(2.5)]
        public void Create_WhenRadiusIsPositiveOrZero_ReturnsSuccess(double radius)
        {
            //Arange

            //Act

            var createResult = Circle.Create(radius);

            //Assert

            Assert.True(createResult.IsSuccess);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2.5)]
        public void Create_WhenRadiusNegative_ReturnsFailure(double radius)
        {
            //Arange

            //Act

            var createResult = Circle.Create(radius);

            //Assert

            Assert.True(createResult.IsFailure);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(2, 12.566371)]
        [InlineData(15, 706.858347)]
        public void GetArea_ShouldReturnCorrectResult(double radius, double expected)
        {
            //Arange

            var circle = Circle.Create(radius);
            int precision = 6;

            //Act

            var area = circle.Value.GetArea();

            //Assert

            Assert.Equal(expected, area, precision);
        }
    }
}

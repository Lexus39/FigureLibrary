namespace FigureLibrary.Core.Tests
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(3,4,5)]
        [InlineData(4,7,10)]
        [InlineData(2,2,3)]
        public void Create_WhenTriangleExist_ReturnsSuccess(double sideA, double sideB, double sideC)
        {
            //Arange

            //Act

            var createResult = Triangle.Create(sideA, sideB, sideC);

            //Assert

            Assert.True(createResult.IsSuccess);
        }

        [Theory]
        [InlineData(3, 0, 5)]
        [InlineData(4, -7, 10)]
        public void Create_WhenSidesNegativeOrZero_ReturnsFailure(double sideA, double sideB, double sideC)
        {
            //Arange

            //Act

            var createResult = Triangle.Create(sideA, sideB, sideC);

            //Assert

            Assert.True(createResult.IsFailure);
        }

        [Theory]
        [InlineData(2, 5, 2)]
        [InlineData(4, 6, 10)]
        [InlineData(1, 2, 3)]
        public void Create_WhenTriangleDoesNotExist_ReturnsFailure(double sideA, double sideB, double sideC)
        {
            //Arange

            //Act

            var createResult = Triangle.Create(sideA, sideB, sideC);

            //Assert

            Assert.True(createResult.IsFailure);
        }

        [Theory]
        [InlineData(3, 4, 5, 6)]
        [InlineData(4, 7, 10, 10.928746)]
        [InlineData(2, 2, 3, 1.984313)]
        public void GetArea_ShouldReturnCorrectResult(double sideA, double sideB, double sideC, double expected)
        {
            //Arange

            var triangle = Triangle.Create(sideA, sideB, sideC);
            int precision = 6;

            //Act

            var area = triangle.Value.GetArea();

            //Assert

            Assert.Equal(expected, area, precision);
        }


        [Theory]
        [InlineData(3, 4, 5, true)]
        [InlineData(4, 7, 10, false)]
        [InlineData(2, 2, 3, false)]
        [InlineData(6, 8, 10, true)]
        [InlineData(6, 7, 10, false)]
        public void IsRightTriangle_ShouldReturnCorrectResult(double sideA, double sideB, double sideC, bool expected)
        {
            //Arange

            var triangle = Triangle.Create(sideA, sideB, sideC);

            //Act

            var result = triangle.Value.IsRightTriangle();

            //Assert

            Assert.Equal(expected, result);
        }
    }
}

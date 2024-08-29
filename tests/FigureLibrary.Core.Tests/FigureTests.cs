namespace FigureLibrary.Core.Tests
{
    public class FigureTests
    {
        public static IEnumerable<object[]> Figures =>
            new List<object[]>()
            {
                new object[2] { Triangle.Create(3, 4, 5).Value, 6},
                new object[2] { Circle.Create(15).Value, 706.858347 },
                new object[2] { Triangle.Create(4, 7, 10).Value, 10.928746 }
            };

        [Theory]
        [MemberData(nameof(Figures))]
        public void GetArea_ShouldCalculateCorrect(Figure figure, double expected)
        {
            //Arange

            int precision = 6;

            //Act

            var area = figure.GetArea();

            //Assert

            Assert.Equal(expected, area, precision);
        }
    }
}

using CSharpFunctionalExtensions;

namespace FigureLibrary.Core
{
    public class Triangle : Figure
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        private Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public static Result<Triangle> Create(double sideA, double sideB, double sideC)
        {
            var triangle = new Triangle(sideA, sideB, sideC);
            var validationResult = triangle.Validate();
            if (validationResult.IsFailure)
            {
                return Result.Failure<Triangle>(validationResult.Error);
            }
            return Result.Success(triangle);
        }

        private Result Validate()
        {
            if (SideA <= 0 || SideB <= 0 || SideC <= 0)
            {
                return Result.Failure("Sides must be greater than zero");
            }
            if (SideA + SideB <= SideC 
                || SideB + SideC <= SideA 
                || SideC + SideA <= SideB)
            {
                return Result.Failure("Triangle does not exist");
            }
            return Result.Success();
        }

        public override double GetArea()
        {
            var semiPerimeter = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * 
                (semiPerimeter - SideB) * (semiPerimeter - SideC));
        }

        public bool IsRightTriangle()
        {
            var sides = OrderSides();
            return sides[2] * sides[2] == sides[0] * sides[0] + sides[1] * sides[1];
        }

        private double[] OrderSides()
        {
            var sides = new double[3] { SideA, SideB, SideC };
            Array.Sort(sides);
            return sides;
        }
    }
}

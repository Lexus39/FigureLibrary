using CSharpFunctionalExtensions;

namespace FigureLibrary.Core
{
    public class Circle : Figure
    {
        public double Ragius { get; }

        private Circle(double radius)
        {
            Ragius = radius;
        }

        public static Result<Circle> Create(double radius)
        {
            var circle = new Circle(radius);
            var validationResult = circle.Validate();
            if (validationResult.IsFailure)
            {
                return Result.Failure<Circle>(validationResult.Error);
            }
            return Result.Success(circle);
        }

        private Result Validate()
        {
            if (Ragius < 0)
            {
                return Result.Failure("Radius cannot be less than 0");
            }
            return Result.Success();
        }

        public override double GetArea()
        {
            return Math.PI * Ragius * Ragius;
        }
    }
}

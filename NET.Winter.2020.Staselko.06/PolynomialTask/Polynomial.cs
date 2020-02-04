using System;
using System.Text;

namespace PolynomialTask
{
    /// <summary>
    /// Sealed class Polinomial.
    /// Implemets interfaces IEquatable, ICloneable.
    /// </summary>
    public sealed class Polynomial : IEquatable<Polynomial>, ICloneable
    {
        private readonly int countOfCoefficients;
        private readonly double[] coefficients;
        private double epsilon = 0.0001;

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="coefficients">Array of coefficients.</param>
        public Polynomial(double[] coefficients)
        {
            if (coefficients is null)
            {
                throw new ArgumentNullException(nameof(coefficients), "cannot be null");
            }

            if (coefficients.Length == 0)
            {
                throw new ArgumentException("array cannot be empty");
            }

            this.countOfCoefficients = coefficients.Length;
            this.coefficients = new double[this.countOfCoefficients];

            for (int i = 0; i < this.countOfCoefficients; i++)
            {
                this.coefficients[i] = coefficients[i];
            }
        }

        /// <summary>
        /// Gets or sets aaccuracy of calculations.
        /// </summary>
        /// <value>
        /// Epsilon = 0.0001.
        /// </value>
        public double Epsilon { get => this.epsilon; set => this.epsilon = value; }

        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(lhs), "cannot be null");
            }

            if (rhs is null)
            {
                throw new ArgumentNullException(nameof(rhs), "cannot be null");
            }

            return Add(lhs, rhs);
        }

        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(lhs), "cannot be null");
            }

            if (rhs is null)
            {
                throw new ArgumentNullException(nameof(rhs), "cannot be null");
            }

            return Subtract(lhs, rhs);
        }

        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(lhs), "cannot be null");
            }

            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(rhs), "cannot be null");
            }

            return Multiply(lhs, rhs);
        }

        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null && rhs is null)
            {
                return true;
            }

            if (lhs is null)
            {
                return false;
            }

            if (rhs is null)
            {
                return false;
            }

            if (lhs.countOfCoefficients != rhs.countOfCoefficients)
            {
                return false;
            }

            for (int i = 0; i < lhs.countOfCoefficients; i++)
            {
                if (Math.Abs(lhs.coefficients[i] - rhs.coefficients[i]) > lhs.Epsilon)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// Add method.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="rhs">Second polynomial.</param>
        /// <returns>Sum of two polynomials.</returns>
        public static Polynomial Add(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(lhs), "cannot be null");
            }

            if (rhs is null)
            {
                throw new ArgumentNullException(nameof(rhs), "cannot be null");
            }

            int newLength = Math.Max(lhs.countOfCoefficients, rhs.countOfCoefficients);
            int minValue = Math.Min(lhs.countOfCoefficients, rhs.countOfCoefficients);
            double[] prod = new double[newLength];
            for (int i = 0; i < newLength; i++)
            {
                if (i < minValue)
                {
                    prod[i] = lhs.coefficients[i] + rhs.coefficients[i];
                }
                else
                {
                    prod[i] = lhs.coefficients.Length > rhs.coefficients.Length ? (prod[i] += lhs.coefficients[i]) : (prod[i] += rhs.coefficients[i]);
                }
            }

            return new Polynomial(prod);
        }

        /// <summary>
        /// Subtract method.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="rhs">Second polynomial.</param>
        /// <returns>subtraction of two polynomials.</returns>
        public static Polynomial Subtract(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(lhs), "cannot be null");
            }

            if (rhs is null)
            {
                throw new ArgumentNullException(nameof(rhs), "cannot be null");
            }

            int newLength = Math.Max(lhs.coefficients.Length, rhs.coefficients.Length);
            int minValue = Math.Min(lhs.coefficients.Length, rhs.coefficients.Length);
            double[] prod = new double[newLength];

            for (int i = 0; i < newLength; i++)
            {
                if (i < minValue)
                {
                    prod[i] = lhs.coefficients[i] - rhs.coefficients[i];
                }
                else
                {
                    prod[i] = lhs.coefficients.Length > rhs.coefficients.Length ? (prod[i] = lhs.coefficients[i]) : (prod[i] -= rhs.coefficients[i]);
                }
            }

            return new Polynomial(prod);
        }

        /// <summary>
        /// Multiply method.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="rhs">Second polynomial.</param>
        /// <returns>Multiplication if two polynomials.</returns>
        public static Polynomial Multiply(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(lhs), "cannot be null");
            }

            if (rhs is null)
            {
                throw new ArgumentNullException(nameof(rhs), "cannot be null");
            }

            int newLength = lhs.coefficients.Length + rhs.coefficients.Length - 1;
            double[] prod = new double[newLength];

            for (int i = 0; i < lhs.coefficients.Length; i++)
            {
                for (int j = 0; j < rhs.coefficients.Length; j++)
                {
                    prod[i + j] += lhs.coefficients[i] * rhs.coefficients[j];
                }
            }

            return new Polynomial(prod);
        }

        /// <summary>
        /// ToString override method.
        /// </summary>
        /// <returns>String representation of an object.</returns>
        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = this.coefficients.Length - 1; i >= 0; i--)
            {
                if (this.coefficients[i] == 0)
                {
                    continue;
                }

                result.Append($"{this.coefficients[i]}x^{i}");
            }

            return result.ToString();
        }

        /// <summary>
        /// GetHashCode override method.
        /// </summary>
        /// <returns>int value.</returns>
        public override int GetHashCode()
        {
            return this.countOfCoefficients.GetHashCode();
        }

        /// <summary>
        /// Equals override method.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>True(if two objects are equal) or false(otherwise).</returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            Polynomial polynomial = obj as Polynomial;

            return this.Equals(polynomial);
        }

        /// <summary>
        /// Equals method.
        /// </summary>
        /// <param name="polynomial">Polynomial.</param>
        /// <returns>True(if two objects are equal) or false(otherwise).</returns>
        public bool Equals(Polynomial polynomial)
        {
            if (polynomial is null)
            {
                return false;
            }

            if (ReferenceEquals(this, polynomial))
            {
                return true;
            }

            if (polynomial.countOfCoefficients != this.countOfCoefficients)
            {
                return false;
            }

            return this == polynomial;
        }

        /// <summary>
        /// Clone method.
        /// </summary>
        /// <returns>Creates a shalow copy of Polynomial.</returns>
        public object Clone() => this.MemberwiseClone();
    }
}

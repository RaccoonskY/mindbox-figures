using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figures_lib
{
    public class Triangle : IFigure
    {
        private double[] _sides = new double[3];

        public double SideA
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value of triangle side must be positive!");
                }
                _sides[0] = value;

            }
            get
            {
                return _sides[0];
            }
        }

        public double SideB
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value of triangle side must be positive!");
                }
                _sides[1] = value;

            }
            get
            {
                return _sides[1];
            }
        }

        public double SideC
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value of triangle side must be positive!");
                }
                _sides[2] = value;

            }
            get
            {
                return _sides[2];


            }
        }

        /// <summary>
        /// Constructor to initialize triangle instance using 3 numbers
        /// </summary>
        /// <param name="sideA">First side of triangle</param>
        /// <param name="sideB">Second side of triangle</param>
        /// <param name="sideC">Third side of triangle</param>
        public Triangle(double sideA, double sideB, double sideC) {
            if (!IfTriangleExists(sideA, sideB, sideC))
            {
                throw new ArgumentException("Such triangle cannot exist: sum of sides less than one.");
            }
            this.SideA = sideA;
            this.SideB = sideB;
            this.SideC = sideC; 
        }

        /// <summary>
        /// Constructor to initialize triangle instance using enumerable object 
        /// </summary>
        /// <param name="values">
        /// Enumerable object, containing values to initialize triangle sides
        /// (e.g. <seealso cref="List{T}"/>, <seealso cref="Array"/>)
        /// </param>
        /// <exception cref="ArgumentException">
        /// There must be more than 3 object in enumerable argunment 
        /// and
        /// Argument as side of triangle must be positive number (> 0)
        /// </exception>
        /// <example>
        /// <c>
        ///     var triangle = new Triangle(new []{1.0, 2.0 ,3.0});=
        /// </c>
        /// </example>
        public Triangle(IEnumerable<double> values)
        {
            if (!IfTriangleExists(values.ToArray()))
            {
                throw new ArgumentException("Such triangle cannot exist: sum of sides less than one.");
            }
            if (values.Count() < 3)
            {
                throw new ArgumentException("Number of sides must be more or equal 3.");
            }

            var curSideIterator = values.GetEnumerator();
            for (int i = 0;i < _sides.Length;i++) {
                curSideIterator.MoveNext();
                var curSide = curSideIterator.Current;
                _sides[i] = curSide > 0 ? curSide: throw new ArgumentException("Side of triangle must be positive (> 0) number");
               
            }
        }
        
        /// <summary>
        /// Static method to check if triangle exists with such side values: 
        ///     `every side must be less than sum of others`
        /// </summary>
        /// <param name="values">
        /// value to initialize the triangle sides
        /// </param>
        /// <returns>
        /// <see cref="bool"/> value:
        /// True - if exists
        /// False - if not
        /// </returns>
        static public bool IfTriangleExists(params double[] values)
        {
            //hardcoded
            return values[0] < values[1] + values[2]
                && values[1] < values[0] + values[2]
                && values[2] < values[0] + values[1];
            
        }

        /// <summary>
        /// Checks if triangle is right using Pifagor theorem
        /// </summary>
        /// <param name="values">
        /// Sides of triangle
        /// </param>
        /// <returns>
        /// True - is right
        /// False - is not
        /// </returns>
        static public bool IfTriangleIsRight(params double[] values)
        {
            //if there is more than 3 values applied
            var sides = new List<double> { values[0], values[1], values[2]};
            var maxSide = sides.Max();
            sides.Remove(maxSide);
            //As Pifagor said:
            return  Math.Pow(maxSide,2) == ( Math.Pow(sides[0],2) + Math.Pow(sides[1], 2) );
        }


        /// <summary>
        /// <see cref="IfTriangleIsRight(double[])"/>
        /// </summary>
        /// <returns>     
        /// True - is right
        /// False - is not
        /// </returns>
        public bool IfTriangleIsRight()
        {
            var sides = new List<double> { _sides[0], _sides[1], _sides[2]};
            var maxSide = sides.Max();
            sides.Remove(maxSide);
            return Math.Pow(maxSide, 2) == (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2));
        }

        public double GetArea()
        {
            var halfPerimeter = _sides.Sum() / 2;
            // area = (halfPerimeter * (hp - a) * (hp - b) * (hp - c) )^0.5
            var area = Math.Sqrt(
                halfPerimeter * _sides.
                Select(side => halfPerimeter - side).
                Aggregate((a,b) => a * b)
                );
            return area; 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace figures_lib
{
    /// <summary>
    /// Class symbolizes a circle with particular radius as <see cref="Radius"/> 
    /// </summary>
    /// <remarks>
    /// It's implementation of <seealso cref="IFigure"/> interface
    /// </remarks>
    public class Circle : IFigure
    {
        protected double _radius;
        public double Radius { 
            set { 
                if (value < 0)
                {
                    throw new ArgumentException("Radius of circle must be positive!");
                }
                _radius = value;
      
            } 
            get { 
                return _radius; 
            }
        }

        /// <summary>
        /// Constructor to create circle object with particluar radius
        /// </summary>
        /// <param name="radius">
        /// Radius of circle. 
        /// </param>
        /// <remarks>
        /// Used in method <seealso cref="GetArea"/> to calculate area of figure
        /// </remarks>
        public Circle(double radius) {
            
            this.Radius = radius;
        
        }
        public double GetArea()
        {
            var area = Math.PI * Math.Pow(_radius,2);
            return area;
        }
    }
}

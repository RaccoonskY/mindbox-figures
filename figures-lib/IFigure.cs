using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figures_lib
{
    /// <summary>
    /// Base interface for all figures
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Method to calculate the area of figure 
        /// </summary>
        /// <returns>
        /// Returns area of figure with type <see cref="double"/>
        /// </returns>
        double GetArea();
       

    }
}

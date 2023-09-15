using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using figures_lib;

namespace mindbox_figures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IFigure> figures = new List<IFigure>();

            figures.Add(new Circle(2.0));
            figures.Add(new Circle(5.6));

            figures.Add(new Triangle(5.0,4.0,2.0));
            figures.Add(new Triangle(new double[] {5.0, 2.0, 4.5}));


            foreach (var figure in figures)
            {
                Console.WriteLine(figure.GetArea());

            }
        }
    }
}

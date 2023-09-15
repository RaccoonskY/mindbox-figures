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




            foreach (var figure in figures)
            {
                Console.WriteLine(figure.GetArea());

            }
        }
    }
}

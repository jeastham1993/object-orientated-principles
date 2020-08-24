using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ObjectOrientated.Loops
{
    class Program
    {
	    private static IPainter FindCheapestPainterWithLoop(
		    double sqMetres,
		    IEnumerable<IPainter> painters)
	    {
		    var bestPrice = 0D;
		    IPainter cheapest = null;

		    foreach (var painter in painters)
		    {
			    if (painter.IsAvailable)
			    {
				    var price = painter.EstimateCompensation(sqMetres);

				    if ( cheapest == null || price < bestPrice)
				    {
					    cheapest = painter;
				    }
			    }
		    }

		    return cheapest;
	    }

	    private static IPainter FindCheapestPainter(
		    double sqMetres,
		    IEnumerable<IPainter> painters)
	    {
		    return painters
			    .Where(p => p.IsAvailable)
			    .WithMinimum(painter => painter.EstimateCompensation(sqMetres));
	    }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

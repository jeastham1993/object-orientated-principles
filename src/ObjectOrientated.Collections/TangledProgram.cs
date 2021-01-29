using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectOrientated.Collections
{
    class TangledProgram
    {
		// The use of IEnumerable is intentional, it hides the actual implementation behind the scenes
		// It could be a list, Dictionary, HashTable etc
	    private static IPainter FindCheapestPainter(
		    double sqMetres,
		    IEnumerable<IPainter> painters)
	    {
		    return painters
			    .Where(p => p.IsAvailable)
			    .WithMinimum(painter => painter.EstimateCompensation(sqMetres));
	    }

		// This method ALMOST looks the same but isn't quite.
	    private static IPainter FindFastestPainter(
		    double sqMetres,
		    IEnumerable<IPainter> painters)
	    {
		    return painters
			    .Where(p => p.IsAvailable)
			    .WithMinimum(painter => painter.EstimateTimeToPaint(sqMetres));
	    }

	    private static IPainter WorkTogether(
		    double sqMetres,
		    IEnumerable<IPainter> painters)
	    {
		    var time = TimeSpan.FromHours(
			    1 /
			    painters
				    .Where(p => p.IsAvailable)
				    .Select(painter => 1 / painter.EstimateTimeToPaint(sqMetres).TotalHours)
				    .Sum());

		    var totalToPay = painters.Where(p => p.IsAvailable)
			    .Select(
				    painter => painter.EstimateCompensation(sqMetres) /
				               painter.EstimateTimeToPaint(sqMetres).TotalHours *
				               time.TotalHours)
			    .Sum();

		    return new ProportionalPainter()
		    {
				TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMetres),
				DollarsPerHour = totalToPay / time.TotalHours,
		    };
	    }

        static void TangledMain(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

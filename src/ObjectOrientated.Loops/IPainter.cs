using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientated.Loops
{
    interface IPainter
    {
        bool IsAvailable { get; set; }

        TimeSpan EstimateTimeToPaint(
	        double sqMetres);

        double EstimateCompensation(
	        double sqMetres);
    }
}

using System;

namespace ObjectOrientated.Collections
{
    interface IPainter
    {
        bool IsAvailable { get; }

        TimeSpan EstimateTimeToPaint(
	        double sqMetres);

        double EstimateCompensation(
	        double sqMetres);
    }
}

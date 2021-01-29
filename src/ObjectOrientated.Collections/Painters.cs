// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ObjectOrientated.Collections
{
	class Painters
	{
		private IEnumerable<IPainter> ContainedPainters { get; }

		public Painters(
			IEnumerable<IPainter> painters)
		{
			this.ContainedPainters = painters;
		}

		public Painters GetAvailable() =>
			new Painters(this.ContainedPainters.Where(p => p.IsAvailable));

		public IPainter GetCheapestOne(
			double sqMetres) =>
			this.ContainedPainters.WithMinimum(p => p.EstimateCompensation(sqMetres));

		public IPainter GetFastestOne(
			double sqMetres) =>
			this.ContainedPainters.WithMinimum(p => p.EstimateTimeToPaint(sqMetres));
	}
}
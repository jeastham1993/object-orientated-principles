using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace ObjectOrientated.Collections
{
	class CompositePainter<TPainter> : IPainter 
		where TPainter : IPainter
	{
		private IEnumerable<TPainter> Painters { get; }

		private Func<double, IEnumerable<TPainter>, IPainter> Reduce { get; }
		
		public CompositePainter(
			IEnumerable<TPainter> painters,
			Func<double, IEnumerable<TPainter>, IPainter> reduce)
		{
			this.Painters = painters.ToList();
			this.Reduce = reduce;
		}

		/// <inheritdoc />
		public bool IsAvailable => this.Painters.Any(p => p.IsAvailable);

		/// <inheritdoc />
		public TimeSpan EstimateTimeToPaint(
			double sqMetres) => this.Reduce(sqMetres, this.Painters).EstimateTimeToPaint(sqMetres);

		/// <inheritdoc />
		public double EstimateCompensation(
			double sqMetres) => this.Reduce(sqMetres, this.Painters).EstimateCompensation(sqMetres);
	}
}
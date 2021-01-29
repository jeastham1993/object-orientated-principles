// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System;

namespace ObjectOrientated.Collections
{
	class ProportionalPainter : IPainter
	{
		/// <inheritdoc />
		public bool IsAvailable => true;

		public TimeSpan TimePerSqMeter { get; set; }

		public double DollarsPerHour { get; set; }

		/// <inheritdoc />
		public TimeSpan EstimateTimeToPaint(
			double sqMetres) => TimeSpan.FromHours(this.TimePerSqMeter.TotalHours * sqMetres);

		/// <inheritdoc />
		public double EstimateCompensation(
			double sqMetres) => this.EstimateTimeToPaint(sqMetres).TotalHours * this.DollarsPerHour;
	}
}
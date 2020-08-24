using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOrientated.Loops
{
    public static class EnumerableExtensions
    {
	    public static T WithMinimum<T, TKey>(
		    this IEnumerable<T> sequence,
		    Func<T, TKey> criterion)
		    where T : class
		    where TKey : IComparable<TKey> =>
		    sequence
				// Loop each input and run the criterion function, storing all the results in a Tuple
			    .Select(obj => Tuple.Create(obj, criterion(obj)))
				// Then aggregate them based on the the Item2 part of the Tuple
			    .Aggregate(
			    (Tuple<T, TKey>)null,
			    (
				    best,
				    cur) => best == null || cur.Item2.CompareTo(best.Item2) < 0 ? cur : best)
				// And return
			    .Item1;
    }
}

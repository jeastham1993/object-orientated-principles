using System;

namespace ObjectOrientated.BadCode
{
    class Program
    {
		// What starts our as a simple SUM method very quickly gets complex as requirements change
		// Customer - I only want to sum odd numbers (add a flag)
		// Customer - I want to be able to choose whether to only sum odd or everything
		// Customer - I want to be able to choose whether to only sum even numbers oe everything
		// etc etc
	    static int Sum(
		    int[] values,
		    bool oddNumbersOnly)
	    {
		    var sum = 0;

		    for (var i = 0; i < values.Length; i++)
		    {
				// THIS LINE IS THE PROBLEM - The decision on which numbers to include is static
				// when the customer wants updated logic, this just expands
				// what it is missing, is objects.
			    if (oddNumbersOnly || values[i] % 2 != 0)
			    {
				    sum += values[i];
			    }
		    }

		    return sum;
	    }

	    static void ShowIt(
		    string data)
	    {
		    string upper;

			// Guarding against null like this is a perfect sign of non-OOP
			// It's perfectly good advice to construct an object that represents nothing, then call a method on it
			// Maybe create an object called MaybeString, then call MaybeString.ToMaybeUpper()
		    if (data == null)
		    {
				upper = null;
		    }
		    else
		    {
			    upper = data.ToUpper();
		    }

		    Console.WriteLine(upper);
	    }

        static void Main(string[] args)
        {
	        Console.WriteLine("Hello World!");
        }
    }
}

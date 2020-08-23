using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientated.Branching
{
    class Active : IFreezable
    {
	    /// <inheritdoc />
	    public IFreezable Deposit()
	    {
		    throw new NotImplementedException();
	    }

	    /// <inheritdoc />
	    public IFreezable Withdraw()
	    {
		    throw new NotImplementedException();
	    }

	    /// <inheritdoc />
	    public IFreezable Freeze()
	    {
		    throw new NotImplementedException();
	    }
    }
}

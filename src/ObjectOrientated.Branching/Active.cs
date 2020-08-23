using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientated.Branching
{
    class Active : IFreezable
    {
	    private Action OnUnfreeze { get; }

	    public Active(
		    Action onUnfreeze)
	    {
		    this.OnUnfreeze = onUnfreeze;
	    }

	    /// <inheritdoc />
	    public IFreezable Deposit() => this;

	    /// <inheritdoc />
	    public IFreezable Withdraw() => this;

	    /// <inheritdoc />
	    public IFreezable Freeze() => new Frozen(this.OnUnfreeze);
    }
}

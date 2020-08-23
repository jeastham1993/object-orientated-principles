using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientated.Branching
{
    class NotVerified : IAccountState
    {
		private Action OnUnfreeze { get; set; }

	    public NotVerified(
		    Action onUnfreeze)
	    {
		    this.OnUnfreeze = onUnfreeze;
	    }

	    /// <inheritdoc />
	    public IAccountState Deposit(Action addToBalance)
	    {
		    addToBalance();

		    return this;
	    }

	    /// <inheritdoc />
	    public IAccountState Withdraw(Action subtractFromBalance) => this;

	    /// <inheritdoc />
	    public IAccountState Freeze() => this;

	    /// <inheritdoc />
	    public IAccountState Close() => new Closed();

	    /// <inheritdoc />
	    public IAccountState HolderVerified() => new Active(this.OnUnfreeze);
    }
}

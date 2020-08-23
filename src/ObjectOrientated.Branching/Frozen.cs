using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientated.Branching
{
    class Frozen : IAccountState
    {
		private Action OnUnfreeze { get; }

		public Frozen(
			Action onUnfreeze)
		{
			this.OnUnfreeze = onUnfreeze;
		}

	    /// <inheritdoc />
	    public IAccountState Deposit(Action addToBalance)
	    {
		    this.OnUnfreeze();

		    addToBalance();

		    return new Active(this.OnUnfreeze);
	    }

	    /// <inheritdoc />
	    public IAccountState Withdraw(Action subtractFromBalance)
	    {
		    this.OnUnfreeze();
		    subtractFromBalance();
		    return new Active(this.OnUnfreeze);
	    }

	    /// <inheritdoc />
	    public IAccountState Freeze() => this; // DO NOTHING because the account is already frozen.

	    /// <inheritdoc />
	    public IAccountState Close() => new Closed();

	    /// <inheritdoc />
	    public IAccountState HolderVerified() => this;
    }
}

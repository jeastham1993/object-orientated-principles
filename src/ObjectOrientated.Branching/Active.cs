﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientated.Branching
{
    class Active : IAccountState
    {
	    private Action OnUnfreeze { get; }

	    public Active(
		    Action onUnfreeze)
	    {
		    this.OnUnfreeze = onUnfreeze;
	    }

	    /// <inheritdoc />
	    public IAccountState Deposit(
		    Action addToBalance)
	    {
		    addToBalance();

		    return this;
	    }

	    /// <inheritdoc />
	    public IAccountState Withdraw(Action withdrawFromBalance)
	    {
		    withdrawFromBalance();

		    return this;
	    }

	    /// <inheritdoc />
	    public IAccountState Freeze() => new Frozen(this.OnUnfreeze);

	    /// <inheritdoc />
	    public IAccountState Close() => new Closed();

	    /// <inheritdoc />
	    public IAccountState HolderVerified() => this;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientated.Branching
{
	// Once closed, nothing can happen to an account.
	// Returning this is equivalent to doing nothing and just returning.
    class Closed : IAccountState
    {
	    /// <inheritdoc />
	    public IAccountState Deposit(Action addToBalance) => this;

	    /// <inheritdoc />
	    public IAccountState Withdraw(Action withdrawFromBalance) => this;

	    /// <inheritdoc />
	    public IAccountState Freeze() => this;

	    /// <inheritdoc />
	    public IAccountState Close() => this;

	    /// <inheritdoc />
	    public IAccountState HolderVerified() => this;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientated.Branching
{
    interface IAccountState
    {
        /// <summary>
        /// Deposit into the account.
        /// </summary>
        /// <returns>The new freezable state.</returns>
	    IAccountState Deposit(Action addToBalance);

        /// <summary>
        /// Withdraw from the account.
        /// </summary>
        /// <returns>The new freezable state.</returns>
	    IAccountState Withdraw(Action subtractFromBalance);

        /// <summary>
        /// Freeze the account.
        /// </summary>
        /// <returns>The new freezable state.</returns>
	    IAccountState Freeze();

        IAccountState Close();

        IAccountState HolderVerified();
    }
}

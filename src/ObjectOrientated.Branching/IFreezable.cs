using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientated.Branching
{
    interface IFreezable
    {
        /// <summary>
        /// Deposit into the account.
        /// </summary>
        /// <returns>The new freezable state.</returns>
	    IFreezable Deposit();

        /// <summary>
        /// Withdraw from the account.
        /// </summary>
        /// <returns>The new freezable state.</returns>
	    IFreezable Withdraw();

        /// <summary>
        /// Freeze the account.
        /// </summary>
        /// <returns>The new freezable state.</returns>
	    IFreezable Freeze();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientated.Branching
{
	/// Account class with all state moved into the interface.
	class AccountWithExtractedState
	{
		// This removes all logic relating to freezing and unfreezing, including state transition
		// It is all offloaded into implementations of the IFreezable interface.
		private IAccountState AccountState { get; set; }

		public AccountWithExtractedState(
			Action onUnfreeze)
		{
			this.AccountState = new NotVerified(onUnfreeze);
		}

		public decimal Balance { get; private set; }

		/// <summary>
		/// Deposit money into the account, this can only happen if the account is not closed.
		/// </summary>
		/// <param name="amount">The amount to deposit.</param>
		public void Deposit(
			decimal amount)
        {
	        // If a deposit is made to a frozen account it should be unfrozen and a custom action triggered
            this.AccountState = this.AccountState.Deposit(
	            () =>
	            {
		            this.Balance += amount;
	            });
        }

		/// <summary>
        /// Withdraw money from the account, this can only happen after the account has been verified.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        public void Withdraw(
			decimal amount)
		{
			// If a withdraw is made from a frozen account it should be unfrozen and a custom action triggered
			this.AccountState = this.AccountState.Withdraw(
				() =>
				{
					this.Balance -= amount;
				});
		}

		public void HolderVerified()
		{
			this.AccountState = this.AccountState.HolderVerified();
		}

		public void Close()
		{
			this.AccountState = this.AccountState.Close();
		}

		public void Freeze()
		{
			// When the account is frozen, change the manage unfreezing Action.
			this.AccountState = this.AccountState.Freeze();
		}
	}
}

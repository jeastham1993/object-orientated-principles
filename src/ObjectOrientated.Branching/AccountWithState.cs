using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientated.Branching
{
	// As more and more requirements are added a simple class will inevitably grow in complexity and lines of code
	// This also means many more tests written to keep up with the requirements
	// This is a better implementation of the InitialAccount class
	class AccountWithState
	{
		private bool IsVerified { get; set; }
		private bool IsClosed { get; set; }

		// This removes all logic relating to freezing and unfreezing, including state transition
		// It is all offloaded into implementations of the IFreezable interface.
		private IFreezable Freezeable { get; set; }

		public AccountWithState(
			Action onUnfreeze)
		{
			this.Freezeable = new Active(onUnfreeze);
		}

		public decimal Balance { get; private set; }

		/// <summary>
		/// Deposit money into the account, this can only happen if the account is not closed.
		/// </summary>
		/// <param name="amount">The amount to deposit.</param>
		public void Deposit(
			decimal amount)
        {
            if (this.IsClosed)
            {
                return;
            }

            // If a deposit is made to a frozen account it should be unfrozen and a custom action triggered
            this.Freezeable = this.Freezeable.Deposit();

            this.Balance += amount;
        }

		/// <summary>
        /// Withdraw money from the account, this can only happen after the account has been verified.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        public void Withdraw(
			decimal amount)
		{
			if (this.IsVerified == false)
			{
				return;
			}

			if (this.IsClosed)
			{
				return;
			}

			// If a withdraw is made from a frozen account it should be unfrozen and a custom action triggered
			this.Freezeable = this.Freezeable.Withdraw();

			this.Balance -= amount;
		}

		public void HolderVerified()
		{
			this.IsVerified = true;
		}

		public void Close()
		{
			this.IsClosed = true;
		}

		public void Freeze()
		{
			if (this.IsClosed)
			{
				return; // Account must not be closed.
			}

			if (this.IsVerified == false)
			{
				return; // Account must be verified.
			}

			// When the account is frozen, change the manage unfreezing Action.
			this.Freezeable = this.Freezeable.Freeze();
		}
	}
}

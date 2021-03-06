﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientated.Branching
{
	// As more and more requirements are added a simple class will inevitably grow in complexity and lines of code
	// This also means many more tests written to keep up with the requirements
	class InitialAccount
	{
		private bool IsVerified { get; set; }
		private bool IsClosed { get; set; }
		private bool IsFrozen { get; set; }
		private Action OnUnfreeze { get; }

		public InitialAccount(
			Action onUnfreeze)
		{
			this.OnUnfreeze = onUnfreeze;
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
			if (this.IsFrozen)
			{
				this.IsFrozen = false;
				this.OnUnfreeze();
			}

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
			if (this.IsFrozen)
			{
				this.IsFrozen = false;
				this.OnUnfreeze();
			}

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

			this.IsFrozen = true;
		}
	}
}

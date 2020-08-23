using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientated.Branching
{
    class Frozen : IFreezable
    {
		private Action OnUnfreeze { get; }

		public Frozen(
			Action onUnfreeze)
		{
			this.OnUnfreeze = onUnfreeze;
		}

	    /// <inheritdoc />
	    public IFreezable Deposit()
	    {
		    this.OnUnfreeze();

		    return new Active(this.OnUnfreeze);
	    }

	    /// <inheritdoc />
	    public IFreezable Withdraw()
	    {
		    this.OnUnfreeze();

			return new Active(this.OnUnfreeze);
	    }

	    /// <inheritdoc />
	    public IFreezable Freeze() => this; // DO NOTHING because the account is already frozen.
    }
}

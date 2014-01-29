using System;

namespace MonopolySharp
{
	// FixedDie is a Die that always returns the same value (passed in the constructor)

	public class FixedDie : Die
	{
		public FixedDie(int value) : base(0)
		{
			this.value = value;
		}

		public override int Roll ()
		{
			return value;
		}

		private int value;
	}
}


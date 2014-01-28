using System;

namespace MonopolySharp
{
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


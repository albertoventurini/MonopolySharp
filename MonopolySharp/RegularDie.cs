using System;

namespace MonopolySharp
{
	public class RegularDie : Die
	{
		public RegularDie () : base(6)
		{
			rnd = new Random();
		}

		public override int Roll()
		{
			return rnd.Next(1, base.n_faces+1);
		}

		private static Random rnd;
	}
}


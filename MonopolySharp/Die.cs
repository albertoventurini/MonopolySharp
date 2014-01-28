using System;

namespace MonopolySharp
{
	public abstract class Die
	{
		public Die (int n_faces = 6)
		{
			this.n_faces = n_faces;
		}

		public abstract int Roll();

		protected int n_faces;
	}
}


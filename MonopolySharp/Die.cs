using System;

namespace MonopolySharp
{
	// Die is an abstract class that represents a generic Die

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


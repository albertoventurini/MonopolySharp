using System;

namespace MonopolySharp
{
	public class Player
	{
		public Player (string name, Game game)
		{
			this.name = name;
			this.game = game;
			n_rounds = 0;
		}


		public void RollDieAndAdvance ()
		{
			int increment = game.GetDie().Roll();
			game.AdvancePlayerPosition(this, increment);
		}


		public void PlayRound ()
		{
			n_rounds++;
		}

		public string GetName()
		{
			return name;
		}

		public int GetRounds()
		{
			return n_rounds;
		}


		private string name;
		private Game game;
		private int n_rounds;

	}
}


using System;

namespace MonopolySharp
{
	public class Player
	{
		public Player (string name, Game game, Cell initCell)
		{
			this.name = name;
			this.game = game;
			this.myCell = initCell;
			n_rounds = 0;
		}


		public void RollDieAndAdvance ()
		{
			int increment = game.GetDie().Roll();

			myCell = game.GetBoard().Advance(myCell, increment);
		}


		public void PlayRound ()
		{
			RollDieAndAdvance();
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


		// Position property
		public int Position
		{
			get
			{
				return game.GetBoard().GetCellPosition(myCell);
			}

			set
			{
				Board b = game.GetBoard();
				myCell = b.Advance(b.Start(), value);
			}
		}


		private string name;
		private Game game;
		private Cell myCell;
		private int n_rounds;

	}
}


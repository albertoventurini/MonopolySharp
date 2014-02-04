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
			int incr = game.GetDie().Roll();

			Board board = game.GetBoard();
			for(int i = 0; i < incr; i++)
			{
				myCell = board.Advance(myCell, 1);

				// if (myCell is GO) ...
			}
		}


		public void PlayRound ()
		{
			RollDieAndAdvance();
			n_rounds++;
		}




		// Properties


		public int Position
		{
			get	{ return game.GetBoard().GetCellPosition(myCell); }
			set
			{
				Board b = game.GetBoard();
				myCell = b.Advance(b.Start(), value);
			}
		}


		public string Name
		{
			get { return name; }
		}


		public int Rounds
		{
			get { return n_rounds; }
		}


		private string name;
		private Game game;
		private Cell myCell;
		private int n_rounds;

	}
}


using System;
using System.Collections.Generic;


namespace MonopolySharp
{
	public class Game
	{
		public Game()
		{
			players = new List<Player>();
			playerPositions = new Dictionary<Player, Cell>();
			board = new Board(40);
			die = new RegularDie();
		}

		public void AddPlayer(string name)
		{

			Player p = new Player(name, this);

			if(players.Count != 0)
			{
				int rand_idx = ( new Random((int)DateTime.Now.Ticks).Next() ) % players.Count;
				players.Insert(rand_idx, p);
			}
			else
				players.Add(p);

			playerPositions.Add(p, board.Start());
		}

		public Die GetDie()
		{
			return die;
		}

		public void SetDie(Die die)
		{
			this.die = die;
		}

		public int GetPlayerPosition(Player p)
		{
			Cell cell = playerPositions[p];
			return board.GetCellPosition(cell);
		}

		public void SetPlayerPosition(Player p, int position)
		{
			playerPositions[p] = board.Advance(board.Start(), position);
		}

		public void AdvancePlayerPosition(Player p, int increment)
		{
			playerPositions[p] = board.Advance(playerPositions[p], increment);
		}

		public void Play()
		{
			if(players.Count < 2 || players.Count > 8)
				throw new Exception();

			for(int i = 0; i < RoundsPerGame; i++)
				PlayRound();
		}

		public void PlayRound()
		{
			foreach(Player p in players)
				p.PlayRound();

			n_rounds++;
		}


		public List<string> GetPlayerNames()
		{
			List<string> names = new List<string>();

			foreach(Player p in players)
				names.Add(p.GetName());

			return names;
		}

		public int GetRounds()
		{
			return n_rounds;
		}


		private const int RoundsPerGame = 20;

		public List<Player> players;
		private Dictionary<Player, Cell> playerPositions;
		private Board board;
		private Die die;
		private int n_rounds;
	}
}


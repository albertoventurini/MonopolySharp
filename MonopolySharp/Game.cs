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
			board = new Board(BoardSize);
			die = new RegularDie();
		}

		public void AddPlayer(string name)
		{

			Player p = new Player(name, this);

			// If there are already players,
			// then add the player at a random position
			if(players.Count != 0)
			{
				int rand_idx = ( new Random((int)DateTime.Now.Ticks).Next() ) % (players.Count + 1);
				players.Insert(rand_idx, p);
			}
			else
			// otherwise, just add the unique player to the list
				players.Add(p);

			playerPositions.Add(p, board.Start());
		}

		// Get the die
		public Die GetDie()
		{
			return die;
		}

		// Set the die
		public void SetDie(Die die)
		{
			this.die = die;
		}

		// Get an integer that represents the position of the player on the game board
		public int GetPlayerPosition(Player p)
		{
			Cell cell = playerPositions[p];
			return board.GetCellPosition(cell);
		}

		// Set the position of the player on the game board
		public void SetPlayerPosition(Player p, int position)
		{
			playerPositions[p] = board.Advance(board.Start(), position);
		}

		// Advance the position of the player by 'increment' cells
		public void AdvancePlayerPosition(Player p, int increment)
		{
			playerPositions[p] = board.Advance(playerPositions[p], increment);
		}

		// Play a full game
		public void Play()
		{
			if(players.Count < 2 || players.Count > 8)
				throw new Exception();

			for(int i = 0; i < RoundsPerGame; i++)
				PlayRound();
		}

		// Play one round of the game
		public void PlayRound()
		{
			foreach(Player p in players)
				p.PlayRound();

			n_rounds++;
		}

		// Return the list of player names
		public List<string> GetPlayerNames()
		{
			List<string> names = new List<string>();

			foreach(Player p in players)
				names.Add(p.GetName());

			return names;
		}

		// Return the number of rounds that were played
		public int GetRounds()
		{
			return n_rounds;
		}


		private const int RoundsPerGame = 20;
		private const int BoardSize = 40;

		public List<Player> players;
		private Dictionary<Player, Cell> playerPositions;
		private Board board;
		private Die die;
		private int n_rounds;
	}
}


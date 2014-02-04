using System;
using System.Collections.Generic;

//
// The Game class represents a Monopoly game.
//


namespace MonopolySharp
{
	public class Game
	{
		public Game()
		{
			players = new List<Player>();
			board = new Board(BoardSize);
			die = new RegularDie();
		}

		public void AddPlayer(string name)
		{
			// Create a new player with initial position = 0
			Player p = new Player(name, this, board.Start());
			p.Position = 0;

			// Add player to the game, maintaining a random order
			int rand_idx = ( new Random((int)DateTime.Now.Ticks).Next() ) % (players.Count + 1);
			players.Insert(rand_idx, p);
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


		public Board GetBoard()
		{
			return board;
		}


		private const int RoundsPerGame = 20;
		private const int BoardSize = 40;

		public List<Player> players;
		//private Dictionary<Player, Cell> playerPositions;
		private Board board;
		private Die die;
		private int n_rounds;
	}
}


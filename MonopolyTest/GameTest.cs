using System;
using MonopolySharp;
using NUnit.Framework;

using System.Collections.Generic;

namespace MonopolyTest
{
	[TestFixture]
	public class GameTest
	{
		[Test]
		public void create_a_game_with_two_players()
		{
			Game game = new Game();
			game.AddPlayer("Horse");
			game.AddPlayer("Car");

			List<string> names = game.GetPlayerNames();

			Assert.Contains("Horse", names);
			Assert.Contains("Car", names);
		}

		[Test]
		public void players_should_not_be_less_than_two_or_more_than_eight()
		{
			Game onePlayerGame = new Game();
			onePlayerGame.AddPlayer("Horse");

			Assert.Throws<Exception>( delegate { onePlayerGame.Play(); });

			Game ninePlayerGame = new Game();
			for(int i = 0; i < 9; i++)
				ninePlayerGame.AddPlayer("Player " + i.ToString());

			Assert.Throws<Exception>( delegate { ninePlayerGame.Play(); });

		}

		[Test]
		public void names_should_be_shuffled ()
		{
			int status = 0;
			for (int i = 0; i < 100; i++)
			{
				Game game = new Game ();
				game.AddPlayer ("Horse");
				game.AddPlayer ("Car");

				List<string> names = game.GetPlayerNames();
				if(names[0] == "Horse" && names[1] == "Car") status++;
				if(names[0] == "Car" && names[1] == "Horse") status++;

				if(status == 2) break;
			}

			Assert.AreEqual(2, status);

		}


		[Test]
		public void number_of_played_rounds_should_be_twenty()
		{
			Game game = new Game();
			game.AddPlayer("Horse");
			game.AddPlayer("Car");

			game.Play();

			Assert.AreEqual(20, game.GetRounds());

			foreach(Player p in game.players)
				Assert.AreEqual(20, p.GetRounds());
		}

		[Test]
		public void order_of_players_should_not_change_at_each_round ()
		{
			Game game = new Game ();
			game.AddPlayer ("Horse");
			game.AddPlayer ("Car");

			List<string> names = game.GetPlayerNames ();

			for (int i = 0; i < 20; i++)
			{
				game.PlayRound();
				Assert.AreEqual(game.GetPlayerNames()[0], names[0]);
				Assert.AreEqual(game.GetPlayerNames()[1], names[1]);
			}
		}
	}
}


using System;
using MonopolySharp;
using NUnit.Framework;

namespace MonopolyTest
{
	[TestFixture]
	public class PlayerTest
	{
		[Test]
		public void player_rolls_seven ()
		{
			Game game = new Game();
			game.AddPlayer("player1");

			game.SetDie(new FixedDie(7));

			Player p = game.players[0];
			p.RollDieAndAdvance();

			Assert.AreEqual(7, game.GetPlayerPosition(p));
		}

		[Test]
		public void player_on_thirtynine_rolls_six_and_should_end_up_in_five()
		{
			Game game = new Game();
			game.AddPlayer("player1");

			game.SetDie(new FixedDie(6));

			Player p = game.players[0];

			game.SetPlayerPosition(p, 39);
			p.RollDieAndAdvance();

			Assert.AreEqual(5, game.GetPlayerPosition(p));
		}
	}
}


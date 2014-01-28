using System;
using MonopolySharp;
using NUnit.Framework;

namespace MonopolyTest
{
	[TestFixture]
	public class BoardTest
	{

		[Test]
		public void setting_up_new_board_should_succeed ()
		{
			Assert.DoesNotThrow (() => {
				new Board (40); });
		}


		[Test]
		public void getting_start_cell_should_succeed ()
		{
			Board board = new Board(40);

			Cell cell;
			Assert.DoesNotThrow( () => {cell = board.Start(); } );

			cell = board.Start();
			Assert.AreEqual(0, board.GetCellPosition(cell));
		}

		[Test]
		public void advancing_on_board_should_succeed()
		{
			Board board = new Board(40);

			Cell newcell = board.Advance(board.Start(), 10);
			Assert.AreEqual(10, board.GetCellPosition(newcell));

		}

	}
}


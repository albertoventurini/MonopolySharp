using System;
using System.Collections.Generic;



namespace MonopolySharp
{
	public class Board
	{
		public Board (int n_cells)
		{
			cells = new List<Cell>(n_cells);

			for(int i = 0; i < n_cells; i++)
				cells.Add(new Cell());
		}

		public int GetCellPosition(Cell cell)
		{
			return cells.IndexOf(cell);
		}

		public Cell Start()
		{
			return cells[0];
		}

		public Cell Advance(Cell current, int increment)
		{
			int idx = (GetCellPosition(current) + increment) % cells.Count;
			return cells[idx];
		}

		private List<Cell> cells;
	}
}


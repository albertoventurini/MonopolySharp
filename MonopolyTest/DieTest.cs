using System;
using MonopolySharp;
using NUnit.Framework;

namespace MonopolyTest
{
	[TestFixture]
	public class DieTest
	{

		[Test]
		public void test_regular_die()
		{
			Die die = new RegularDie();

			// A regular die should roll between 1 and 6

			for(int i = 0; i < 50; i++)
			{
				Assert.GreaterOrEqual(die.Roll(), 1);
				Assert.LessOrEqual(die.Roll(), 6);
			}
		}

		[Test]
		public void test_fixed_die ()
		{
			for (int i = 0; i < 50; i++)
			{
				Die die = new FixedDie (i);
				Assert.AreEqual (die.Roll (), i);
			}
		}

	}
}


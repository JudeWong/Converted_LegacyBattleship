using System;
using NUnit.Framework;
namespace BattleShips
{
	[TestFixture]
	public class LauYiChengUnitTest
	{
		[Test]
		public void NumberOfShotsTest ()
		{
			AttackResult ar = new AttackResult (ResultOfAttack.Hit, "", 4, 4);
			ResultOfAttack result = new ResultOfAttack ();
			int count = 0;

			///condition to add the count
			if (result == ResultOfAttack.Hit || result == ResultOfAttack.Destroyed) {
				count += 1;
			} else if (result == ResultOfAttack.Miss || result == ResultOfAttack.ShotAlready) {
				count += 0;
			}

			///testing the counts
			Assert.AreEqual (0, count);

			result = ResultOfAttack.Hit;
			Assert.AreEqual (1, count);

			result = ResultOfAttack.ShotAlready;
			result = ResultOfAttack.Miss;
			Assert.AreEqual (1, count);

			result = ResultOfAttack.Hit;
			result = ResultOfAttack.Destroyed;
			Assert.AreEqual (3, count);
		}
	}
}

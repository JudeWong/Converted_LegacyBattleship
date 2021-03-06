﻿using System;
using NUnit.Framework;
using SwinGameSDK;

namespace BattleShips
{
	[TestFixture()]
	public class DeploymentControllerTest
	{
		[Test()]
		public void TestDeplomentOfShip ()
		{
			Point2D mouse = default (Point2D);

			mouse = SwinGame.PointAt (500, 500);

			int row = 0;
			int col = 0;

			//bug during deployment of ship
			row = Convert.ToInt32 (Math.Floor ((mouse.Y) / (UtilityFunctions.CELL_HEIGHT + UtilityFunctions.CELL_GAP)));
			col = Convert.ToInt32 (Math.Floor ((mouse.X - UtilityFunctions.FIELD_LEFT) / (UtilityFunctions.CELL_WIDTH + UtilityFunctions.CELL_GAP)));

			Assert.AreEqual (11, row);
			Assert.AreEqual (3, col);

			row = Convert.ToInt32 (Math.Floor ((mouse.Y - UtilityFunctions.FIELD_TOP) / (UtilityFunctions.CELL_HEIGHT + UtilityFunctions.CELL_GAP)));
			col = Convert.ToInt32 (Math.Floor ((mouse.X - UtilityFunctions.FIELD_LEFT) / (UtilityFunctions.CELL_WIDTH + UtilityFunctions.CELL_GAP)));

			Assert.AreEqual (9, row);
			Assert.AreEqual (3, col);
		}
	}
}

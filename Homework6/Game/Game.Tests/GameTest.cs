using NUnit.Framework;
using Game;

using System;
using System.IO;
using System.Reflection;

namespace Game.Tests
{
    public class GameTest
    {

        [Test]
        public void PositionAfterLeftAndRightMovementsShallRemainSame()
        {
            var game = new Game("../../../../Game.Tests/MapTest.txt");
            (int, int) initPosition = game.position;
            game.OnLeft(this, EventArgs.Empty);
            game.OnRight(this, EventArgs.Empty);
            Assert.AreEqual(initPosition, game.position);
        }

        [Test]
        public void PositionAfterUpAndDownMovementsShallRemainSame()
        {
            var game = new Game("../../../../Game.Tests/MapTest.txt");
            (int, int) initPosition = game.position;
            game.OnDown(this, EventArgs.Empty);
            game.OnUp(this, EventArgs.Empty);
            Assert.AreEqual(initPosition, game.position);
        }

        [Test]
        public void PositionAfterUpAndRightMovementsShallChanges()
        {
            var game = new Game("../../../../Game.Tests/MapTest.txt");
            (int, int) initPosition = game.position;
            game.OnUp(this, EventArgs.Empty);
            game.OnRight(this, EventArgs.Empty);
            Assert.AreEqual((initPosition.Item1 + 1, initPosition.Item2 - 1), game.position);
        }

        [Test]
        public void PositionAfterDownAndLeftMovementsShallChanges()
        {
            var game = new Game("../../../../Game.Tests/MapTest.txt");
            (int, int) initPosition = game.position;
            game.OnLeft(this, EventArgs.Empty);
            game.OnDown(this, EventArgs.Empty);
            Assert.AreEqual((initPosition.Item1 - 1, initPosition.Item2 + 1), game.position);
        }

    }
}
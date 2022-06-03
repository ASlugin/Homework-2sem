namespace Game.Tests;

using NUnit.Framework;
using System;
using System.IO;

public class GameTest
{
    private Game? game;

    [SetUp]
    public void CreateNewGame()
    {
        game = new Game("../../../../Game.Tests/MapTest.txt");
    }

    [Test]
    public void PositionAfterLeftAndRightMovementsShallRemainSame()
    {
        (int, int) initPosition = game!.GetPosition();
        game.OnLeft(this, EventArgs.Empty);
        game.OnRight(this, EventArgs.Empty);
        Assert.AreEqual(initPosition, game.GetPosition());
    }

    [Test]
    public void PositionAfterUpAndDownMovementsShallRemainSame()
    {
        (int, int) initPosition = game!.GetPosition();
        game.OnDown(this, EventArgs.Empty);
        game.OnUp(this, EventArgs.Empty);
        Assert.AreEqual(initPosition, game.GetPosition());
    }

    [Test]
    public void PositionAfterUpAndRightMovementsShallChanges()
    {
        (int, int) initPosition = game!.GetPosition();
        game.OnUp(this, EventArgs.Empty);
        game.OnRight(this, EventArgs.Empty);
        Assert.AreEqual((initPosition.Item1 + 1, initPosition.Item2 - 1), game.GetPosition());
    }

    [Test]
    public void PositionAfterDownAndLeftMovementsShallChanges()
    {
        (int, int) initPosition = game!.GetPosition();
        game.OnLeft(this, EventArgs.Empty);
        game.OnDown(this, EventArgs.Empty);
        Assert.AreEqual((initPosition.Item1 - 1, initPosition.Item2 + 1), game.GetPosition());
    }
}
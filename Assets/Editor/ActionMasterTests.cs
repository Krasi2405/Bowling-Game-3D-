using UnityEngine;
using UnityEditor;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest
{

    private ActionMaster actionMaster;

    [SetUp]
    public void Setup()
    {
        actionMaster = new ActionMaster();
    }

    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnsEndTurn()
    {
        Assert.AreEqual(ActionMaster.Action.EndTurn, actionMaster.Bowl(10));
    }

    [Test]
    public void T02Bowl8ReturnsTidy()
    {
        Assert.AreEqual(ActionMaster.Action.Tidy, actionMaster.Bowl(8));
    }

    [Test]
    public void T03Bowl28ReturnsEndTurn()
    {
        Assert.AreEqual(ActionMaster.Action.Tidy, actionMaster.Bowl(1));
        Assert.AreEqual(ActionMaster.Action.EndTurn, actionMaster.Bowl(8));
    }

    [Test]
    public void T04LastBowlReturnsGameEndIfNot10()
    {
        for (int i = 1; i < 20; i++)
        {
            actionMaster.Bowl(1);
        }
        Assert.AreEqual(ActionMaster.Action.EndGame, actionMaster.Bowl(2));
    }

    [Test]
    public void T05Allow21stBowlIf20thIsStrike()
    {
        for (int i = 1; i < 19; i++)
        {
            actionMaster.Bowl(1);
        }
        Assert.AreEqual(ActionMaster.Action.Reset, actionMaster.Bowl(10));
        Assert.AreEqual(ActionMaster.Action.Tidy, actionMaster.Bowl(2));
        Assert.AreEqual(ActionMaster.Action.EndGame, actionMaster.Bowl(8));
    }

    [Test]
    public void T06ResetIfStrike()
    {
        Assert.AreEqual(ActionMaster.Action.EndTurn, actionMaster.Bowl(10));
        // Skips the next turn because of strike so no end turn.
        Assert.AreEqual(ActionMaster.Action.Tidy, actionMaster.Bowl(2));
    }

    [Test]
    public void T07EndTurnIfSecondStrike()
    {
        Assert.AreEqual(ActionMaster.Action.Tidy, actionMaster.Bowl(1));
        // Skips the next turn because of strike so no end turn.
        Assert.AreEqual(ActionMaster.Action.EndTurn, actionMaster.Bowl(9));
    }

    [Test]
    public void T08NathanBowlIndexTest()
    {
        Assert.AreEqual(ActionMaster.Action.Tidy, actionMaster.Bowl(0));
        Assert.AreEqual(ActionMaster.Action.EndTurn, actionMaster.Bowl(10));

        Assert.AreEqual(ActionMaster.Action.Tidy, actionMaster.Bowl(3));

        Assert.AreEqual(ActionMaster.Action.EndTurn, actionMaster.Bowl(7));
    }
}
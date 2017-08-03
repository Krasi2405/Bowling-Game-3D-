using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class ActionMasterTest
{
    private List<int> bowls;


    [SetUp]
    public void Setup()
    {
        bowls = new List<int>();
    }

    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnsEndTurn()
    {
        bowls.Add(10);
        Assert.AreEqual(ActionMaster.Action.EndTurn, ActionMaster.GetAction(bowls));
    }

    [Test]
    public void T02Bowl8ReturnsTidy()
    {
        bowls.Add(8);
        Assert.AreEqual(ActionMaster.Action.Tidy, ActionMaster.GetAction(bowls));
    }

    [Test]
    public void T03Bowl28ReturnsEndTurn()
    {
        bowls.Add(1);
        Assert.AreEqual(ActionMaster.Action.Tidy, ActionMaster.GetAction(bowls));
        bowls.Add(8);
        Assert.AreEqual(ActionMaster.Action.EndTurn, ActionMaster.GetAction(bowls));
    }

    [Test]
    public void T04LastBowlReturnsGameEndIfNot10()
    {
        for (int i = 1; i < 20; i++)
        {
            bowls.Add(1);
        }
        bowls.Add(2);
        Assert.AreEqual(ActionMaster.Action.EndGame, ActionMaster.GetAction(bowls));
    }

    [Test]
    public void T05Allow21stBowlIf20thIsStrike()
    {
        for (int i = 1; i < 19; i++)
        {
            bowls.Add(1);
        }
        bowls.Add(10);
        Assert.AreEqual(ActionMaster.Action.Reset, ActionMaster.GetAction(bowls));
        bowls.Add(2);
        Assert.AreEqual(ActionMaster.Action.Tidy, ActionMaster.GetAction(bowls));
        bowls.Add(8);
        Assert.AreEqual(ActionMaster.Action.EndGame, ActionMaster.GetAction(bowls));
    }

    [Test]
    public void T06ResetIfStrike()
    {
        bowls.Add(10);
        Assert.AreEqual(ActionMaster.Action.EndTurn, ActionMaster.GetAction(bowls));
        // Skips the next turn because of strike so no end turn.
        bowls.Add(2);
        Assert.AreEqual(ActionMaster.Action.Tidy, ActionMaster.GetAction(bowls));
    }

    [Test]
    public void T07EndTurnIfSecondStrike()
    {
        bowls.Add(1);
        Assert.AreEqual(ActionMaster.Action.Tidy, ActionMaster.GetAction(bowls));
        // Skips the next turn because of strike so no end turn.
        bowls.Add(9);
        Assert.AreEqual(ActionMaster.Action.EndTurn, ActionMaster.GetAction(bowls));
    }

    [Test]
    public void T08NathanBowlIndexTest()
    {
        bowls.Add(0);
        Assert.AreEqual(ActionMaster.Action.Tidy, ActionMaster.GetAction(bowls));
        bowls.Add(10);
        Assert.AreEqual(ActionMaster.Action.EndTurn, ActionMaster.GetAction(bowls));
        bowls.Add(3);
        Assert.AreEqual(ActionMaster.Action.Tidy, ActionMaster.GetAction(bowls));
        bowls.Add(7);
        Assert.AreEqual(ActionMaster.Action.EndTurn, ActionMaster.GetAction(bowls));
    }
}
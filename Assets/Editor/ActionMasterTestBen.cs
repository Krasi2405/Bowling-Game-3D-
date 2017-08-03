using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTestBen {
    



	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;


    private List<int> bowls;


    [SetUp]
    public void Setup()
    {
        bowls = new List<int>();
    }

	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01OneStrikeReturnsEndTurn () {
        bowls.Add(10);
		Assert.AreEqual (endTurn, ActionMaster.GetAction(bowls));
	}

	[Test]
	public void T02Bowl8ReturnsTidy () {
        bowls.Add(8);
		Assert.AreEqual (tidy, ActionMaster.GetAction(bowls));
	}

	[Test]
	public void T04Bowl28SpareReturnsEndTurn () {
        bowls.Add(2);
        bowls.Add(8);
		Assert.AreEqual (endTurn, ActionMaster.GetAction(bowls));
	}

	[Test]
	public void T05CheckResetAtStrikeInLastFrame () {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach (int roll in rolls) {
            bowls.Add(roll);
		}
        bowls.Add(10);
		Assert.AreEqual (reset, ActionMaster.GetAction(bowls));
	}

	[Test]
	public void T06CheckResetAtSpareInLastFrame () {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach (int roll in rolls) {
            bowls.Add(roll);
		}
        bowls.Add(1);
        bowls.Add(9);
		Assert.AreEqual (reset, ActionMaster.GetAction(bowls));
	}

	[Test]
	public void T07YouTubeRollsEndInEndGame () {
		int[] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2};
		foreach (int roll in rolls) {
            bowls.Add(roll);
		}
        bowls.Add(9);
		Assert.AreEqual (endGame, ActionMaster.GetAction(bowls));
	}

	[Test]
	public void T08GameEndsAtBowl20 () {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1};
		foreach (int roll in rolls) {
            bowls.Add(roll);
		}
        bowls.Add(1);
		Assert.AreEqual (endGame, ActionMaster.GetAction(bowls));
	}

    [Test]
    public void T09Bowl20Test()
    {
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
        foreach (int roll in rolls)
        {
            bowls.Add(roll);
        }
        bowls.Add(10);
        Assert.AreEqual(reset, ActionMaster.GetAction(bowls));
        bowls.Add(2);
        Assert.AreEqual(tidy, ActionMaster.GetAction(bowls));
    }

    [Test]
    public void T10Bowl20TestWith0()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            bowls.Add(roll);
        }
        bowls.Add(10);
        Assert.AreEqual(reset, ActionMaster.GetAction(bowls));
        bowls.Add(0);
        Assert.AreEqual(tidy, ActionMaster.GetAction(bowls));
    }
    
    [Test]
    public void T11DondiTest()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            bowls.Add(roll);
        }
        bowls.Add(10);
        Assert.AreEqual(reset, ActionMaster.GetAction(bowls));
        bowls.Add(10);
        Assert.AreEqual(reset, ActionMaster.GetAction(bowls));
        bowls.Add(10);
        Assert.AreEqual(endGame, ActionMaster.GetAction(bowls));
    }
}
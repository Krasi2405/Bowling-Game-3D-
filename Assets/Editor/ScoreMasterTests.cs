using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[TestFixture]
public class ScoreMasterTests : MonoBehaviour {

    
	[Test]
    public void T00CanAddScores()
    {
        int[] rolls = {2, 7};
        Assert.AreEqual(9, ScoreMaster.GetTotalScore(rolls.ToList()));
    }

    [Test]
    public void T01HandleSpare()
    {
        int[] rolls = {2,8, 7,0};
        Assert.AreEqual(24, ScoreMaster.GetTotalScore(rolls.ToList()));
    }


    [Test]
    public void T02HandleThreeSparesInARoll()
    {
        int[] rolls = {2,8, 3,7, 8,2, 1, 0};
        Assert.AreEqual(43, ScoreMaster.GetTotalScore(rolls.ToList()));
    }


    [Test]
    public void T03HandleStrike()
    {
        int[] rolls = {10, 2,8};
        Assert.AreEqual(30, ScoreMaster.GetTotalScore(rolls.ToList()));
    }


    [Test]
    public void T04HandleStrikeAndSpare()
    {
        int[] rolls = {10, 2,8, 4,4};
        Assert.AreEqual(42, ScoreMaster.GetTotalScore(rolls.ToList()));
    }

    [Test]
    public void T05HandleThreeStrikesInARoll()
    {
        int[] rolls = {10, 10, 10, 1,3};
        Assert.AreEqual(69, ScoreMaster.GetTotalScore(rolls.ToList()));

    }

    
    [Test]
    public void T06YoutubeSampleGameNoEnding()
    {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2};
        Assert.AreEqual(161, ScoreMaster.GetTotalScore(rolls.ToList()));
    }


    [Test]
    public void T07YoutubeSampleGame()
    {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9};
        Assert.AreEqual(170, ScoreMaster.GetTotalScore(rolls.ToList()));
    }


    [Test]
    public void T08AllStrikes()
    {
        int[] rolls = {10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10};
        Assert.AreEqual(300, ScoreMaster.GetTotalScore(rolls.ToList()));
    }

    [Test]
    public void T09AllGutterballs()
    {
        int[] rolls = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        Assert.AreEqual(0, ScoreMaster.GetTotalScore(rolls.ToList()));
    }
}

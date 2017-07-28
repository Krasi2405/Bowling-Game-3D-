//using system;
//using system.collections.generic;
//using nunit.framework;
//using unityengine;
//using system.linq;

//[testfixture]
//public class ourscoredisplaytest
//{

//    [test]
//    public void t00passingtest()
//    {
//        assert.areequal(1, 1);
//    }

//    [test]
//    public void t01bowl1()
//    {
//        int[] rolls = { 1 };
//        string rollsstring = "1";
//        assert.areequal(rollsstring, scoredisplay.formatrolls(rolls.tolist()));
//    }

//    [test]
//    public void t02bowlx()
//    {
//        int[] rolls = { 10 };
//        string rollsstring = "x "; // remember the space
//        assert.areequal(rollsstring, scoredisplay.formatrolls(rolls.tolist()));
//    }

//    [test]
//    public void t03bowl19()
//    {
//        int[] rolls = { 1, 9 };
//        string rollsstring = "1/"; // remember the space
//        assert.areequal(rollsstring, scoredisplay.formatrolls(rolls.tolist()));
//    }

//    [test]
//    public void t04bowlstrikeinlastframe()
//    {
//        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 1 };
//        string rollsstring = "111111111111111111x11"; // remember the space
//        assert.areequal(rollsstring, scoredisplay.formatrolls(rolls.tolist()));
//    }

//    [test]
//    public void t05bowl0()
//    {
//        int[] rolls = { 0 };
//        string rollsstring = "-"; // remember the space
//        assert.areequal(rollsstring, scoredisplay.formatrolls(rolls.tolist()));
//    }



//    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
//    [category("verification")]
//    [test]
//    public void tg01goldencopyb1of3()
//    {
//        int[] rolls = { 10, 9, 1, 9, 1, 9, 1, 9, 1, 7, 0, 9, 0, 10, 8, 2, 8, 2, 10 };
//        string rollsstring = "x 9/9/9/9/7-9-x 8/8/x";
//        assert.areequal(rollsstring, scoredisplay.formatrolls(rolls.tolist()));
//    }

//    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
//    [category("verification")]
//    [test]
//    public void tg02goldencopyb2of3()
//    {
//        int[] rolls = { 8, 2, 8, 1, 9, 1, 7, 1, 8, 2, 9, 1, 9, 1, 10, 10, 7, 1 };
//        string rollsstring = "8/819/718/9/9/x x 71";
//        assert.areequal(rollsstring, scoredisplay.formatrolls(rolls.tolist()));
//    }

//    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
//    [category("verification")]
//    [test]
//    public void tg03goldencopyb3of3()
//    {
//        int[] rolls = { 10, 10, 9, 0, 10, 7, 3, 10, 8, 1, 6, 3, 6, 2, 9, 1, 10 };
//        string rollsstring = "x x 9-x 7/x 8163629/x";
//        assert.areequal(rollsstring, scoredisplay.formatrolls(rolls.tolist()));
//    }

//    // http://brownswick.com/wp-content/uploads/2012/06/openbowlingscores-6-12-12.jpg
//    [category("verification")]
//    [test]
//    public void tg04goldencopyc1of3()
//    {
//        int[] rolls = { 7, 2, 10, 10, 10, 10, 7, 3, 10, 10, 9, 1, 10, 10, 9 };
//        string rollsstring = "72x x x x 7/x x 9/xx9";
//        assert.areequal(rollsstring, scoredisplay.formatrolls(rolls.tolist()));
//    }

//    // http://brownswick.com/wp-content/uploads/2012/06/openbowlingscores-6-12-12.jpg
//    [category("verification")]
//    [test]
//    public void tg05goldencopyc2of3()
//    {
//        int[] rolls = { 10, 10, 10, 10, 9, 0, 10, 10, 10, 10, 10, 9, 1 };
//        string rollsstring = "x x x x 9-x x x x x91";
//        assert.areequal(rollsstring, scoredisplay.formatrolls(rolls.tolist()));
//    }

//}
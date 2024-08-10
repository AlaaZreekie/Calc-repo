using API;
using FluentAssertions;
using Microsoft.VisualBasic;


namespace TestCalc;

public class UnitTest1
{

    //static private readonly Expression _res;

    public void NetworkServiceTests()
    {
        
        //_res = new Expression("");
    }
    [Fact]
    public void TestExpression()
    {

        var expected = new Expression("1+1+2");
        double ans = expected.Evaluate();
        var result = expected.Evaluate();
        Console.WriteLine("result is ------------------ :" + result);


        Assert.Equal<double>(4,result);
        //equal for string
    }
    [Fact]
    public void TestBigExpression()
    {

        var expected = new Expression("1+2*5+3*0");
        double ans = expected.Evaluate();
        var result = expected.Evaluate();
        Console.WriteLine("result is ------------------ :" + result);


        Assert.Equal<double>(11,result);
        //equal for string
    }

    [Fact]
    public void TestBigExpressionwithPracket()
    {

        var expected = new Expression("(1+2)*5+3*0");
        double ans = expected.Evaluate();
        var result = expected.Evaluate();
        Console.WriteLine("result is ------------------ :" + result);


        Assert.Equal<double>(15,result);
        //equal for string
    }


    [Fact]
    public void TestBigExpressionwithPracket2()
    {

        var expected = new Expression("(1+2)-1*5+3*0");
        double ans = expected.Evaluate();
        var result = expected.Evaluate();
        Console.WriteLine("result is ------------------ :" + result);


        Assert.Equal<double>(-2,result);
        //equal for string
    }


    [Fact]
    public void plusWithMinus()
    {

        var expected = new Expression("1-1+1-1+1-1");
        double ans = expected.Evaluate();
        var result = expected.Evaluate();
        Console.WriteLine("result is ------------------ :" + result);


        Assert.Equal<double>(0,result);
        //equal for string
    }

}
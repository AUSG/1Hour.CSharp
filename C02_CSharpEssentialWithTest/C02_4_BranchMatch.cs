using System;
using Xunit;

namespace C02_CSharpEssentialWithTest;

public class C02_4_BranchMatch
{
    record ValueObject(string Name, int Age);

    [Fact]
    public void IfTest()
    {
        ValueObject vo = new("Hi", 20);

        // Basic If
        if (vo.Name == "HI" && vo.Age == 20)
        {
            // Ok
        }

        // Recursive pattern
        if (vo is {Name: "Hi", Age: 20})
        {
            // Ok
        }

        // Negative pattern
        if (vo is not {Name: "Hi", Age: 20}) // simpler than vo.Name == "HI" && vo.Age == 20
        {
            // Ok
        }

        if (vo.Age >= 10 && vo.Age < 20)
        {
            // Ok
        }

        if (vo.Age is >= 10 and < 20)
        {
            // More simpler
        }

        if (vo is {Age: > 10 and <= 20}) // ㅋㅋ
        {
            // Good
        }

        vo = null;

        if (vo?.Age > 20) // always false
        {
            // Ok
        }

        // default value of int is zero(0)
        if ((vo?.Age ?? default) > 20)
        {
            // Ok
        }

        if (vo is {Age: > 20}) // same with vo != null && vo.Age > 20
        {
            // Ok
        }

        if (vo!.Age > 20) // ! is to notify compiler it's not null.
        {
            // Error NRE
        }
    }



    [Fact]
    public void PatternMatch()
    {
        ICommand command = default;
        var test = command switch
        {
            CommandOne commandOne => 1,
            CommandThree commandThree => 2,
            CommandTwo commandTwo => 3
        };
    }

    [Fact]
    public void PatternMatchOnIf()
    {
        object obj = 1;

        if (obj is int score)
        {
            // ok score
        }
    }

    [Fact]
    public void PatternMatchOnSwitch()
    {
        var score = 100;

        var grade = score switch
        {
            < 50 => "F",
            < 60 => "D",
            < 70 => "C",
            < 80 => "B",
            < 90 => "A",
            <= 100 => "S",
            _ => throw new InvalidOperationException()
        };
    }
}

internal interface ICommand
{
}

internal class CommandOne : ICommand
{
    public int GetOne() => 1;
}

internal class CommandTwo : ICommand
{
}

internal class CommandThree : ICommand
{
}
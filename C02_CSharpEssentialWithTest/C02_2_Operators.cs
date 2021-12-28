using System;
using Xunit;

namespace C02_CSharpEssentialWithTest;

public class C02_2_Operators
{
    [Fact]
    public void SameTypeAdd()
    {
        var a = 1;
        var b = 2;
        
        Assert.Equal(3, a + b);
    }

    [Fact]
    public void AddWithString()
    {
        var hi = "hi";
        var b = false;
        var i = 123;
        
        Assert.Equal("hiFalse123", hi + b + i); // implicit cast to String with using ToString
    }

    [Fact]
    public void DifferenceTypesAdd()
    {
        var b = false;
        var i = 123;
        
        // b + i; compile error!
    }
    
    // and + - / * && & || | operators are exist like other languages.
}
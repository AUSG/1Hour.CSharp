using Xunit;

namespace C02_CSharpEssentialWithTest;

public class C02_1_Types
{
    [Fact]
    public void NumberDefaultTypes()
    {
        var intVal = 0; // Default integer type is int
        var doubleVal = 0.123; // Default decimal type is double
        
        Assert.IsType<int>(intVal);
        Assert.IsType<double>(doubleVal);
    }

    [Fact]
    public void NumberTypes()
    {
        int i = 0;
        long l = 1;
        uint ui = 2;
        ulong ul = 3;
        float f = 1.5F;
        double d = 1.5;
        decimal de = new(1.5);
    }

    [Fact]
    public void StringTest()
    {
        var str = "hi"; // string
        var interpolation = $"{str} csharp";
        
        Assert.Equal("hi csharp", interpolation);
    }

    [Fact]
    public void OtherTypes()
    {
        bool test = true;
        char character = 'c';
        byte b = 255;
    }
}
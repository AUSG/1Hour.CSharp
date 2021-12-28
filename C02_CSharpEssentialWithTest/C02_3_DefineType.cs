using System;
using Xunit;

namespace C02_CSharpEssentialWithTest;

public class C02_3_DefineType
{

    #region Interface Class Definition

    

    // Define class
    class A
    {
    }
    
    // Define Interface
    interface IA
    {
    }

    // Inherit class  
    class B : A
    {
    }
    
    // Implment interface
    class ConcreteA : IA
    {
    }
    
    // Define field
    class DefineField
    {
        public string A = "Default";
    }
    
    // Define setter and getter with property
    class DefineFieldWithProperty
    {
        private string _a = "Default"; // Underscore(_) prefix is convention for private fields
        
        public string A
        {
            get => _a;
            internal set => _a = value; // public property but set is only allowed to call on internal(Project).
        }
    }
    
    // Define field, setter and getter as concise way. similar to above class.
    class ConciseDefineField
    {
        public string A { get; private set; }
    }
    
    // Define constructor
    class DefineConstructor
    {
        public string A { get; private set; }
        
        public DefineConstructor(string value)
        {
            A = value;
        }
    }
    
    // Define method
    class DefineMethods
    {
        // Expression : [Accessor] [=static] ReturnType MethodName([, ParameterType Name])
        public void SayHi()
        {
            Console.WriteLine("HI");
        }

        // Define static string
        public static string A = "HI";

        // Define static method
        public static void SayHiStatic()
        {
        }
    }

    // Define static class
    // - This is not a object.
    // - Can not implement interface.
    static class DefineStaticClass
    {
        public static string A = "hi";
        
        // Static constructor
        static DefineStaticClass()
        {
            A = "NO";
        }

        public static void SayHi()
        {
            Console.WriteLine(A);
        }
    }
    #endregion

    #region Record Definition
    
    // Record Type for defining immutable value object.
    record ValueObject(string Hi, bool IsPublic);

    record ValueObjectExtension(string Hi, bool IsPublic, string extend) : ValueObject(Hi, IsPublic);

    
    record MutableRecordExtension(string Hi) // All property is basically immutable.
    {
        // Record type allow mutable property
        public string MutableProperty { get; set; }
        
        // And we can define methods like class.
        public void SayHi()
        {
            Console.WriteLine("Ho!");
        }
    }


    [Fact]
    public void RecordWithTest()
    {
        var vo = new ValueObject("HI", false);

        // `with` is just clone with update some props.
        var voClone = vo with { Hi = "NO", IsPublic = true };
        
        
        Assert.NotEqual(vo, voClone);
        Assert.NotSame(vo, voClone);
    }

    [Fact]
    public void RecordEqualityTest()
    {
        // Record support value equality comparison.
        ValueObject v1 = new("A", true);
        ValueObject v2 = new("A", true); // other reference type
        
        Assert.Equal(v1, v2);
        Assert.NotSame(v1, v2); // compare reference
    }

    [Fact]
    public void RecordDeconstructTest()
    {
        // Record support deconstruct as default
        ValueObject vo = new("A", true);
    
        var (hi, isPublic) = vo;
        
        Assert.Equal("A", hi);
        Assert.True(isPublic);
    }
    
    #endregion
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace C03_Collection;

public class C03_CollectionTypes
{
    [Fact]
    public void BasicInterfaceAndCollectionType()
    {
        // Similar to iterator of other languages(javascript / java), But it's simple interface and can not do anything.
        // Just have next(), reset(), current property.
        IEnumerator enumerator = new ArrayList {"A", "B", "C"}.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var current = enumerator.Current;
            Console.WriteLine(current);
        }

        // IEnumerable can make IEnumerator and almost collection basically implement this. From C# 1.0 
        IEnumerable basicType = new ArrayList();
        foreach (var o in basicType) // Now we can use foreach keyword
        {
            // item type is always object.
            Console.WriteLine(o);
        }

        // IEnumerable<T>(with Generic Type) was released on C# 2.0
        // It's just type-safe IEnumerable
        IEnumerable<string> genericEnumerable = new List<string>();
        foreach (string hi in genericEnumerable)
        {
            Console.WriteLine("Now we can know for what a type of collecton item.");
        }

        // IEnumerable interface doesn't have mutable api
        // genericEnumerable.Add <- Compile error.
        // But, ICollection<T> can add item.
        ICollection<string> coll = new List<string>();
        coll.Add("Something.");

        // Define Dictionary which is called by Map<Key, Value> of other language.
        // All of concrete type implement IDictionary
        IDictionary<string, string> dictionary = new Dictionary<string, string>(); // similar to HashMap

        // And also it's implement IEnumerable
        IEnumerable<KeyValuePair<string, string>> dictEnumerable = dictionary;

        // Define SortedDictionary to improve perf for numeric key type
        var sortedDict2 = new SortedDictionary<int, string>
        {
            {100, "expression 1"}, 
        };
        
        var sortedDict = new SortedDictionary<int, string>
        {
            [200] = "expression 2"
        };


        // dictionary collection
        new Dictionary<string, string>();
        new SortedDictionary<string, string>();

        // set collection
        new HashSet<string>();
        new SortedSet<string>();

        // list collection
        new List<string>(); // Similar to ArrayList, Vector
        new LinkedList<string>();

        // array
        var strings = new[] {"a", "b", "c'"};
        
        // advanced
        new Queue<string>();
        // new PriorityQueue<string, ConcreteComparer>() 
        new Stack<string>();

        // immutable collection
        ImmutableList.Create<string>();
        ImmutableArray.Create<string>();
        ImmutableDictionary.Create<string, string>();
        ImmutableHashSet.Create<string>();
        
        
        // Summary
        // ------------------------------------------------
        // IEnumerable(GetEnumerator => IEnumerator)
        //     <- IEnumerator<T>
        //         <- ICollection<T>
        //             <- IDicionary<K, V>
        //             <- IList<T>
        //             <- ISet<T>
        //         <- IReadOnlyCollection<T>
        //             <- IListOnly*<T>
        //             <- Queue<T>
        //             <- Stack<T>
      
    }
}
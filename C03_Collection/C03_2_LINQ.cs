using System;
using System.Linq;
using Xunit;

namespace C03_Collection;

public class C03_2_LINQ
{
    [Fact]
    public void Test()
    {
        var items = Enumerable.Range(0, 100);

        // DSL-Like expression.
        var count = (from num in items
            where num % 2 == 0
            select num * 10).Sum();

        // group by linq-expression
        var groupby = from num in items
            where num > 20
            group num by num % 2 == 0
            into g
            select (isEven: g.Key, count: g.Count(), max: g.Max(), min: g.Min(), avg: g.Average());

        var groupbyChainStyle = items
            .Where(num => num > 20)
            .GroupBy(num => num % 2 == 0)
            .Select(g => (isEven: g.Key, count: g.Count(), max: g.Max(), min: g.Min(), avg: g.Average()));


        // Advanced features
        var sum = items.Skip(10)
            .Take(20) 
            .Select(num => num * 2)
            .Concat(new[] {1, 2, 3, 4, 5}) // with some items : NOT AddRange
            .Distinct()
            .Append(3) // attach last only one item : NOT AddRange
            .Append(5)
            .Append(10)
            .AsParallel() // Parallel compute - :)
            .Sum();
    }
}
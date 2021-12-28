namespace C04_ASPNET.Core.Services;


public record Sample(int Id, string Message, string Description);

public interface ISampleService
{
    IEnumerable<Sample> GetSamples();
}

public class SampleService : ISampleService
{
    public IEnumerable<Sample> GetSamples()
    {
        yield return new Sample(1, "hi", "description");
    }
}
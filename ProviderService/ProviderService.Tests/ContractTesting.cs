using PactNet.Infrastructure.Outputters;
using PactNet.Verifier;

namespace ProviderServiceTests;

public class ContractTesting
{
    private readonly IPactVerifierProvider pactVerifier;

    public ContractTesting()
    {
        var config = new PactVerifierConfig
        {
            Outputters = new List<IOutput>
            {
                new ConsoleOutput()
            },
            LogLevel = PactNet.PactLogLevel.Error
        };
        pactVerifier = new PactVerifier(config).ServiceProvider("ProviderService", new Uri("http://localhost:5228"));
    }

    [Fact]
    public void PactVerification()
    {
        var files = GetPactFilesNames();
        foreach (var file in files)
        {
            var consumerPactFileInfo = new FileInfo(file);
            pactVerifier
                .WithFileSource(consumerPactFileInfo)
                .Verify();
        }
    }

    private IEnumerable<string> GetPactFilesNames()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var parentDirectory = Directory.GetParent(currentDirectory)?.Parent?.Parent?.Parent;
        var directory = parentDirectory != null ? Path.Combine(parentDirectory.FullName, "pacts") : throw new DirectoryNotFoundException("Directory not found");

        return Directory.GetFiles(directory, "*.json");
    }
}
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using System;

namespace AzureAppConfigDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddAzureAppConfiguration(options =>
                {
                    options.Connect(new Uri("https://app-config-secret-mgmt.azconfig.io"), new DefaultAzureCredential())
                           .ConfigureKeyVault(kv =>
                           {
                               kv.SetCredential(new DefaultAzureCredential());
                           });
                });

            var configuration = builder.Build();

            // Example of retrieving a setting
            var apiOptionsKey = configuration["ApiOptionsKey"];
            Console.WriteLine($"ApiOptionKey: {apiOptionsKey}");

            // Example of retrieving a secret from Key Vault
            var apiOptionsSecret = configuration["ApiOptionsSecret"];
            Console.WriteLine($"ApiOptionsSecret: {apiOptionsSecret}");
        }
    }
}

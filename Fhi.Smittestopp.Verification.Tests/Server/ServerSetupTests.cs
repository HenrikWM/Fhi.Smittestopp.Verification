using System.Threading.Tasks;
using Fhi.Smittestopp.Verification.Server;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace Fhi.Smittestopp.Verification.Tests.Server
{
    [TestFixture]
    public class ServerSetupTests
    {
        private WebApplicationFactory<Startup> _factory;

        [OneTimeSetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            _factory.Dispose();
        }

        [Test]
        public async Task Server_GivenOpenIdConfigRequest_ReturnsOpenIdConfig()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(".well-known/openid-configuration");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=UTF-8");
        }

        [Test]
        public async Task Server_GivenHealthCheckRequest_ReturnsHealthy()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("health");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var body = await response.Content.ReadAsStringAsync();
            body.Should().Be("Healthy");
        }
    }
}
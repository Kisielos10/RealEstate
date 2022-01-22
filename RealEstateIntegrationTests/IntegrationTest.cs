using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RealEstate.API;
using RealEstate.API.DTO;
using RealEstate.API.Persistence;
using Xunit;

namespace RealEstateIntegrationTests
{
    public class IntegrationTest
    {
        private HttpClient _client;

        public IntegrationTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>().ConfigureAppConfiguration(conf => conf.AddJsonFile("appsettings.json")));
            _client = server.CreateClient();

        }

        [Fact]
        public async Task ApiStartupTest()
        {
            var response = await _client.GetAsync("api/healthcheck");
            var responseContent = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseContent.Should().Be("healthy");
        }

        [Fact]
        public async Task GetRealEstates()
        {
            var response = await _client.GetAsync("api/realestates");
            var responseContent = await response.Content.ReadAsStringAsync();
            var abc = JsonConvert.DeserializeObject<List<RealEstateDto>>(responseContent);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            abc.Should().NotBeEmpty();
        }

        [Fact]
        public async Task AddRealEstates()
        {
            var realEstate = new CreateRealEstateDto
            {
                Area = 400.30m,
                Price = 5000000m,
                YearBuilt = 2000,
                Type = BuildingType.Other,
                Address = new AddressDto()
                {
                    ApartmentNumber = 2,
                    BuildingNumber = 13,
                    PostalCode = "66-446",
                    StreetName = "Pilsudzkiego"
                }
            };

            var response = await _client.PostAsJsonAsync("api/realestates", realEstate);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var result = await response.Content.ReadFromJsonAsync<RealEstateDto>();

            result.YearBuilt.Should().Be(2000);

            RandomNumberGenerator.GetInt32(1900, 2020);
        }
    }
}

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PointOfSaleAPI;
using PointOfSaleAPI.Entities;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1 //: IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        static HttpClient client = new HttpClient();

        public UnitTest1()
        {
            client.BaseAddress = new Uri("https://localhost:44337/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<bool> TestLaptopBrand()
        {
            
            var response = await client.GetAsync("api/GetLaptopBrands");
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            else
            {
                return false;
            }
        }
        private async Task<bool> TestHdd()
        {

            var response = await client.GetAsync("api/GetHdd");
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            else
            {
                return false;
            }
        }
        private async Task<bool> TestRam()
        {

            var response = await client.GetAsync("api/GetRam");
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            else
            {
                return false;
            }
        }
        private async Task<bool> TestColor()
        {

            var response = await client.GetAsync("api/GetColor");
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            else
            {
                return false;
            }
        }

        [Fact]
        public async Task TestLaptopAPIWorking()
        {
            Assert.True(await TestLaptopBrand());
        }
        [Fact]
        public async Task TestHddAPIWorking()
        {
            Assert.True(await TestHdd());
        }
        [Fact]
        public async Task TestRamAPIWorking()
        {
            Assert.True(await TestRam());
        }
        [Fact]
        public async Task TestColorAPIWorking()
        {
            Assert.True(await TestColor());
        }
    }
}

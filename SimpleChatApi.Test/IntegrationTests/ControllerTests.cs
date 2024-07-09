using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SimpeChatApi;
using SimpleChatApi.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatApi.Test.IntegrationTests
{
    public class ControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient client;

        public ControllerTests(WebApplicationFactory<Startup> factory)
        {
            client = factory.CreateClient();
        }

        [Fact]
        public async Task GetChats_SouldReturnChats()
        {
            var res = await client.GetAsync("/api/chat");
            res.EnsureSuccessStatusCode();

            var resString = await res.Content.ReadAsStringAsync();
            var chats = JsonConvert.DeserializeObject<IEnumerable<ChatModel>>(resString);

            Assert.NotEmpty(chats);
        }
    }
}

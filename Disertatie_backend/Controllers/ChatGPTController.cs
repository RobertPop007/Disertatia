using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenAI_API;
using OpenAI_API.Completions;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Disertatie_backend.Controllers
{
    public class ChatGPTController : BaseApiController
    {
        [HttpGet]
        [Route("AskChatGPT")]
        public async Task<IActionResult> AskChatGPT(string query)
        {
            var endpoint = "https://api.openai.com/v1/chat/completions"; //Claude Kye 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

            var messages = new[]
            {
                new {role = "user", content = query}
            };

            var data = new
            {
                model = "gpt-3.5-turbo",
                messages = messages
            };

            var jsonString = JsonConvert.SerializeObject(data);

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", "Bearer sk-proj-AXMt9gQbFbFIdpxixHFuT3BlbkFJflfKPdFlE94lRcqELtTq");

            var response = await client.PostAsync(endpoint, content);

            var responseContent = await response.Content.ReadAsStringAsync();

            var jsonResponse = JObject.Parse(responseContent);

            string responseFromChatGPT = jsonResponse["choices"][0]["message"]["content"].Value<string>();

            return Ok(responseFromChatGPT);
        }
    }
}

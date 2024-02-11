using OpenAI;
using OpenAI.Managers;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using OpenAI.Interfaces;

namespace Chat
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IOpenAIService api = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = "OPENAI KEY"
            });

            Console.WriteLine("Como posso te ajudar?");
            var pergunta = Console.ReadLine();

            var completion = await api.ChatCompletion.CreateCompletion(
                new ChatCompletionCreateRequest
                {
                    Messages = new List<ChatMessage>
                    {
                    ChatMessage.FromSystem("System message"),
                    ChatMessage.FromUser(pergunta)
                    },
                    Model = Models.ChatGpt3_5Turbo0301
                }) ;

            if (completion.Successful)
            {
                Console.WriteLine(completion.Choices.FirstOrDefault()?.Message.Content);
            }
            else
            {
                Console.WriteLine(completion.Error?.Message);
            }


        }
    }
}
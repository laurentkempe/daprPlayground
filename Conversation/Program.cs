// 👇🏼 Get Dapr conversation client through DI
var conversationClient = ConversationClientBuilder.Create();

// 👇🏼 Specify that we want to use the "ollama" Dapr conversation component (./components/ollama.yaml)
var conversationOptions = new ConversationOptions("ollama");

// 👇🏼 Use Dapr conversation client to converse with the "ollama" Dapr conversation component
var response = await conversationClient.ConverseAsync(
    [
        new ConversationInput(
        [
            new UserMessage
            {
                Name = "Laurent",
                Content =
                [
                    new MessageContent("What is Dapr?")
                ]
            }
        ])
    ],
    conversationOptions);

Console.WriteLine($"Output response: {response.Outputs.First().Choices.First().Message.Content}");
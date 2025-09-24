namespace Conversation;

internal static class ConversationClientBuilder
{
    public static DaprConversationClient Create()
    {
        var services = new ServiceCollection();
        services.AddDaprConversationClient();
        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider.GetRequiredService<DaprConversationClient>();
    }
}
# Sample application using Dapr .NET SDK, Dapr Sidekick, Dapr secret component, Dapr GraphQL binding, GitHub GraphQL

This sample demonstrates how to configure Dapr GraphQL binding using Dapr secret component to be able to call GitHub GraphQL API.
It leverages also Dapr Sidekick to run the Dapr sidecar when the sample application starts.

You can read more about it on the blog post "TODO".

# Try

Before running the application you need to get a [GitHub OAuth token](https://docs.github.com/en/graphql/guides/forming-calls-with-graphql#authenticating-with-graphql), and set it in [GitHubGraphQLService/components/github-secrets.json](https://github.com/laurentkempe/daprPlayground/blob/master/GitHubGraphQLDapr/GitHubGraphQLService/components/github-secrets.json#L2) replacing YOURTOKEN

    {
       "GitHubPersonalAccessToken": "Bearer YOURTOKEN"
    }

You can see some examples of how to call the service in the file [client.http](https://github.com/laurentkempe/daprPlayground/blob/master/GitHubGraphQLDapr/GitHubGraphQLService/client.http)

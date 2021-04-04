using System;
using System.Linq;
using Dapr.Client;
using Tweetinvi;

Console.WriteLine("Hello Dapr secrets!");

var daprClient = new DaprClientBuilder().Build();

var twitterSecrets = daprClient.GetBulkSecretAsync("local-secret-store").Result;

var consumerKey = twitterSecrets["twitterSecrets:consumerKey"].Values.First();
var consumerSecret = twitterSecrets["twitterSecrets:consumerSecret"].Values.First();
var accessToken = twitterSecrets["twitterSecrets:accessToken"].Values.First();
var accessSecret = twitterSecrets["twitterSecrets:accessSecret"].Values.First();

var twitterClient =
    new TwitterClient(consumerKey, consumerSecret, accessToken, accessSecret);

var user = await twitterClient.Users.GetAuthenticatedUserAsync();
Console.WriteLine(user.Description);

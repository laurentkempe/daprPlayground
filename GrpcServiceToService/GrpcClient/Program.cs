using System;
using System.Collections.Generic;
using System.Text.Json;
using Dapr.Client.Autogen.Grpc.v1;
using Grpc.Core;

var channel = new Channel("127.0.0.1:3500", ChannelCredentials.Insecure);
var daprClient = new Dapr.Client.Autogen.Grpc.v1.Dapr.DaprClient(channel);
var request = new InvokeServiceRequest
{
    Id = "proxy",
    Message = new InvokeRequest
    {
        Method = "weatherforecastproxy",
        HttpExtension = new HTTPExtension
        {
            Verb = HTTPExtension.Types.Verb.Get,
            Querystring = "count=2"
        }
    }
};

var invokeResponse = daprClient.InvokeService(request);
var json = invokeResponse.Data.Value.ToStringUtf8();
Console.WriteLine(json);

var jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
var weatherForecasts =
    JsonSerializer.Deserialize<List<WeatherForecast>>(json, jsonSerializerOptions);
foreach (var weatherForecast in weatherForecasts)
{
    Console.WriteLine($"Date: {weatherForecast.Date}, {weatherForecast.Summary}, {weatherForecast.TemperatureC}°");
}

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public string Summary { get; set; }
}
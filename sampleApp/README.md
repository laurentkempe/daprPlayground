# Sample App

This sample app demonstrates how to use [.NET Dapr SDK](https://github.com/dapr/dotnet-sdk) for State, Pub/Sub and Service to Service call.
It leverage [Dapr SideKick](https://github.com/man-group/dapr-sidekick-dotnet) to be able to start easily the Dapr sidecar from your application or services.
It also shows the usage of Jaeger for distributed traces.

It was created for DevApps meetup "Saison 04 Episode 07" (in French), [watch it on YouTube](https://youtu.be/XtASb2tmo5c?t=119) and [download the slides](https://laurentkempe.com/presentations/Introduction%20to%20Dapr%20.NET%20SDK/Introduction%20to%20Dapr%20.NET%20SDK.pptx).

* WebSite, a Blazor server application, uses Dapr State to retrieve/store a counter state and Dapr Pub/Sub to publish an event.
* CounterService, a ASP.NET 5 WebApi, uses Dapr Pub/Sub to subscribe to the event and log it.
* WeatherService, the default template for ASP.NET 5 WebApi, just use Dapr SideKick to start it with Dapr.

# Try

## Start Jaeger

    docker run -d --name jaeger -e COLLECTOR_ZIPKIN_HOST_PORT=:9412 -p 16686:16686 -p 9412:9412 jaegertracing/all-in-one:1.22

## Start Sample App

You can start WebSite and CounterService `.\start.ps1` (it needs Windows Terminal), which will also start the Dapr sidecars.

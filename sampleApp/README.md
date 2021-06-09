# Sample App

This sample app demonstrates how to use Dapr SDK for State, Pub/Sub and Service to Service call.

It was created for DevApps meetup "Saison 04 Episode 07" (in French).

WebSite, a Blazor server application, uses Dapr State to retrieve/store a counter state and Dapr Pub/Sub to publish an event.
Service, a ASP.NET 5 WebApi, uses Dapr Pub/Sub to subscribe to the event and log it.

# Try

## Start Jaeger

    docker run -d --name jaeger -e COLLECTOR_ZIPKIN_HOST_PORT=:9412 -p 16686:16686 -p 9412:9412 jaegertracing/all-in-one:1.22

## Start Sample App

You can start WebSite and Service `.\start.ps1` (it needs Windows Terminal), which will also start the Dapr sidecars.

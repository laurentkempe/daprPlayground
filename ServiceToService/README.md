# Service to Service with Dapr SDK

This sample demonstrates how to use Dapr SDK in a Service to Service call.

You can start proxy and backend dapr sidecars using `.\start.ps1` (needs Windows Terminal).

When both sidecars are running use `client.http` to make a request to the proxy service which calls the backend service.

See name resolution by changing the port from `http://localhost:3500` to `http://localhost:3501`, so calling any sidecar route correctly the call.

You can read more about it on the blog post "Service to service invocation with Dapr .NET SDK".
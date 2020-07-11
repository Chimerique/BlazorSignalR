# BlazorSignalR
This project intent to show live data informations on a chart by combining Blazor webassembly, SignalR and Background Worker.

## Blazor
The blazor part of the app will :
 - Invoke a JS lib (tradingview) to init the graph and update datat
 - Count / show each new data it received
 - Display the last received data (or error)
 
## SignalR
A Signal R hub has been created to update each connected client with the latest data available.

## Background worker
The background worker is in charge to trigger the SignalR call each time it has detected a new value. (in this sample a random value is created every 2 seconds)

using Observer;

// See https://aka.ms/new-console-template for more information

Consumer consumer = new();
StreamingClient streamingClient = new();

streamingClient.Subscribe(consumer);
streamingClient.Notify();

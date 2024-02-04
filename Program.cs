﻿using DiscordRPC;
using DiscordRPC.Message;

partial class Program {
    public const ulong clientId = 1114910688872247350;
    public static RichPresence Presence = new RichPresence();
    private static DiscordRpcClient RPCClient;
    private static Mouse mouse = new Mouse();
    public static Pipes pipes = new Pipes();
    static void Main() {
        Dictionary<int, string> discordPipesDictionary = pipes.Scan();
        Console.WriteLine($"Discord Pipes : {pipes.toString(discordPipesDictionary)}");
        int input = int.Parse(Console.ReadLine());
        string value;
        if (discordPipesDictionary.TryGetValue(input, out value)) {
            Console.WriteLine($"Using Discord Pipe: {value}");
            RPCClient = new DiscordRpcClient(clientId.ToString(), input);
            RPCClient.Initialize();
            Presence.Details = "Mouse Moving";
            while (true) {
                if (mouse.IsInactive(1000)) {
                    Presence.State = "Mouse is : Inactive";
                }
                else {
                    Presence.State = "Mouse is : Active";
                }
                RPCClient.SetPresence(Presence);
                Thread.Sleep(1000);
            }
            RPCClient.Dispose();
        } else {
            Console.WriteLine($"Discord Pipe {input} does not exist.");
        }
    }
}
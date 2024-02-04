using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public partial class Pipes {
    public Dictionary<int, string> Scan() {
        Dictionary<int, string> discordPipesDictionary = new Dictionary<int, string>();
        var discordPipesCount = -1;
        var pipeCount = 0;
        var pipes = Directory.GetFiles(@"\\.\pipe\");
        for (var i = 0; i < pipes.Length; i++) {
            var pipe = pipes[i].Split('\\').Last();
            if (pipe.StartsWith("discord")) {
                discordPipesCount++;
                discordPipesDictionary.Add(discordPipesCount, pipes[pipeCount]);
            }
            else {
                pipeCount++;
            }
        }
        return discordPipesDictionary;
    }
    public string toString(Dictionary<int, string> discordPipesDictionary) {
        return string.Join(", ", discordPipesDictionary.Select(kvp => $"\n{kvp.Key}: {kvp.Value}"));
    }
}
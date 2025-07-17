﻿/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row

        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];

            // Ensure points are valid and parseable
            if (int.TryParse(fields[8], out int points))
            {
                if (players.ContainsKey(playerId))
                {
                    players[playerId] += points;
                }
                else
                {
                    players[playerId] = points;
                }
            }
        }

        Console.WriteLine("Top 10 Players by Total Career Points:");
        Console.WriteLine("---------------------------------------");

        foreach (var player in players
                     .OrderByDescending(p => p.Value)
                     .Take(10))
        {
            Console.WriteLine($"{player.Key}: {player.Value} points");
        }
    }
}

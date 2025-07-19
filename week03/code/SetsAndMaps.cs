using System.Text.Json;
using System.Diagnostics;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>(words);
        var result = new List<string>();

        foreach (var word in words)
        {
            string reversed = new string(new[] { word[1], word[0] });
            if (word != reversed && seen.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
                seen.Remove(reversed); // avoid duplicate pairings
            }
        }

        return result.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length >= 5)
            {
                var degree = fields[4].Trim();
                if (!degrees.ContainsKey(degree))
                {
                    degrees[degree] = 1;
                }
                else
                {
                    degrees[degree]++;
                }
            }
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        var dict1 = new Dictionary<char, int>();
        var dict2 = new Dictionary<char, int>();

        foreach (char c in word1.ToLower().Where(c => !char.IsWhiteSpace(c)))
        {
            if (!dict1.ContainsKey(c)) dict1[c] = 0;
            dict1[c]++;
        }

        foreach (char c in word2.ToLower().Where(c => !char.IsWhiteSpace(c)))
        {
            if (!dict2.ContainsKey(c)) dict2[c] = 0;
            dict2[c]++;
        }

        return dict1.Count == dict2.Count && !dict1.Except(dict2).Any();
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(jsonStream, options);

        var result = new List<string>();

        if (featureCollection?.features != null)
        {
            foreach (var feature in featureCollection.features)
            {
                var place = feature.properties.place;
                var mag = feature.properties.mag;
                if (!string.IsNullOrEmpty(place) && mag.HasValue)
                {
                    result.Add($"{place} - Mag {mag.Value}");
                }
            }
        }

        return result.ToArray();
    }
}

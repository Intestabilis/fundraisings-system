using System.Globalization;

namespace Fundraisings.Persistence.ExternalData.Parsers;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;

public class DeepstateDataParser
{
    static async Task Parse()
    {
        var targetDate = new DateTime(2025, 6, 5); // фіксована дата 05.06.2025

        Console.WriteLine($"Fetching DeepState data for date: {targetDate:yyyy-MM-dd} (UTC)");

        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://deepstatemap.live/api/history/public");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var entries = JsonConvert.DeserializeObject<List<DeepStateEntry>>(content);

        var results = new List<GeoEvent>();

        foreach (var entry in entries)
        {
            if (entry.CreatedAt.Date != targetDate)
                continue;

            var doc = new HtmlDocument();
            doc.LoadHtml(entry.DescriptionEn);

            var links = doc.DocumentNode.SelectNodes("//a[@href]");
            if (links == null)
                continue;

            var coords = new List<Location>();

            foreach (var link in links)
            {
                var href = link.GetAttributeValue("href", "");
                var match = Regex.Match(href, @"#(?:\d+)/([0-9.]+)/([0-9.]+)");
                if (match.Success)
                {
                    coords.Add(new Location
                    {
                        Place = link.InnerText.Trim(),
                        Lat = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture),
                        Lon = double.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture)
                    });
                }
            }

            var text = doc.DocumentNode.InnerText.ToLower();
            string type = null;
            if (text.Contains("occupied") || text.Contains("окупував"))
                type = "occupied";
            else if (text.Contains("advanced") || text.Contains("просунувся"))
                type = "advanced";

            if (type != null && coords.Count > 0)
            {
                results.Add(new GeoEvent
                {
                    Type = type,
                    DateTime = entry.CreatedAt,
                    Coordinates = coords
                });
            }

            Console.WriteLine($"Found {results.Count} events for {targetDate:yyyy-MM-dd}:\n");

            foreach (var e in results)
            {
                Console.WriteLine($"Type: {e.Type}, DateTime: {e.DateTime:O}");
                foreach (var c in e.Coordinates)
                    Console.WriteLine($" - {c.Place} ({c.Lat}, {c.Lon})");
                Console.WriteLine();
            }
        }
    }
    class DeepStateEntry
    {
        [JsonProperty("descriptionEn")]
        public string DescriptionEn { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
    }

    class GeoEvent
    {
        public string Type { get; set; }
        public DateTime DateTime { get; set; }
        public List<Location> Coordinates { get; set; }
    }

    class Location
    {
        public string Place { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
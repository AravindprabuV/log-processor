using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using service.Interface;

namespace service;
public class LoggerService : ILoggerService
{
    public async Task ParseLogFiles(string file)
    {
        var fileData = await File.ReadAllLinesAsync (file);

        Dictionary<int, JsonNode> dict = new();
        var i = 0;
        foreach (var line in fileData)
        {
            var splittedData = Regex.Split(line, "(?:\\d{4}/\\d{2}/\\d{2} \\d{2}:\\d{2}:\\d{2}.\\d{3}\\|)");

            var jsonData = splittedData[1];

            jsonData = jsonData.Replace("\b", "");

            dict.Add(i, JsonSerializer.Deserialize<JsonNode>(jsonData));


            i++;


        }

    }
}


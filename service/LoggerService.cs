using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using service.Interface;

namespace service;
public class LoggerService : ILoggerService
{
    public async Task<Dictionary<int,string>> GetApiIdFromFile(string file)
    {
        var fileData = await File.ReadAllLinesAsync (file);

        Dictionary<int, string> dict = new();
        var i = 0;
        foreach (var line in fileData)
        {
            var splittedData = Regex.Split(line, "(?:\\d{4}/\\d{2}/\\d{2} \\d{2}:\\d{2}:\\d{2}.\\d{3}\\|)");

            var jsonData = splittedData[1];

            jsonData = jsonData.Replace("\b", "");

            var seralizedJson = JObject.Parse(jsonData);

            var apiIdNode = seralizedJson.SelectToken("RawRequest.ApiId");

            if (apiIdNode != null)
            {

                dict.Add(i, value: apiIdNode.Value<string>());
            }



            i++;


        }

        return dict;

    }
}


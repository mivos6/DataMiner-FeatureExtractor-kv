// This code requires the Nuget package Microsoft.AspNet.WebApi.Client to be installed.
// Instructions for doing this in Visual Studio:
// Tools -> Nuget Package Manager -> Package Manager Console
// Install-Package Microsoft.AspNet.WebApi.Client

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CallRequestResponseService
{

    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }

    class ModelRequest
    {
        static string rezultat;
        public static string Result {
            get
            {
                return rezultat;
            }
            set
            {
                rezultat = value; 
            }
        }

        /*static void Main(string[] args)
        {
            InvokeRequestResponseService().Wait();
        }*/

        public static async Task InvokeRequestResponseService(int[] features)
        {
            using (var client = new HttpClient())
            {
                string[,] strFeatures = new string[1,features.Length];
                int i = 0;
                foreach (int temp in features)
                {
                    strFeatures[0, i++] = temp.ToString();
                }
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"F0", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16", "F17", "F18", "F19", "F20", "F21", "F22", "F23", "F24", "F25", "F26", "F27", "F28", "F29", "F30", "F31", "F32", "F33", "F34", "F35", "F36", "F37", "F38", "F39", "F40", "F41", "F42", "F43", "F44", "F45", "F46", "F47", "F48", "F49", "F50", "F51", "F52", "F53", "F54", "F55", "F56", "F57", "F58", "Class"},
                                Values = strFeatures
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "jIQaF23PNudYp2xGTJIptgfAMj5BP/93tfy3zwNrwKv8NcogVAwnvGfpUFM/JSLbViQJjLqdaOP4j8M0pNLIRA=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/9fc47ece229048dca9446555a7604fcb/services/982a4e313add483d9f79479b31c9fc10/execute?api-version=2.0&details=true");

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)


                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Result = result;
                }
                else
                {
                    Result = string.Format("The request failed with status code: {0}<br><br>", response.StatusCode);

                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    Result += (response.Headers.ToString() + "<br><br>");

                    string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Result += (responseContent + "<br><br>");
                }
            }
        }
    }
}

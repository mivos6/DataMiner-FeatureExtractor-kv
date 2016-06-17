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

        public static async Task InvokeRequestResponseService(double[] features)
        {
            using (var client = new HttpClient())
            {
                string[,] strFeatures = new string[1,features.Length];
                int i = 0;
                foreach (double temp in features)
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
                                ColumnNames = new string[] {"F0", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16", "F17", "F18", "F19", "F20", "F21", "F22", "F23", "F24", "F25", "F26", "F27", "F28", "F29", "F30", "F31", "F32", "F33", "F34", "F35", "F36", "F37", "F38", "F39", "F40", "F41", "F42", "F43", "F44", "F45", "F46", "F47", "F48", "F49", "F50", "F51", "F52", "F53", "F54", "F55", "F56", "F57", "F58", "F59", "F60", "F61", "F62", "F63", "F64", "F65", "F66", "F67", "F68", "F69", "F70", "F71", "F72", "F73", "F74", "F75", "F76", "F77", "F78", "F79", "F80", "F81", "F82", "F83", "F84", "F85", "F86", "F87", "F88", "F89", "F90", "F91", "F92", "F93", "F94", "F95", "F96", "F97", "F98", "F99", "F100", "F101", "F102", "F103", "F104", "F105", "F106", "F107", "F108", "F109", "F110", "F111", "F112", "F113", "F114", "F115", "F116", "F117", "F118", "F119", "F120", "F121", "F122", "F123", "F124", "F125", "F126", "F127", "F128", "F129", "F130", "F131", "F132", "F133", "F134", "F135", "F136", "F137", "F138", "F139", "F140", "F141", "F142", "F143", "F144", "F145", "F146", "F147", "F148", "F149", "F150", "F151", "F152", "F153", "F154", "F155", "F156", "F157", "F158", "F159", "F160", "F161", "F162", "F163", "F164", "F165", "F166", "F167", "F168", "F169", "F170", "F171", "F172", "F173", "F174", "F175", "F176", "F177", "F178", "F179", "F180", "F181", "F182", "F183", "F184", "F185", "F186", "F187", "F188", "F189", "F190", "F191", "F192", "F193", "F194", "F195", "F196", "F197", "F198", "F199", "F200", "F201", "F202", "F203", "F204", "F205", "F206", "F207", "F208", "F209", "F210", "F211", "F212", "F213", "F214", "F215", "F216", "F217", "F218", "F219", "F220", "F221", "F222", "F223", "F224", "F225", "F226", "F227", "F228", "F229", "F230", "F231", "F232", "F233", "F234", "F235", "F236", "F237", "F238", "F239", "F240", "F241", "F242", "F243", "F244", "F245", "F246", "F247", "F248", "F249", "F250", "F251", "F252", "F253", "F254", "F255", "F256", "F257", "F258", "F259", "F260", "F261", "F262", "F263", "F264", "F265", "F266", "F267", "Class"},
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

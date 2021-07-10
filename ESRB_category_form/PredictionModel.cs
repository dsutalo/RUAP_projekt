using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Globalization;

using System.Threading.Tasks;

namespace ESRB_category_form
{
    class PredictionModel
    {
        private static char predictionResults; 
        private static string[,] inputValues;

        private static string probabilityE;
        private static string probabilityET;
        private static string probabilityM;
        private static string probabilityT;

        public string getProbabilityE()
        {
            return probabilityE;
        }
        public string getProbabilityET()
        {
            return probabilityET;
        }
        public string getProbabilityM()
        {
            return probabilityM;
        }
        public string getProbabilityT()
        {
            return probabilityT;
        }


        public char getResults()
        {
            return predictionResults;
        }


        public void setESRBValues(string[,] values)
        {
            inputValues = values;
        }

        public void StartPrediction()
        {
            _ = InvokeRequestResponseService();
        }

       private static async Task InvokeRequestResponseService()
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"title", "console", "alcohol_reference", "animated_blood", "blood", "blood_and_gore", "cartoon_violence", "crude_humor", "drug_reference", "fantasy_violence", "intense_violence", "language", "lyrics", "mature_humor", "mild_blood", "mild_cartoon_violence", "mild_fantasy_violence", "mild_language", "mild_lyrics", "mild_suggestive_themes", "mild_violence", "no_descriptors", "nudity", "partial_nudity", "sexual_content", "sexual_themes", "simulated_gambling", "strong_janguage", "strong_sexual_content", "suggestive_themes", "use_of_alcohol", "use_of_drugs_and_alcohol", "violence", "esrb_rating"},
                                Values = inputValues
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "hr4JHu6uLvjPHLmfnVZ6Wwq0MXhyOg9Cvl4P80E1AljpnOBa/OnmyadKAxTGHT7GtHUQ1JH3uvje7RcNUjU9rA=="; 
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/03ce3057020a414aa21b20ddcef2f733/services/6e0b3a57b25d49af9f3eaa9f7add001a/execute?api-version=2.0&details=true");

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)


                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    int lastIndex = result.IndexOf("]]}}}}"); 
                    predictionResults = result[lastIndex - 2];// category data in response

                    string pattern = @"[-]{0,1}[\d]*[.]{0,1}[\d]+";// finds every number in string

                    Regex regex = new Regex(pattern);
                    var number = regex.Matches(result);

                    probabilityE = number[1].Value;
                    probabilityET = number[2].Value;
                    probabilityM = number[3].Value;
                    probabilityT = number[4].Value;


                    
                }
                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync();
                    

                    
                }
            }
        }

       
        

    }
}

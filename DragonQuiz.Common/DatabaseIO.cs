using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;

using Newtonsoft.Json;

namespace DragonQuiz
{
    public class DatabaseIO
    {
		private const string SERVER_URL = "http://localhost:60165/api/values";
		public static List<DQuestion> GetPack(DRequest request)
		{
			try
			{
				WebRequest webRequest = WebRequest.Create(SERVER_URL + request.ToString());
				webRequest.Credentials = CredentialCache.DefaultCredentials;
				webRequest.Method = "GET";
				webRequest.ContentType = "application/json; charset=utf-8";
				WebResponse response = webRequest.GetResponse();
				//Stream dataStream = response.GetResponseStream();
				

				// Open the stream using a StreamReader for easy access.
				//StreamReader reader = new StreamReader(dataStream);
				// Read the content.
				//string responseFromServer = reader.ReadToEnd();
				// Clean up the streams and the response.
				//reader.Close();
				//response.Close();
				using (var reader = new StreamReader(response.GetResponseStream()))
				{
					var objText = reader.ReadToEnd();
					if (objText != null)
					{
						return JsonConvert.DeserializeObject<List<DQuestion>>(objText);
					}
					return new List<DQuestion>{ new DQuestion()};
				}
				
			}
			catch
			{
				return null;
			}
		}

		public static void PushQuestions(List<DQuestion> questionsList) {
			string s = JsonConvert.SerializeObject(questionsList);
			var wc = new WebClient();
			wc.Headers.Add("Content-Type", "application/json");
			try
			{
				var result = wc.UploadData(SERVER_URL, Encoding.UTF8.GetBytes(s));
			}
			catch { }
			/* WebRequest webRequest = WebRequest.Create(SERVER_URL);
			webRequest.Method = "POST";
			webRequest.Credentials = CredentialCache.DefaultCredentials;
			WebResponse response = webRequest.GetResponse(); */
		}
    }
}

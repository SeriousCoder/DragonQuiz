using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Http;
using System.IO;

using Newtonsoft.Json;

namespace DragonQuiz
{
    public class DatabaseIO
    {
      /*  public static void receiveResponce(IAsyncResult f, Action<List<DQuestion> > callback)
        {
             RequestState myRequestState=(RequestState) f.AsyncState;
             HttpWebRequest  myHttpWebRequest = myRequestState.request;
             var response = (HttpWebResponse) myHttpWebRequest.EndGetResponse(f);
            
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var objText = reader.ReadToEnd();
                if (objText != null)
                {
                    return JsonConvert.DeserializeObject<List<DQuestion>>(objText);
                }
                return new List<DQuestion> { new DQuestion() };
            }
        }


		private const string SERVER_URL = "http://91.225.131.178:60165/api/values";
		public static void GetPack(DRequest request, Action<List<DQuestion> > callback)
		{
			try
			{
				WebRequest webRequest = WebRequest.Create(SERVER_URL + request.ToString());
				webRequest.Method = "GET";
				webRequest.ContentType = "application/json; charset=utf-8";
                ((HttpWebRequest)webRequest).BeginGetResponse(fun => { receiveResponce(fun, callback) }, null);
			}
			catch
			{
                return;
			}
		}
        
		public async static void PushQuestions(List<DQuestion> questionsList) {
			string s = JsonConvert.SerializeObject(questionsList);
			var content = new StringContent(s.ToString(), Encoding.UTF8, "application/json");
			var wc = new HttpClient();
			try
			{
				var result = await wc.PostAsync(SERVER_URL, content);
			}
			catch { }*/
			/* WebRequest webRequest = WebRequest.Create(SERVER_URL);
			webRequest.Method = "POST";
			webRequest.Credentials = CredentialCache.DefaultCredentials;
			WebResponse response = webRequest.GetResponse(); 
		}*/
    }
}

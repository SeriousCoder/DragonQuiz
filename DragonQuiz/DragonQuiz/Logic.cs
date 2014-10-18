using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;

class Integration
{
    public class DQuestion
    {
        public int ID{ get; set; }
        public string Content{ get; set; }
        public string Answer{ get; set; }
        public string Comment{ get; set; }
        public string Tags{ get; set; }
    };

    public struct Request
    {
        public int Number;
        public string Tags;
        public void setRequest(int n, string tags)
        {
            Number = n;
            Tags = tags;
        }
    };


    public static List<DQuestion> getPackage(Request request)
    {

        List<DQuestion> l = new List<DQuestion>();
        for (int i = 1; i <= request.Number; ++i)
            {        DQuestion q = new DQuestion();
        q.Content = "aaa";
        q.Answer = "tt";
        q.Tags = "#azaza";
                l.Add(q);
            }
        return l;
    }


}
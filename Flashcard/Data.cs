using System;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace Flashcard
{
    public static class Data
    {
        public static List<President> list = new List<President>();

        public static void DataLoad()
        {
            var client = new WebClient();
            var url = "https://www.nadworny.com/websvc/presidents.txt";
       
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            var data = client.OpenRead(url);



            using (StreamReader sr = new StreamReader(data))
            {
                sr.ReadLine();
                var rs = sr.ReadToEnd();

                var result = rs.Split('\n');
                int count = 0;
                foreach(var var in result)
                {
                    count++;

                    if(count < 45)
                    {
                        var resultTwo = var.Split('\t');
                        list.Add(new President(resultTwo[0], resultTwo[2]));
                    }
                }
            }





    }
    }
}

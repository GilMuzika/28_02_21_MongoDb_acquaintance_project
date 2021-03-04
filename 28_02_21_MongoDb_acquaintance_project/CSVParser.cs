using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _28_02_21_MongoDb_acquaintance_project
{
    public static class CSVParser
    {




        /// <summary>
        /// 
        /// </summary>
        /// <param name="urlOrPath">May be global URL to a file or a local path</param>
        /// <returns></returns>
        static public Dictionary<string, List<string>> ParseCSV(string urlOrPath)
        {
            return ParseCSVStream(GetStreamFromUrlOrFile(urlOrPath));
        }

        static public async Task<Dictionary<string, List<string>>> ParseCSVAsync(string urlOrPath)
        {
            return await Task.Run(() => 
            {
                return ParseCSV(urlOrPath);
            });
        }




        static private Dictionary<string, List<string>> ParseCSVStream(Stream rawCSVairlinesData)
        {
            Dictionary<string, List<string>> listDicts = new Dictionary<string, List<string>>();
            string[] captions = new string[0];
            using (TextFieldParser parser = new TextFieldParser(rawCSVairlinesData, Encoding.Default))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                int globalCount = 0;
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                    if(globalCount == 0)
                        captions = fields;
                    
                    int count = 0;                    
                    foreach (string field in fields)
                    {
                        if(globalCount == 0)
                        {
                            listDicts.Add(field, new List<string>());
                            
                        }
                        else
                        {
                            listDicts[captions[count]].Add(field);
                        }
                        count++;
                    }

                    


                    globalCount++;
                    //listDicts.Add(dict);
                }
            }
            return listDicts;
        }



        public static Stream GetStreamFromUrlOrFile(string urlOrPath)
        {
            byte[] imageData = null;

            using (var wc = new System.Net.WebClient())
                imageData = wc.DownloadData(urlOrPath);

            return new MemoryStream(imageData);
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using Ganss.Excel;
using Newtonsoft.Json;
using System.IO;

namespace TestAlfaEduard
{
    internal class WriteAdd
    {
        public async Task WriteAddWordAsync(IEnumerable<Channel> channelList)
        {
            ///Write data to word
            try
            {
                //Create an instance for word app  
                Word.Application winword = new Word.Application();

                //Set animation status for word application  
                winword.ShowAnimation = false;

                //Set status for word application is to be visible or not.  
                winword.Visible = true;

                //Create a missing variable for missing value  
                object missing = System.Reflection.Missing.Value;

                //Create a new document  
                Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                if (channelList == null)
                {
                    Console.WriteLine("Данные из файла не были взяты!");
                    return;
                }

                Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);

                foreach (Channel channel in channelList)
                {
                    para1.Range.Text = $"\t{channel.title} " + Environment.NewLine;
                    para1.Range.Text = $"\t{channel.link}" + Environment.NewLine;
                    para1.Range.Text = $"\t{channel.description} " + Environment.NewLine;
                    para1.Range.Text = $"\t{channel.category} " + Environment.NewLine;
                    para1.Range.Text = $"\t{channel.pubDate}\n\n\n " + Environment.NewLine;
                }
                Console.WriteLine("Данные успешно были записаны в WordAdd.docx файл!");
                channelList = null;

                await Task.Delay(1000);

                //Save the document  
                object filename = "WordApp.docx";
                document.SaveAs2(ref filename);
                document.Close(ref missing, ref missing, ref missing);
                document = null;
                winword.Quit(ref missing, ref missing, ref missing);
                winword = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

        }

        public async Task WriteAddExcelAsync(IEnumerable<Channel> channelList)
        {

            var excelMapper = new ExcelMapper();
            await excelMapper.SaveAsync("channel.xlsx", channelList, "Channel");

        }

        public async Task WriteAddJsonAsync(IEnumerable<Channel> channelList)
        {

            string json = JsonConvert.SerializeObject(channelList);
            await File.WriteAllTextAsync(@"path.json", json);
        }

    }
}
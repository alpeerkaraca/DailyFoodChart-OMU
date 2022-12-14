using HtmlAgilityPack;
using System.IO;
using System.Net.Http;
using System.Globalization;
using System.Diagnostics;
using System.Text;
namespace Yemek{
    class Program
    {
        public static void Main(){
            DateTime date= DateTime.Now;
            String[] foodListHolder;
            String[] foodList = new string[5];
            Console.OutputEncoding = Encoding.UTF8;
            int i = 0;

            var url = "https://sks.omu.edu.tr/gunun-yemegi/";
            
            var HttpClient = new HttpClient();

            var html = HttpClient.GetStringAsync(url);

            var doc = new HtmlDocument();

            doc.LoadHtml(html.Result);

            var htmlNodes = doc.DocumentNode.SelectNodes("//div/table/tbody/tr");
            foodListHolder = new string[htmlNodes.Count];
            foreach(var htmlNode in htmlNodes) foodListHolder[i++] = htmlNode.InnerText;
            int index = Int32.Parse(date.Day.ToString()) + 2;
            foodList = foodListHolder[index].Split("\n",System.StringSplitOptions.RemoveEmptyEntries);

            Console.Write($"️🗓️Bugünün Tarihi: {date.ToLongDateString()}\nGünün Çorbası: {foodList[2]}\n🍱Ana Yemek: {foodList[3]}\n🍚Ara Yemek: {foodList[4]}");
            Console.Write($"\n🍑Yan Ürün: {foodList[5]}\n\U0001f944İblis Aletta'dan Bol Afiyetlerle 🧑🏼‍🍳");
        /*
            Instagram: https://instagram.com/alpeerkaraca
            Github: https://github.com/alpeerkaraca
            Twitter: https://twitter.com/alpeerkaraca
            Linkedin: https://linkedin.com/in/alpeerkaraca
            Discord: Mashiro Shiina#7086
            Website: https://alpeerkaraca.github.io
        */
        }

    }

}       //Index = current day + 2 (cause of empty lines on html code)

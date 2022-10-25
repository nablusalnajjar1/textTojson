using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;


namespace textToJson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var filename = "C:\\Users\\nablus\\batch_1_all_annotated.txt";
            var lines = File.ReadAllText(filename);
            //lines= Regex.Replace(lines, @"", " ");
            var pattern = @"<--[^>]*-->";
            //var pattern3 = @"_.*\s";
            //  var pattern2 = @"[^\u0600-\u06FF]+";
            var matches = Regex.Split(lines, pattern);
            matches = matches.Take(matches.Length - 1).ToArray();
            var obj = new Rootobject();
         
            foreach (var item in matches)
            {
                var sub = new Class1();
                var mainlist = item.Replace("\r", "").Replace(Environment.NewLine, " ").Replace("\n"," ").Split(' ').ToList();
                
                string lastText = string.Empty;
                var joinlist=new List<string>();
                var count = 0;
                var index=0;
               
                foreach (var pair in mainlist)
                {
                    if (pair != "")
                    {
                        var token = new Token();
                        var tok = new List<Token>();
                        var sp = new List<Span>();
                        var span = new Span();
                       // var pairwithoutNewLine = pair.Replace(Environment.NewLine, " ");
                        var split = pair.Split('_').ToList();
                        token.text = split[0].Replace("\r", "").Replace("\n", "");
                        token.start = index;
                        token.end = token.start + split[0].Length - 1;
                        token.id = count;
                        token.ws = true;
                        span.start = token.start;
                        span.end = token.end;
                        span.token_end = token.id;
                        span.token_start = token.id;
                        span.label = split[1].Replace("\r", "").Replace("\n", "");
                        count++;
                        index += split[0].Length + 1;

                        joinlist.Add(split[0]);
                        sub.spans.Add(span);
                        sub.tokens.Add(token);
                    }
                }
                lastText = string.Join(" ", joinlist);
                sub.text = lastText;
                obj.Property1.Add(sub);
            }
            var string2 = "دولي / كوريا الشمالية تعيد قنوات الاتصال مع جارتها الجنوبية 4 تشرين الأول ( بترا ) - أعادت كوريا الشمالية قنوات الاتصال عبر الخط الساخن مع جارتها الجنوبية ، اليوم الاثنين ، داعية إياها إلى تنشيط الجهود الرامية إلى تحسين العلاقات الثنائية . وذكرت وكالة الأنباء الكورية المركزية ، أن بيونغ يانغ ستقوم بإعادة تشغيل اتصالات الخط الساخن صباح اليوم ، بموجب قرار زعيم كوريا الشمالية كيم جونغ أون . وحثت بيونغ يانغ ، سيئول على بذل جهود إيجابية لتطبيع العلاقات بين الشمال والجنوب وتنفيذ مهماتها التي يجب أن تمثل الأولوية لفتح آفاق مشرقة للمستقبل . وكانت سلطات كوريا الشمالية قد أغلقت اتصالات الخط الساخن مع الطرف الجنوبي في التاسع من حزيران 2020 ردا على إرسال ناشطين كوريين جنوبيين بالونات هوائية تحمل منشورات دعائية إلى أراضي سيطرة الجانب الشمالي . وفي تموز الماضي ، تم إحياء الخط لعدة أيام قبل أن يتم إغلاقه من جديد احتجاجا على تدريبات عسكرية نفذتها كوريا الجنوبية والولايات المتحدة . - - ( يترا ) / أغ / اص / وم";
            var string1 = "دولي / كوريا الشمالية تعيد قنوات الاتصال مع جارتها الجنوبية عمان 4 تشرين الأول ( بترا ) - أعادت كوريا الشمالية قنوات الاتصال عبر الخط الساخن مع جارتها الجنوبية ، اليوم الاثنين ، داعية إياها إلى تنشيط الجهود الرامية إلى تحسين العلاقات الثنائية . وذكرت وكالة الأنباء الكورية المركزية ، أن بيونغ يانغ ستقوم بإعادة تشغيل اتصالات الخط الساخن صباح اليوم ، بموجب قرار زعيم كوريا الشمالية كيم جونغ أون . وحثت بيونغ يانغ ، سيئول على بذل جهود إيجابية لتطبيع العلاقات بين الشمال والجنوب وتنفيذ مهماتها التي يجب أن تمثل الأولوية لفتح آفاق مشرقة للمستقبل . وكانت سلطات كوريا الشمالية قد أغلقت اتصالات الخط الساخن مع الطرف الجنوبي في التاسع من حزيران 2020 ردا على إرسال ناشطين كوريين جنوبيين بالونات هوائية تحمل منشورات دعائية إلى أراضي سيطرة الجانب الشمالي . وفي تموز الماضي ، تم إحياء الخط لعدة أيام قبل أن يتم إغلاقه من جديد احتجاجا على تدريبات عسكرية نفذتها كوريا الجنوبية والولايات المتحدة . - - ( يترا ) رصد / أغ / اص / وم";
            int ab = string1.Length;
            int cd = string2.Length;
            string json = JsonConvert.SerializeObject(obj.Property1);
            File.WriteAllText(@"C:\Users\nablus\Final.jsonl", json);
        }
    }
}

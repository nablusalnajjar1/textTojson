using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textToJson
{

    public class Rootobject
    {
        public List<Class1> Property1 { get; set; }=new List<Class1>();
    }

    public class Class1
    {
        public string text { get; set; }
        public List<Token> tokens { get; set; }= new List<Token>();
        public List<Span> spans { get; set; }= new List<Span>();
    }

    public class Token
    {
        public string text { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public int id { get; set; }
        public bool ws { get; set; }
    }

    public class Span
    {
        public int start { get; set; }
        public int end { get; set; }
        public int token_start { get; set; }
        public int token_end { get; set; }
        public string label { get; set; }
    }

}

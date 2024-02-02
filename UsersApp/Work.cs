using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp
{
    class Work
    {
        public int id { get; set; }
        private string shifr, text, key;
        public string Shifr
        {
            get { return shifr; }
            set { shifr = value; }
        }
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        public Work() { }
        public Work(string shifr, string text, string key)
        {
            this.shifr = shifr;
            this.text = text;
            this.key = key;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _output;
        public string Output => _output;

        private string _seq;

        public Blue_2(string input, string sequence) : base(input)
        {
            _output = null;
            _seq = sequence.ToLower();
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(_input) || string.IsNullOrEmpty(_seq))
            {
                _output = string.Empty;
                return;
            }
            string[] words = _input.Split(' ');
            string res = "";
            string sep = "";
            foreach (string word in words)
            {
                if (string.IsNullOrEmpty(word) || string.IsNullOrWhiteSpace(word)) continue;
                if (!word.ToLower().Contains(_seq))
                {
                    res += sep + word;
                    sep = " ";
                }
                else if ((!char.IsLetter(word[0])) && word.Length > 0)
                {
                    res += " " + word[0] + word[0];
                    sep = " ";
                }
                if ((!char.IsLetter(word[word.Length - 1])) && word.Length > 0  && word.ToLower().Contains(_seq))
                {
                    res += word[word.Length - 1];
                    sep = " ";
                }
            }

            //var words = _input.Split(' ');
            //var res = "";
            //foreach (var word in words)
            //{
            //    var w = word.ToLower();
            //    if (!w.Contains(_seq))
            //    {
            //        res += " " + word;
            //    }
            //}
            //_output = string.Join(" ", res).Trim();
            _output = res;
        }
        public override string ToString()
        {
            if (_output.Length == 0 || string.IsNullOrEmpty(_output)) return string.Empty;
            return _output;
        }
    }
}

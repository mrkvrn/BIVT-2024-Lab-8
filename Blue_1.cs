using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;
        public string[] Output => _output;

        public Blue_1(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(_input))
            {
                _output = null;
                return;
            }

            string[] input = _input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] res = new string[input.Length];
            int count = 0;
            string line = "";
            foreach (string word in input)
            {
                if (string.IsNullOrEmpty(word) || string.IsNullOrWhiteSpace(word)) continue;
                if (line.Length == 0) line = word;
                else if (line.Length + word.Length <= 49) line += " " + word;
                else
                {
                    res[count++] = line;
                    line = word;
                }
            }
            if (!string.IsNullOrEmpty(line)) res[count++] = line;
            _output = new string[count];
            Array.Copy(res, _output, count);
        }
        public override string ToString()
        {
            if (_output == null) return null;
            string res = "";
            for (int i = 0; i < _output.Length; i++)
            {
                res += $"{_output[i]}";
                if (i < _output.Length - 1)
                {
                    res += Environment.NewLine;
                }
            }
            if (string.IsNullOrEmpty(res)) return null;
            res = res.TrimEnd();
            return res;
        }
    }
}

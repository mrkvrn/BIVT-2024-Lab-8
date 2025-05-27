using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;
        //public (char, double)[] Output => _output;
        public (char, double)[] Output
        {
            get
            {
                if (_output == null) return null;

                (char, double)[] output = new (char, double)[_output.Length];
                Array.Copy(_output, output, _output.Length);
                return output;
            }
        }
        public Blue_3(string input) : base(input)
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
            var words = _input.Split(new[] { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' }, StringSplitOptions.RemoveEmptyEntries);
            int[] letters = new int[char.MaxValue];
            int wcount = 0;
            int unique = 0;
            foreach (string word in words)
            {
                if (word.Length == 0) continue;
                char first = char.ToLower(word[0]);
                if (char.IsLetter(first))
                {
                    letters[first]++;
                    wcount++;
                }
            }
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] > 0) unique++;
            }

            _output = new (char, double)[unique];
            int ind = 0;
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] > 0)
                {
                    double res = Math.Round(letters[i] * 100.0 / wcount, 4);
                    _output[ind++] = ((char)i, res);
                }
            }

            Array.Sort(_output, (x, y) =>
            {
                int comparison = y.Item2.CompareTo(x.Item2);
                return comparison != 0 ? comparison : x.Item1.CompareTo(y.Item1);
            });
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return string.Empty;
            //string res = "";
            var res = new StringBuilder();
            
            for (int i = 0; i < _output.Length; i++)
            {
                //res += $"{_output[i].Item1} - {Math.Round(_output[i].Item2, 4)}";
                res.Append($"{_output[i].Item1} - {_output[i].Item2:F4}");
                if (i < _output.Length - 1)
                {
                    res.AppendLine();
                }
            }
            //res = res.TrimEnd('\n');
            return res.ToString();
        }
    }
}

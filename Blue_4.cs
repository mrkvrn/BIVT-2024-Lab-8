using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;
        public int Output => _output;

        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(_input)) return;
            var words = _input.Split(' ','.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/');

            int sign = 1;
            int ind = 0;

            foreach (string word in words)
            {
                if (string.IsNullOrWhiteSpace(word) || string.IsNullOrEmpty(word)) continue;

                if (char.IsDigit(word[0]) || (word.Length > 1 && char.IsDigit(word[1]) && word[0] == '-'))
                {
                    int res = 0;
                    if (word[0] == '-')
                    {
                        sign = -1;
                        ind = 1;
                    }
                    foreach (char i in word)
                    {
                        if (char.IsDigit(i))
                        {
                            res = res * 10 + (i - '0');
                        }

                    }
                    res *= sign;
                    _output += res;
                }
            }
        }

        public override string ToString()
        {
            return $"{_output}";
        }

    }
}
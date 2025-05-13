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
                _output = "";
                return;
            }
            var words = _input.Split(' ');
            var res = "";

            foreach (var word in words)
            {
                var w = word.ToLower();
                if (!w.Contains(_seq))
                {
                    res += " " + word;
                }
            }

            _output = string.Join(" ", res).Trim();
        }
        public override string ToString()
        {
            if (_output == null) return null;
            return _output;
        }
    }
}

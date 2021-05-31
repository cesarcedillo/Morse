using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morse
{
    public class DecodeSentence : ICloneable
    {
        private string sentence;
        private string value;
        private int position;

        public string Value { get => value; set => this.value = value; }
        public string Sentence { get => sentence; set => sentence = value; }
        public int Position { get => position; set => position = value; }

        public DecodeSentence()
        {
            Value = "";
            Position = 0;
            Sentence = "";
        }

        public object Clone() => this.MemberwiseClone();

        public override string ToString() => Sentence;

    }
}

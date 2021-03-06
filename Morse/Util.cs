using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morse
{
    public static class Util
    {
        public static readonly Dictionary<string, string> morseCode = new()
        {
            {".-", "A"},
            {"-...","B"},
            {"-.-.","C"},
            {"-..","D"},
            {".","E"},
            {"..-.","F"},
            {"--.","G"},
            {"....","H"},
            {"..","I"},
            {".---","J"},
            {"-.-","K"},
            {".-..","L"},
            {"--","M"},
            {"-.","N"},
            {"---","O"},
            {".--.","P"},
            {"--.-","Q"},
            {".-.","R"},
            {"...","S"},
            {"-","T"},
            {"..-","U"},
            {"...-","V"},
            {".--","W"},
            {"-..-","X"},
            {"-.--","Y"},
            {"--..","Z"}
        };

    }
}

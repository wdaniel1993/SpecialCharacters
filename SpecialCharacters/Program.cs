using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecialCharacters.Input;
using SpecialCharacters.Output;
using SpecialCharacters.Process;

namespace SpecialCharacters
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var inputReader = new InputReader();
            var outputWriter = new OutputWriter();
            var dataProcessor = new DataProcessor();

            var input = inputReader.Read();

            var output = dataProcessor.Process(input);

            outputWriter.Write(output);
        }
    }
}

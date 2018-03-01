using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecialCharacters.Input;
using SpecialCharacters.Models;
using SpecialCharacters.Output;
using SpecialCharacters.Process;

namespace SpecialCharacters
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var dataPath = Path.Combine(basePath, @"data");

            var inputReader = new InputReader();
            var outputWriter = new OutputWriter();
            var dataProcessor = new DataProcessor();

            var input = inputReader.Read(Path.Combine(dataPath, "a_example.in"));

            var output = dataProcessor.Process(input);

            outputWriter.Write(output, Path.Combine(dataPath, "solution.out"));
        }
    }
}

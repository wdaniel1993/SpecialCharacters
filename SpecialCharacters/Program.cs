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
            var fileNames = new string[]{
                "a_example",
                "b_should_be_easy",
                "c_no_hurry",
                "d_metropolis",
                "e_high_bonus"
            };

            foreach (var fileName in fileNames)
            {
                var inputReader = new InputReader();
                var outputWriter = new OutputWriter();
                var dataProcessor = new DataProcessor();

                var input = inputReader.Read(Path.Combine(dataPath, fileName + ".in"));

                var output = dataProcessor.Process(input);

                outputWriter.Write(output, Path.Combine(dataPath, fileName + ".out"));
            }
        }
    }
}

using System;

namespace swiftly_services_exercise
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 1) {
                Console.WriteLine("Usage: swiftly-services-exercise <INPUT_FILE>");
                return 1;
            }

            string path = args[0];
            try {
                SampleFormatParser parser = new SampleFormatParser();
                foreach (string line in System.IO.File.ReadLines(path)) {
                    ProductRecord product_record = parser.Parse(line);
                    Console.WriteLine(product_record.ToString());
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return 2;
            }

            return 0;
        }
    }
}

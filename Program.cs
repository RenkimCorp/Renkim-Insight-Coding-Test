using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renkim_Insight_Coding_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Parse comma delimited file located in the root folder. It is named the following: TestFile.txt");
            Console.WriteLine("Print out the following fields for records that are addressed to NY and FL: id, first_name, last_name");

            Console.WriteLine("Recreate an output file for all the records in the input test file that contain the following fields: id, first_name, last_name");
            Console.WriteLine("The new output file should be named the following: OutTestFile.txt");
        }
    }
}

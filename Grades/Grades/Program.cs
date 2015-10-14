using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook();

            book.NameChanged += new NameChangedDelegate(OnNameChangedReportChange);
            book.NameChanged += new NameChangedDelegate(OnNameChangedDrawStars);
            // equivalent to the above (shorthand)
            book.NameChanged += OnNameChangedReportChange;
            book.NameChanged += OnNameChangedDrawStars;
            // can also remove
            book.NameChanged -= OnNameChangedReportChange;
            // Below is valid for Delegates but invalid for Events
            //book.NameChanged = OnNameChanged2;

            book.Name = "Scott's Grade Book";
            book.Name = "Grade Book";

            book.Name = "";
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            writeResult("Average", stats.AverageGrade);
            writeResult("Highest", (int)stats.HighestGrade);
            writeResult("Lowest", stats.LowestGrade);
            writeResult(stats.Description, stats.LetterGrade);
        }

        static void writeResult(string description, float result)
        {
            Console.WriteLine("{0}: {1:F2}", description, result);
            //Console.WriteLine($"{description}: {result:F2}");
            //Console.WriteLine(description + ": " + result);
            //Console.WriteLine("{0}: {1:C}", description, result);
        }
        static void writeResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }
        static void writeResult(string description, string result)
        {
            Console.WriteLine(description + ": " + result);
        }
        static void OnNameChangedReportChange(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changed name from {args.Existing} to {args.NewName}");
        }
        static void OnNameChangedDrawStars(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("***");
        }
    }
}

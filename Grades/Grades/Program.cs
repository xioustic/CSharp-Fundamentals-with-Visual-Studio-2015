using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();

            AddEventListeners(book);
            GetBookName(book);
            AddBookGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }

        private static IGradeTracker CreateGradeBook()
        {
            // becasuse of polymorphism, this could also return a new GradeBook();
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }


            Console.WriteLine(book.Name);
            writeResult("Average", stats.AverageGrade);
            writeResult("Highest", (int)stats.HighestGrade);
            writeResult("Lowest", stats.LowestGrade);
            writeResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                // since WriteGrades expects a TextWriter, you can pass in Console.Out (TextWriter)
                // or a StreamWriter instance like outputFile, since its compatible with TextWriter
                book.WriteGrades(outputFile);
            }
        }

        private static void AddBookGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            book.Name = "Scott's Grade Book";
            book.Name = "Grade Book";

            Console.WriteLine("Enter a name");

            try
            {
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddEventListeners(IGradeTracker book)
        {
            book.NameChanged += new NameChangedDelegate(OnNameChangedReportChange);
            book.NameChanged += new NameChangedDelegate(OnNameChangedDrawStars);
            // equivalent to the above (shorthand)
            book.NameChanged += OnNameChangedReportChange;
            book.NameChanged += OnNameChangedDrawStars;
            // can also remove
            book.NameChanged -= OnNameChangedReportChange;
            // Below is valid for Delegates but invalid for Events
            //book.NameChanged = OnNameChanged2;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        // create delegate type Writer that can take any function
        // with signature "void <functionname>(string <arg>)"
        public delegate void Writer(string message);

        // create Logger class with a WriteMessage method
        public class Logger
        {
            private string _name;

            public Logger(string logname)
            {
                _name = logname;
            }

            public void WriteMessage(string message)
            {
                Console.WriteLine("{0}: {1}",_name,message);
            }
        }

        static void Main(string[] args)
        {
            // create two logger objects
            Logger logger = new Logger("mylog1");
            Logger logger2 = new Logger("mylog2");

            // create new Writer instance with logger1's WriteMessage
            // method as the referenced method for the Writer
            Writer writer = new Writer(logger.WriteMessage);

            // also chain on logger2.WriteMessage to this delegate
            writer += logger2.WriteMessage;

            writer("Success!!");

            /*
            mylog1: Success!!
            mylog2: Success!!
            */

            // now assign only the first logger's method on the delegate
            writer = logger.WriteMessage;

            writer("Less success!!");

            /*
            mylog1: Less success!!
            */
        }
    }
}

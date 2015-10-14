using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class NameChangedEventArgs : EventArgs
    {
        public string Existing { get; set; }
        public string NewName { get; set; }
    }
}

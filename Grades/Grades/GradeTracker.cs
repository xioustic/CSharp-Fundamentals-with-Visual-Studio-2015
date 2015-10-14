using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker
    {
        // inheriting subclasses must implement these in accordance with these signatures
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);

        // this property implementation Name is the same for all subclasses
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                if (_name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.Existing = _name;
                    args.NewName = value;
                    NameChanged(this, args);
                }
                _name = value;
            }
        }

        // all GradeTrackers will have a NameChangedDelegate called NameChanged
        public event NameChangedDelegate NameChanged;

        // only allow subclasses to access the internal name representation
        protected string _name;
    }
}

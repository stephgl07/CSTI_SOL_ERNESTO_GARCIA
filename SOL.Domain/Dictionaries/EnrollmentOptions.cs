using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Dictionaries
{
    public static class EnrollmentOptions
    {
        public static readonly Dictionary<int, string> EnrollmentTypes = new Dictionary<int, string>
        {
            { 1, "PRESENCIAL" },
            { 2, "REMOTO" }
        };
    }
}

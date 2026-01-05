using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHealth.Domain.DomainExceptions
{
    public class DomainException : Exception
    {
        public DomainException(string msg) : base(msg)
        { }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind
{
    abstract class Error
    {
        protected string ErrorString { get; set; }

        public override string ToString() =>
            ErrorString;
    }
}

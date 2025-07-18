using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services
{
    public class InputValidator : IInputValidator
    {
        public bool isPhoneValidation(string phoneNumber)
        {
            return !string.IsNullOrWhiteSpace(phoneNumber);
        }


    }
}

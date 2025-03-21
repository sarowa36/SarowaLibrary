﻿using System.Text.RegularExpressions;

namespace SarowaLibrary.ToolsLayer.Validation
{
    public static class EmailValidate
    {
        public static bool IsEmail(this string text) => Regex.IsMatch(text, @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$");
    }
}

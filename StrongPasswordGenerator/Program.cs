using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    public static void Main(string[] args)
    {
        var extraChars = 0;
        var digitOccured = false;
        var lowerCaseOccured = false;
        var upperCaseOccured = false;
        var specialCharsOccured = false;

        Console.ReadLine(); // Discard the first line (optional)
        var nextChar = Console.Read();

        while (nextChar != -1)
        {
            if (nextChar >= 48 && nextChar <= 57)
                digitOccured = true;

            if (nextChar >= 97 && nextChar <= 122)
                lowerCaseOccured = true;

            if (nextChar >= 65 && nextChar <= 90)
                upperCaseOccured = true;

            if ((nextChar == 33 || nextChar == 64 || nextChar == 94 || nextChar == 45) ||  // !@^-
                (nextChar >= 35 && nextChar <= 38) ||  // #$%&
                (nextChar >= 40 && nextChar <= 43))   // ()*+
                specialCharsOccured = true;

            if (digitOccured && lowerCaseOccured && upperCaseOccured && specialCharsOccured)
                break;

            nextChar = Console.Read();
        }

        extraChars += !digitOccured ? 1 : 0;
        extraChars += !lowerCaseOccured ? 1 : 0;
        extraChars += !upperCaseOccured ? 1 : 0;
        extraChars += !specialCharsOccured ? 1 : 0;

        if (extraChars + (int)nextChar < 6) // Handle potential negative extraChars
            extraChars = 6 - (extraChars + (int)nextChar);

        Console.WriteLine(extraChars);
    }
}

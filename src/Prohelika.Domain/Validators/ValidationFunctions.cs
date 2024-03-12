using System.Text.RegularExpressions;

namespace Prohelika.Domain.Validators;

public static class ValidationFunctions
{
    /// Checks if string is email.
    public static bool IsValidEmail(
        string? inputString,
        bool isRequired = false
    )
    {
        var isInputStringValid = !isRequired && string.IsNullOrEmpty(inputString);

        if (inputString == null || string.IsNullOrEmpty(inputString)) return isInputStringValid;
        const string pattern =
            """^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$""";

        var regExp = new Regex(pattern);

        isInputStringValid = regExp.IsMatch(inputString);

        return isInputStringValid;
    }

    /// Password should have,
    /// at least a upper case letter
    ///  at least a lower case letter
    ///  at least a digit
    ///  at least a special character [@#$%^&+=]
    ///  length of at least 4
    /// no white space allowed
    public static bool IsValidPassword(
        string? inputString,
        bool isRequired = false)
    {
        var isInputStringValid = !isRequired && string.IsNullOrEmpty(inputString);

        if (string.IsNullOrEmpty(inputString)) return isInputStringValid;
        const string pattern = """^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\d]){1,})(?=(.*[\W]){1,})(?!.*\s).{8,}$""";

        var regExp = new Regex(pattern);

        isInputStringValid = regExp.IsMatch(inputString);

        return isInputStringValid;
    }

    /// Checks if string consist only Alphabet. (No Whitespace)
    public static bool IsText(
        string? inputString,
        bool isRequired = false)
    {
        var isInputStringValid = !isRequired && string.IsNullOrEmpty(inputString);

        if (string.IsNullOrEmpty(inputString)) return isInputStringValid;
        const string pattern = """^[a-zA-Z]+$""";

        var regExp = new Regex(pattern);

        isInputStringValid = regExp.IsMatch(inputString);

        return isInputStringValid;
    }

    /// Checks if string is phone number
    public static bool IsValidPhone(
        string? inputString,
        bool isRequired = false)
    {
        var isInputStringValid = !isRequired && string.IsNullOrEmpty(inputString);

        if (string.IsNullOrEmpty(inputString)) return isInputStringValid;
        if (inputString.Length is > 16 or < 6) return false;

        var pattern = """^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$""";

        var regExp = new Regex(pattern);

        isInputStringValid = regExp.IsMatch(inputString);

        return isInputStringValid;
    }
}
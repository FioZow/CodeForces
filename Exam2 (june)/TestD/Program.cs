
var passwordsCount = int.Parse(Console.ReadLine());
while (passwordsCount != 0)
{
    var password = Console.ReadLine();

    var isCursiveLetter = false;
    var isSmallLetter = false;
    var isVowel = false;
    var isConsonant = false;
    var isNumber = false;

    var vowelChars = new char[] { 'e', 'u', 'i', 'o', 'a', 'y' };
    var consontantChars = new char[] { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Z' };

    foreach (var item in password)
    {
        if (!isCursiveLetter)
        {
            if (item > 64 && item < 91)
            {
                isCursiveLetter = true;
            }
        }
        if (!isSmallLetter)
        {
            if (item > 96 && item < 123)
            {
                isSmallLetter = true;
            }
        }
        if (!isVowel)
        {
            var l = item.ToString().ToLower().ToCharArray()[0];
            foreach (var vow in vowelChars)
            {
                if (vow == l)
                {
                    isVowel = true;
                    break;
                }
            }
        }
        if (!isConsonant)
        {
            var l = item.ToString().ToUpper().ToCharArray()[0];
            foreach (var consontant in consontantChars)
            {
                if (consontant == l)
                {
                    isConsonant = true;
                    break;
                }
            }
        }
        if (!isNumber)
        {
            if (item > 47 && item < 58)
            {
                isNumber = true;
            }
        }
    }

    if (!isCursiveLetter)
    {
        if (!isVowel)
        {
            password += "A";
            isVowel = true;
        }
        else
        {
            password += "B";
            isConsonant = true;
        }
    }

    if (!isSmallLetter)
    {
        if (!isVowel)
        {
            password += "a";
            isVowel = true;
        }
        else
        {
            password += "b";
            isConsonant = true;
        }
    }

    if (!isVowel)
        password += "a";
    if (!isConsonant)
        password += "c";
    if (!isNumber)
        password += "1";

    Console.WriteLine(password);

    passwordsCount--;
}



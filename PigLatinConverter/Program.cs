using System.Linq;
using System.Text.RegularExpressions;

public class Program
{

    private static void Main()
    {
        bool goAgain = true;

        while (goAgain = true)
        {


            Console.WriteLine("Enter a sentence to convert to PigLatin:");
            string sentence = Console.ReadLine().ToLower();
            char[] sentenceDisassemble = sentence.ToCharArray();
            if (isSpecialPresent(sentence) == true)
            {

                Console.WriteLine(sentence);
                return;
            }
            var pigLatin = GetSentenceInPigLatin(sentence);
            Console.WriteLine(pigLatin);
        }
        goAgain = RunAgain();
    }


    
    private static string GetSentenceInPigLatin(string sentence)
    {
        const string vowels = "aeiou";

   
        List<string> newWords = new List<string>();
        foreach (string word in sentence.Split(' '))
        {
            string firstLetter = word.Substring(0, 1);
            string restOfWord = word.Substring(1, word.Length - 1);
            int currentLetter = vowels.IndexOf(firstLetter);

            if (currentLetter == -1)
            {
                newWords.Add(ConvertToPigLatin(word));

            }
            else
            {

                newWords.Add(word + "way");
            }
            
        }
        return string.Join(" ", newWords);
    }


public static string ConvertToPigLatin(string word)
{
    char[] letters = word.ToCharArray();

    for (int i = 0; i < letters.Length; i++)
    {
        //Well start at index 0
        //if a char is a vowel we return the current index
        char letter = letters[i];
        if (isVowel(letter) == true)
        {

            string Constanants = word.Substring(0, i);

            string newWord = word.Remove(0, i);
            string PigLatin = newWord + Constanants + "ay";
            return PigLatin;
        }
    }


    //If C# reaches below the for, that means no characters in the string
    //are vowels so we return -1, which is the universal sign for nothing was found
    return "";
}
    public static bool isVowel(char c)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
        if (vowels.Contains(c))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static bool
   isSpecialPresent(string str)
    {
        // ReGex to check if a string
        // contains uppercase, lowercase
        // special character & numeric value
        string regex = "^(?=.*\\d)"
                    + "(?=.*[-+_!@#$%^&*., ?]).+$";

        // Compile the ReGex
        Regex p = new Regex(regex);

        // If the string is empty
        // then print No
        if (str == null)
        {
            Console.Write("No");
            return false;
        }

        // Find match between given string
        // & regular expression
        Match m = p.Match(str);

        // Print Yes if string
        // matches ReGex
        if (m.Success)
        {
            
            return true;
        }
        else
        { 
        
        return false;
    }
    }
    public static string GetUserInput(string prompt)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine();
        return input;
    }
    
    public static bool RunAgain()
    {
        string answer = GetUserInput("Would you like to input another integer y/n?").ToLower();
        if (answer == "y")
        {
            return true;
        }
        else if (answer == "n")
        {
            return false;
        }
        else
        {
            Console.WriteLine("I'm sorry I didn't understand that");
            Console.WriteLine("Please input y or n");
            Console.WriteLine("Lets try again");
            return RunAgain();

        }
    }

}
// See https://aka.ms/new-console-template for more information


string fileText = File.ReadAllText(@"Files\textFile.txt");


//Exercises Write a program that reads a text file and displays the number of words.

Console.WriteLine(fileText.Split(' ').Length); //Output number in array

//Exercises Write a program that reads a text file and displays the longest word in the file.

Console.WriteLine(longestWord(fileText));

static string longestWord(string sentence)
{
    //return "test";
    string[] stringOfWords = sentence.Split(new Char[] { ',', ' ' });

     int biggest = 0;
     int biggestIndex = 0;

     for (int i = 0; i < stringOfWords.Length; i++)
     {
         if (biggest < stringOfWords[i].Length)
         {
             biggest = stringOfWords[i].Length;
             biggestIndex = i;
         }
     }
     return stringOfWords[biggestIndex];

}
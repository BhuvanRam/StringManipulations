using System;

public class ReverseStringByArrayIndices
{
	public static void Main()
	{
		string input = "abcdef";
    string reverseString = string.Empty;
    
    int maxIndice = 0;
    int[] indices = {2, 5};

    for(int index = 0; index < indices.Length; index++)
    {
      maxIndice = indices[index] > maxIndice ? indices[index]: maxIndice;
      int loopBreaker = index == 0 ? -1 : indices[index-1] - 1;
      for(int j= indices[index] - 1; j > loopBreaker; j--)
      {
        reverseString = reverseString + input[j];
      }
    }
    
    for(int index = input.Length - 1; index > maxIndice - 1; index--)
    {
      reverseString = reverseString + input[index];
    }
    
    Console.WriteLine(reverseString);
	}
}

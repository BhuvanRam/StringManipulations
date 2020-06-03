using System;
using System.Collections;
using System.Collections.Generic;

public class Test
{
	public static void Main()
	{
    string input = "ababcabcabababd";
    string pattern = "ababd";
    
    int lpsIndex = -1;
    List<Tuple<char, int>> lpsTable  = LongestPrefixSufixTable(pattern);
    
    for(int inputIndex = 0; inputIndex < input.Length; inputIndex++)
    {
       if(input[inputIndex] == lpsTable[lpsIndex + 1].Item1)
       {
         lpsIndex++;
       }
       else
       {
         lpsIndex = lpsTable[lpsIndex].Item2 - 1;
         if(lpsIndex != -1)
         {
           inputIndex = inputIndex - 1;
         }
       }
       
       if(lpsIndex == pattern.Length - 1)
       {
         int startIndex = (inputIndex - pattern.Length) + 1;
         int endIndex = inputIndex;
         Console.WriteLine("Pattern Found at {0} - {1}", startIndex, endIndex);
       }
    }
    
	}
  
  public static List<Tuple<char, int>> LongestPrefixSufixTable(string pattern)
  {
    List<Tuple<char, int>> lpsTable = new List<Tuple<char, int>>();
    Dictionary<char, int> indexes = new Dictionary<char, int>();
    
    int index = 1;
    foreach(char patternCharacter in pattern)
    {
      if(!indexes.ContainsKey(patternCharacter))
      {
        indexes.Add(patternCharacter, index);
        lpsTable.Add(new Tuple<char,int>(patternCharacter, 0));
      }
      else
      {
        int existingIndex = indexes[patternCharacter];
        lpsTable.Add(new Tuple<char,int>(patternCharacter, existingIndex));
      }
      index = index + 1;
    }
    
    return lpsTable;
  }
}

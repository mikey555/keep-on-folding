using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// A static class for general helpful methods
/// </summary>
public static class Helpers 
{
    /// <summary>
    /// Destroy all child objects of this transform (Unintentionally evil sounding).
    /// Use it like so:
    /// <code>
    /// transform.DestroyChildren();
    /// </code>
    /// </summary>
    public static void DestroyChildren(this Transform t) {
        foreach (Transform child in t) Object.Destroy(child.gameObject);
    }

    public static void ShowAnagrams(List<string> words)
    {
        
        var c1 = new HashSet<char>();
        c1.Add('A');
        c1.Add('B');
        c1.Add('C');
        var c2 = new HashSet<char>();
        c2.Add('A');
        c2.Add('B');
        c2.Add('D');
        Debug.Log("c1 == c2: " + c1.SetEquals(c2));

        var charArrayList = new List<(string, char[])>();
        foreach (var word in words)
        {
            Debug.Log("Word: " + word);
            char[] charArray = word.ToCharArray();
            Debug.Log(charArray.ToString());
            System.Array.Sort(charArray, Comparer<char>.Default);
            Debug.Log(charArray.ToString());

            foreach (var charArrayFromList in charArrayList)
            {
                if (charArray == charArrayFromList.Item2)
                {
                    Debug.Log(word + "/" + charArrayFromList.Item1);
                }
            }
            charArrayList.Add((word, charArray));

        }


    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class UnfoldedDie : MonoBehaviour
{

    
    List<Side> _sides;
    char[] chars;
    public List<Side> Sides {
        get{ return _sides; }
    }
    
    



    private void Awake()
    {
 
        _sides = new List<Side>(GetComponentsInChildren<Side>());
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    
    public void Init(char[] chars) {
        this.chars = chars;
        var numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };
        foreach (var side in _sides)
        {
            var randomIndex = numbers[Random.Range(0, numbers.Count)];
            numbers.Remove(randomIndex);
            side.Letter = chars[randomIndex-1].ToString().ToUpper();
        }
    }

    public void ActivateHint(string s) {
        Sides.Find(x => x.Letter.ToUpper() == s.ToUpper()).MarkAsHint();
    }
    

    



    

    
}

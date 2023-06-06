using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StreakAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    Color disabledColor = new Color(0, 0, 0, .3f);
    Color enabledColor = new Color(1, 1, 1, 1);
    [SerializeField] GameObject flame;
    
    Image image;
    
    void Awake() 
    {
        image = GetComponentInChildren<Image>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateStreak(int length) {
        if (length > 1) 
        {
            image.DOColor(enabledColor, 0.5f);
            flame.transform.DOPunchScale(flame.transform.localScale * 1.1f, 0.3f);
        } else if (length == 0) 
        {
            image.DOColor(disabledColor, 0.5f);
        }
        
    }
}

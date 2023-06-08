using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Side : MonoBehaviour
{

    [SerializeField] TMP_Text tmpText;
    Image image;
    bool isHintActivated;
    public string Letter
    {
        get => tmpText.text;
        set => tmpText.text = value;
    }
    bool isTyped;
    public bool IsTyped
    {
        get => isTyped;
    }
    
    

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isTyped = false;
        isHintActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Repaint() {
        float h, s, v;
        Color baseColor;

        /*
        if not typed and no hint
            clear
        else 
        */
        
        if (!isTyped && !isHintActivated) {
            image.color = Color.clear;
            return;
        }


        if (isHintActivated) {
            baseColor = new Color(0,1,0,0.25f);
        }
        else {
            baseColor = new Color(0,0,0,0.25f);
        }
        
        // darken by 20%
        if (isTyped) {
            Color.RGBToHSV(baseColor, out h, out s, out v);
            var newColor = Color.HSVToRGB(h, s, v - 0.2f);
            newColor = new Color(newColor.r, newColor.g, newColor.b, baseColor.a);
            image.color = newColor;
        } else {
            image.color = baseColor;
        }
        
        

        
    }

    public void MarkAsTyped()
    {
        isTyped = true;
        Repaint();
    }

    public void MarkAsUntyped()
    {
        isTyped = false;
        
        Repaint();
    }

    public void MarkAsHint() 
    {
        isHintActivated = true;
        Repaint();
        Debug.Log("hint activated on Side: " + this);
    }

    
}

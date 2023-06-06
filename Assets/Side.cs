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
        if (isHintActivated) {
            baseColor = Color.green;
        }
        else {
            baseColor = Color.clear;
        }
        
        if (isTyped) {
        
            Color.RGBToHSV(baseColor, out h, out s, out v);
            // v -= 0.2f;
            image.color = Color.HSVToRGB(h, s, 0.5f);

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
    }
}

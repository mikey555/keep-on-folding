using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterBlock : MonoBehaviour
{
    private string _letter;
    [SerializeField] TMP_Text letterText;
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponentsInChildren<TMP_Text>()[0];
    }

    // Start is called before the first frame update
    void Start()
    {
        _text.text = _letter;
    }

    public void Init(string letter)
    {
        _letter = letter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}

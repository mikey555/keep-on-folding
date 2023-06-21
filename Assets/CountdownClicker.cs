using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CountdownClicker : MonoBehaviour
{
    TMP_Text _text;
    int _number;
    [SerializeField] int _startingNumber;
    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _number = _startingNumber;
        SetTextTo(_startingNumber.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTextTo(string str)
    {
        _text.text = str;
    }

    public void Decrement()
    {

        if (_number >= 1) _number -= 1;
        SetTextTo(_number.ToString());



    }
}

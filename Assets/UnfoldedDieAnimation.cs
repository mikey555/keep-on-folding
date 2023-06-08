using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UnfoldedDieAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Enter()
    {

    }

    public void Skip()
    {

    }



    public void Shake()
    {

        // transform.DOShakePosition(.2f, strength: 40f, vibrato: 20);
        GetComponent<RectTransform>().DOMove(transform.position + Vector3.up * 100, 5f);
        // transform.DOMove(transform.position + Vector3.up * 10, 5f);


    }
}

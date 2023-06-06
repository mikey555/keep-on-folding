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

    public void Enter() {

    }

    public void Skip() {

    }



    public void Shake() {
        
        GetComponentInParent<Puzzle>().transform.DOShakePosition(.2f, strength: 4f, vibrato: 20);
    }
}

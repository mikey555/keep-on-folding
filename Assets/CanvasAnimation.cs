using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CanvasAnimation : MonoBehaviour
{
    [SerializeField] protected RectTransform _animatedElement;
    protected Canvas _canvas;
    protected Vector3 _canvasPos;

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        _canvas = GetComponentInParent<Canvas>();
        _canvasPos = _canvas.transform.localPosition;
    }

    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {

    }




}




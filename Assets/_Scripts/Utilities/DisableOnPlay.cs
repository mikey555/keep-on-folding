using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.SetActive(false);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

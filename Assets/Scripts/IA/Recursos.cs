using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recursos : MonoBehaviour
{

    public int minerios;

    void Start()
    {
        minerios = 5;
    }


    void Update()
    {
        if(minerios==0)
        {
            GetComponent<Renderer>().enabled = false;
        }
    }
}

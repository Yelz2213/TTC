using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString("isStart", "Started");
        Debug.Log("Started!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera currentcam;
    public AudioListener currentAudioListener;
    public GameObject currentItem;

    public Camera startCam;
    public AudioListener startAudioListener;
    void Start()
    {
        currentcam = startCam;
        currentAudioListener = startAudioListener;
        currentItem = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

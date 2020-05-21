using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera firstCamera;
    public AudioListener firstAL;
    public Camera secondCamera;
    public AudioListener secondAL;
    public Player player;

    void OnTriggerExit(Collider other)
    { 
        Debug.Log("Something passed here.");
        if (firstCamera.enabled == true)
        {
            firstCamera.enabled = false;
            firstAL.enabled = false;
            secondCamera.enabled = true;
            secondAL.enabled = true;
            player.currentcam = secondCamera;
            player.currentAudioListener = secondAL;
        } else if (secondCamera.enabled == true)
        {
            secondCamera.enabled = false;
            secondAL.enabled = false;
            firstCamera.enabled = true;
            firstAL.enabled = true;
            player.currentcam = firstCamera;
            player.currentAudioListener = firstAL;
        }
    }
}
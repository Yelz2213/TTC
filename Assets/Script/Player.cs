using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Camera currentcam;
    public AudioListener currentAudioListener;
    public GameObject currentItem;

    public Vector3 currentPosition;
    public Vector3 scene_one_position;

    public Camera startCam;
    public AudioListener startAudioListener;

    bool isFirstTime;
    void Start()
    {
        
    }

    void Update()
    {
        currentPosition = this.transform.position;
    }
}

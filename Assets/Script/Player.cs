using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public Camera currentcam;
    public AudioListener currentAudioListener;
    public GameObject currentItem;

    public Vector3 currentPosition;
    public Vector3 scene_one_position;

    public Interactable focus;

    public Camera startCam;
    public AudioListener startAudioListener;

    public Movement movement;
    public bool isInteracting = false;
    
    void Start()
    {
    }

    public void Update()
    {
        currentPosition = this.transform.position;
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(myRay, out hitInfo, 100))
                {
                    Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        SetFocus(interactable);
                    }
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
            movement.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }
}

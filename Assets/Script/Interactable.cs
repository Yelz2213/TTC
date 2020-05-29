using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus;
    bool isInteracting;
    Transform player;

    public Dialog dialog = null;
    public CheckBaggage checkBaggage = null;
    public Immigration immigration = null;

    public virtual void Interact()
    {
       // Debug.Log("Interacting with " + transform.name);
    }

    void Start()
    {
        isFocus = false;
        isInteracting = false;
    }

    void Update()
    {
        //Debug.Log("isFocus: " + isFocus);
        if (isFocus && !isInteracting)
        {
            // If we are close enough
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                isInteracting = true;
            }
        }

        if (dialog != null)
        {
            if (dialog.textDisplay.text == dialog.sentences[dialog.index])
            {
                if (gameObject.tag != "RoadBlock")
                {
                    dialog.continueButton.SetActive(true);
                    //checkBaggage.continueButton.SetActive(true);

                    Debug.Log(immigration.gameObject.tag);
                    //if (immigration.gameObject.tag == ("Immigration"))
                    //{
                    //    immigration.continueButton.SetActive(true);
                    //    immigration.continueButton2.SetActive(true);
                    //}

                }
                else if (gameObject.tag == "RoadBlock")
                {
                    dialog.continueButton.SetActive(true);
                    if (dialog.index == 1)
                    {
                        dialog.continueButton.SetActive(false);
                        Debug.Log("RoadBlock");
                    }
                }
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        //Debug.Log("isFocus: " + isFocus);
        isFocus = true;
        player = playerTransform;
        isInteracting = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        isInteracting = false;
    }

    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null) {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : Interactable
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed;
    public GameObject textbackground;
    public GameObject continueButton;
    public GameObject nextStageButton = null;
    public GameObject inventoryButton = null;

    public override void Interact()
    {
        //Debug.Log("Interacting");
        base.Interact();
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        textbackground.SetActive(true);
        textDisplay.enabled = true;
        foreach (char letter in sentences[index].ToCharArray()) {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());

            Debug.Log(index);
            if (index == 1)
            {
                if (gameObject.tag == "RoadBlock")
                {
                    continueButton.SetActive(false);
                    nextStageButton.SetActive(true);
                    inventoryButton.SetActive(true);
                    Debug.Log("RoadBlock");
                }
            }
        } else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            textbackground.SetActive(false);

        }
    }
}
   

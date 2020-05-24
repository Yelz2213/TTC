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

    public Player player;

    public override void Interact()
    {
        Debug.Log(".....");
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
        player.isInteracting = true;
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        } else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            textbackground.SetActive(false);
            player.isInteracting = false;
        }
    }
}
   

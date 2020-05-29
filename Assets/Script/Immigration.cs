using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Immigration : Interactable
{
    public Player player;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public string[] sentences2;
    private int index;
    private int index2;
    public float typingSpeed;
    public GameObject textbackground;
    public GameObject continueButton;
    public GameObject continueButton2;

    public override void Interact()
    {
        //Debug.Log("Interacting");
        base.Interact();

        if( player.isChangedOutfit == true )
        {
            StartCoroutine(Type2());
        } else
        {
            StartCoroutine(Type());
        }
    }

    IEnumerator Type()
    {
        continueButton.SetActive(true);
        textbackground.SetActive(true);
        textDisplay.enabled = true;
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator Type2()
    {
        textbackground.SetActive(true);
        continueButton2.SetActive(true);
        textDisplay.enabled = true;
        foreach (char letter in sentences2[index2].ToCharArray())
        {
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
                    Debug.Log("RoadBlock");
                }
            }
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            textbackground.SetActive(false);

        }
    }

    public void NextSentence2()
    {
        continueButton2.SetActive(false);
        if (index2 < sentences2.Length - 1)
        {
            index2++;
            textDisplay.text = "";
            StartCoroutine(Type2());
        } else
        {
            textDisplay.text = "";
            continueButton2.SetActive(false);
            textbackground.SetActive(false);
            player.istaken = true;
        }
    }
}

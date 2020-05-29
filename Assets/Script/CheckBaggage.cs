using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckBaggage : Interactable
{
    public UIcontroller uIcontroller;
    public Inventory inventory;
    public TextMeshProUGUI textDisplay;
    private string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject textbackground;
    public GameObject continueButton;

    public void Awake()
    {
        sentences = new string[1];
        sentences[0] = "Not this one.";
    }

    public override void Interact()
    {
        base.Interact();

        if (gameObject.tag == "CorrectBaggage")
        {
            sentences[0] = "Found it";
        }
        else
        {
            sentences[0] = "Not this one.";
        }

        StartCoroutine(Type());
        uIcontroller.pauseGame();
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

        if (gameObject.tag == "CorrectBaggage")
        {
            Destroy(this.gameObject);
            inventory.baggage.SetActive(true);
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
        }
        else
        {
            textDisplay.text = "";
            index = 0;
            continueButton.SetActive(false);
            textbackground.SetActive(false);
            uIcontroller.pauseGame();
        }
    }
}

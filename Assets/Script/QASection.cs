using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QASection : UIcontroller
{
    public GameObject qAPanel;
    public GameObject readyButton;

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed;
    public GameObject continueButton;

    public void StartQA()
    {
        qAPanel.SetActive(true);
        readyButton.SetActive(false);
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        continueButton.SetActive(true);
        textDisplay.enabled = true;
        foreach (char letter in sentences[index].ToCharArray())
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
        } else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            player.isInteracting = false;
        }
    }

    void LastQuestion()
    {
        
    }
}

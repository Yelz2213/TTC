using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QASection : UIcontroller
{
    public GameObject qAPanel,
                      readyButton,
                      reviewButton,
                      dialogPanel,
                      title;


    public TextMeshProUGUI textDisplay,
                           answerDisplay,
                           answer_wDisplay,
                           dialog_Cloud;

    public string[] sentences, 
                    answer, 
                    answer_w, 
                    dialog_c;

    private int index, 
                index_c;

    public float typingSpeed;
    public GameObject continueButton;

    public void StartQA()
    {
        title.SetActive(false);
        qAPanel.SetActive(true);
        readyButton.SetActive(false);
        reviewButton.SetActive(false);
        StartCoroutine(Type());
        StartCoroutine(TypeDialog());
    }

    //Question contents
    IEnumerator Type()
    {
        continueButton.SetActive(true);
        textDisplay.enabled = true;
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        answerDisplay.enabled = true;
        foreach (char letter in answer[index].ToCharArray())
        {
            answerDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        answer_wDisplay.enabled = true;
        foreach (char letter in answer_w[index].ToCharArray())
        {
            answer_wDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator TypeDialog()
    {
        foreach (char letter in dialog_c[index_c].ToCharArray())
        {
            dialog_Cloud.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }


    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            index_c++;
            textDisplay.text = "";
            answerDisplay.text = "";
            answer_wDisplay.text = "";
            dialog_Cloud.text = "";
            StartCoroutine(Type());
            StartCoroutine(TypeDialog());
        } else
        {
            dialogPanel.SetActive(true);
            qAPanel.SetActive(false);
            textDisplay.text = "";
            answerDisplay.text = "";
            answer_wDisplay.text = "";
            dialog_Cloud.text = "";
            continueButton.SetActive(false);
        }
    }

    public override void openInventory()
    {
        base.openInventory();
        inventoryPanel.SetActive(true);
        readyButton.SetActive(false);
        reviewButton.SetActive(false);
        continueButton.SetActive(false);
    }

    public override void closeInventory()
    {
        base.closeInventory();
        inventoryPanel.SetActive(false);
        readyButton.SetActive(true);
        reviewButton.SetActive(true);
        continueButton.SetActive(true);
    }

    void LastQuestion()
    {
        
    }
}

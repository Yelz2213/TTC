using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QASection : UIcontroller
{
    public GameObject qAPanel,
                      readyButton,
                      reviewButton,
                      nextStage,
                      dialogPanel,
                      title;

    public RectTransform answerButton,
                         answer_wButton;


    public TextMeshProUGUI textDisplay,
                           answerDisplay,
                           answer_wDisplay,
                           dialog_Cloud;

    public string[] sentences, 
                    answer, 
                    answer_w, 
                    dialog_c;

    private int index, 
                index_c,
                random;

    public float typingSpeed;
    public GameObject continueButton;
    bool isSwitched = false;

    public void StartQA()
    {
        Debug.Log(answerButton.anchoredPosition);
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
        //typing question contents
        textDisplay.enabled = true;
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        //typing correct answer contents
        answerDisplay.enabled = true;
        foreach (char letter in answer[index].ToCharArray())
        {
            answerDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        //typing Wrong answer contents
        answer_wDisplay.enabled = true;
        foreach (char letter in answer_w[index].ToCharArray())
        {
            answer_wDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator TypeDialog()
    {
        //typing hints
        foreach (char letter in dialog_c[index_c].ToCharArray())
        {
            dialog_Cloud.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }


    public void NextSentence()
    {
        random = Random.Range(0, 3);
        if(random >= 1)
        {
            Debug.Log("Switched");
            ChangePosition();
        }
        
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
            nextStage.SetActive(true);
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
        title.SetActive(false);
    }

    public override void closeInventory()
    {
        base.closeInventory();
        inventoryPanel.SetActive(false);
        readyButton.SetActive(true);
        reviewButton.SetActive(true);
        continueButton.SetActive(true);
        title.SetActive(true);
    }

    public void ChangePosition() {
        Vector3 pos1 = new Vector3((float)-174.6, 0, 0);
        Vector3 pos2 = new Vector3((float)172, 0, 0);

        if (!isSwitched)
        {
            Debug.Log("Switch1");
            isSwitched = true;
            answerButton.anchoredPosition = pos2;
            answer_wButton.anchoredPosition = pos1;
        } else if (isSwitched)
        {
            Debug.Log("Switch2");
            isSwitched = false;
            answerButton.anchoredPosition = pos1;
            answer_wButton.anchoredPosition = pos2;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public GameObject inventoryPanel;

    public bool isPause = false;
    public Player player;

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    public virtual void openInventory()
    {
        Debug.Log("clicking inventory button");
        inventoryPanel.SetActive(true);
        pauseGame();
    }

    public virtual void closeInventory()
    {
        inventoryPanel.SetActive(false);
        pauseGame();
    }



    public void pauseGame()
    {
        if (isPause != true)
        {
            Time.timeScale = 0;
            player.currentAudioListener.enabled = false;
            isPause = true;
        } else
        {
            Time.timeScale = 1;
            player.currentAudioListener.enabled = true;
            isPause = false;
        }
    }
}



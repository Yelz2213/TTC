using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public GameObject Inventory;
    bool isPause = false;
    public Player player;

    private void Start()
    {

    }

    public void openInventory()
    {
        Inventory.SetActive(true);
        pauseGame();
    }

    public void closeInventory()
    {
        Inventory.SetActive(false);
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



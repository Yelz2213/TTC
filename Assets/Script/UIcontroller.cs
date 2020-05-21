using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class UIcontroller : MonoBehaviour
{
    public GameObject Inventory;
    bool pause = false;
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
        if (pause != true)
        {
            Time.timeScale = 0;
            player.currentAudioListener.enabled = false;
            pause = true;
        } else
        {
            Time.timeScale = 1;
            player.currentAudioListener.enabled = true;
            pause = false;
        }
    }
}



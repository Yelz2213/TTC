using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject passport;
    public GameObject boardingpass;
    public GameObject map;

    public Text text_Item;
    public Player player;

    public void Start()
    {
        text_Item.text = null;
    }


    public void Passport()
    {
        if (player.currentItem != null)
        {
            player.currentItem.SetActive(false);
            text_Item.text = null;
        }
        passport.SetActive(true);
        player.currentItem = passport;
        text_Item.text = "Passport";
    }

    public void Boardingpass()
    {
        if (player.currentItem != null)
        {
            player.currentItem.SetActive(false);
        }
        boardingpass.SetActive(true);
        player.currentItem = boardingpass;
        text_Item.text = "Boarding pass";
    }

    public void Map()
    {
        if (player.currentItem != null)
        {
            player.currentItem.SetActive(false);
        }
        map.SetActive(true);
        player.currentItem = map;
        text_Item.text = "Map";
    }
}

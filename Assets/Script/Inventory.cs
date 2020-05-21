using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject passport;
    public GameObject boardingpass;
    public GameObject map;

    public Player player;
    public void Passport()
    {
        if (player.currentItem != null)
        {
            player.currentItem.SetActive(false);
        }
        passport.SetActive(true);
        player.currentItem = passport;
    }

    public void Boardingpass()
    {
        if (player.currentItem != null)
        {
            player.currentItem.SetActive(false);
        }
        boardingpass.SetActive(true);
        player.currentItem = boardingpass;
    }

    public void Map()
    {
        if (player.currentItem != null)
        {
            player.currentItem.SetActive(false);
        }
        map.SetActive(true);
        player.currentItem = map;
    }
}

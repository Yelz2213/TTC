using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject passport;
    public GameObject boardingpass;
    public GameObject map;
    public GameObject decodeScreen;
    public GameObject baggagePhoto;
    public GameObject baggage;
    public GameObject outfit;
    public GameObject secretList;


    public GameObject inputport;
    public GameObject Password = null;

    public GameObject[] outfits;

    public Material blue;
    public Text text_Item;
    public InputField input;
    public Player player;

    bool isDecoding = false;
    string inputP;

    public void Start()
    {
        text_Item.text = null;
    }

    public void Update()
    {
        if (player.currentItem == boardingpass && isDecoding == true)
        {
            Password.SetActive(true);
        } else
        {
            Password.SetActive(false);
        }
        inputP = input.text;

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

    public void Photo()
    {
        if (player.currentItem != null)
        {
            player.currentItem.SetActive(false);
        }
        baggagePhoto.SetActive(true);
        player.currentItem = baggagePhoto;
        text_Item.text = "Baggage's photo";
    }

    public void UnlockScreen()
    {
        inputport.SetActive(true);
    }

    public void Unlock()
    {
        string password = "4444";
        if (password == inputP)
        {
            inputport.SetActive(false);
            Debug.Log("Unlocked");
            outfit.SetActive(true);
        }
    }

    public void CloseUnlock()
    {

    }

    public void ChangeOutfit()
    {
        for (int index = 0; index < outfits.Length; index++)
        {
            outfits[index].GetComponent<SkinnedMeshRenderer>().material = blue;
        }
        player.isChangedOutfit = true;
    }

    public void decode()
    {
        if (isDecoding == true)
        {
            isDecoding = false;
            decodeScreen.SetActive(false);
        }
        else if (isDecoding == false)
        {
            isDecoding = true;
            decodeScreen.SetActive(true);
        }
    }
}

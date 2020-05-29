using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : Interactable
{
    public Player player;

    public override void Interact()
    {
        base.Interact();
        //SceneManager.LoadScene();
    }
}

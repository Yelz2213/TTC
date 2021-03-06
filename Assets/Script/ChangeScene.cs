﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int scene;
    public Animator transition;
    public float transitionTime = 1f;

    //public VectorValue vectorvalue 
    private void Start()
    {
        /*
        sceneName = SceneManager.GetActiveScene().name;
        player = FindObjectOfType<Player>();
        Debug.Log("Current scene is: " + sceneName);
        float loadPositionX = PlayerPrefs.GetFloat("SceneOnePositionX");
        float loadPositionY = PlayerPrefs.GetFloat("SceneOnePositionY");
        float loadPositionZ = PlayerPrefs.GetFloat("SceneOnePositionZ");
        Vector3 scene_one_position = new Vector3(loadPositionX, loadPositionY, loadPositionZ);
        Debug.Log("scene_one_position: "+scene_one_position);
        */
    }

    public void changeScene(int scene)
    {
        StartCoroutine(LoadLevel(scene));

        /*
        if (sceneName == "SecondScene" && scene == 0)
        {
            SceneManager.LoadScene(scene);
        }
        else if (sceneName == "FirstScene" && scene == 1)
        {
            SceneManager.LoadScene(scene);
        }
        */

        /*
        if(sceneName == "SecondScene" && scene == 0)
        {
            PlayerPrefs.SetFloat("SceneSecondPositionX", player.currentPosition.x);
            PlayerPrefs.SetFloat("SceneSecondPositionY", player.currentPosition.y);
            PlayerPrefs.SetFloat("SceneSecondPositionZ", player.currentPosition.z);
            PlayerPrefs.Save();
            SceneManager.LoadScene(scene);
        }  else if (sceneName == "FirstScene" && scene == 1)
        {
            PlayerPrefs.SetFloat("SceneOnePositionX", player.currentPosition.x);
            PlayerPrefs.SetFloat("SceneOnePositionY", player.currentPosition.y);
            PlayerPrefs.SetFloat("SceneOnePositionZ", player.currentPosition.z);
            PlayerPrefs.Save();
            SceneManager.LoadScene(scene);
        }
        */
    }

    IEnumerator LoadLevel(int Scene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

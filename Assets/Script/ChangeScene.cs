using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    Player player;
    public int scene;
    public string sceneName;

    //public VectorValue vectorvalue 
    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;

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

    void OnTriggerEnter(Collider other)
    {
        changeScene(sceneName, scene);
    }

    public void changeScene(string sceneName, int scene)
    {
        if (sceneName == "SecondScene" && scene == 0)
        {
            SceneManager.LoadScene(scene);
        }
        else if (sceneName == "FirstScene" && scene == 1)
        {
            SceneManager.LoadScene(scene);
        }

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
}

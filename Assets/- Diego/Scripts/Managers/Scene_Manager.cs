using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene_Manager : MonoBehaviour
{
    public void Load_Scene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

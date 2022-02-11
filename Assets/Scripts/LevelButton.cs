using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int sceneToLoad;

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

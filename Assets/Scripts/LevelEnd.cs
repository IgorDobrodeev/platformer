using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelEnd : MonoBehaviour
{
    public int level;
    public string scene;

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") {
            PlayerPrefs.SetInt("level", level);
            PlayerPrefs.Save();
            SceneManager.LoadScene(scene);
        }
    }
}
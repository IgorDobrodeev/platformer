using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int level;
    public void LoadLevelMenu()
    {
        SceneManager.LoadScene("Menu 1");
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadExperemental() {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadLevel2() {
        if(PlayerPrefs.HasKey("level")) {
            level = PlayerPrefs.GetInt("level");  
            if(level >= 2) {
                SceneManager.LoadScene("Level2");
            }
        }
    }
}
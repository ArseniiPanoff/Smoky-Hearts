using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour
{
    public string nameOfLevelToLoad  = "";
    public void LoadLevel ()
    {
	    SceneManager.LoadScene(nameOfLevelToLoad);
    }
}

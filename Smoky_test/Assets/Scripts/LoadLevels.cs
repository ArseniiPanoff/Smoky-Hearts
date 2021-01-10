using UnityEngine;

public class LoadLevels : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject LevelsCanvas;

    public void LoadLevelsCanvas()
    {
        MainCanvas.SetActive(false);
        LevelsCanvas.SetActive(true);
    }
}

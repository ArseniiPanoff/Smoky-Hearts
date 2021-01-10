using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public struct LevelCoor
{
    public float Xcoor;
    public float Ycoor;
};
public class Saver : MonoBehaviour
{
    public bool checkPoint1;
    public bool checkPoint2;
    public float CheckCoorX;
    public float CheckCoorY;
    public LevelCoor[] level = new LevelCoor[20];
    void Start()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        switch(sceneName){
            case "Level1":
                level[0].Xcoor = 62f;level[0].Ycoor = 0f;
                level[1].Xcoor = 103f; level[1].Ycoor = -6f;
                break;
            case "Level2":
                break;
            case "Level3":
                break;
            case "Level4":
                break;
        }
        checkPoint1 = false;
        checkPoint2 = false;
    }
    T[] InitializeArray<T>(int length) where T : new()
    {
        T[] array = new T[length];
        for (int i = 0; i < length; ++i)
        {
            array[i] = new T();
        }
        return array;
    }
}

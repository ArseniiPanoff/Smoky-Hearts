using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct LevelCoor
{
    public float Xcoor1;
    public float Xcoor2;
};
public class Saver : MonoBehaviour
{
    public bool checkPoint1;
    public bool checkPoint2;
    public float CheckCoorX;
    public float CheckCoorY;
    public string sceneName;
    public LevelCoor[] level = new LevelCoor[20];
    void Start()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        switch(sceneName){
            case "Level1":
                level[1].Xcoor1 = 296f; 
                level[1].Xcoor2 = 322f; 
                level[2].Xcoor1 = 590f; 
                level[2].Xcoor2 = 622f; 
                level[3].Xcoor1 = 740f; 
                level[3].Xcoor2 = 804f;
                level[4].Xcoor1 = 928f;
                level[4].Xcoor2 = 967f;
                level[5].Xcoor1 = 1254f;
                level[5].Xcoor2 = 1302f;
                level[6].Xcoor1 = 1426f;
                level[6].Xcoor2 = 1471f;
                level[7].Xcoor1 = 1595f;
                level[7].Xcoor2 = 1621f;
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

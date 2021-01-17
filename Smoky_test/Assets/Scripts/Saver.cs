using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public struct LevelCoor
{
    public float Xcoor;
};
public class Saver : MonoBehaviour
{
    public bool checkPoint1;
    public bool checkPoint2;
    public float CheckCoorX;
    public float CheckCoorY;
    public float[] level = new float[20];
    void Start()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        switch(sceneName){
            case "Level1":
                level[0] = 62f;
                level[1] = 103f; 
                level[2] = 296f; 
                level[3] = 322f; 
                level[4] = 590f; 
                level[5] = 622f; 
                level[6] = 740f; 
                level[7] = 804f;
                level[8] = 928f;
                level[9] = 967f;
                level[10] = 1254f;
                level[11] = 1302f;
                level[12] = 1426f;
                level[13] = 1471f;
                level[14] = 1595f;
                level[15] = 1621f;
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

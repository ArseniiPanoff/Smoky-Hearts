using System.Collections;
using System.Collections.Generic;
using UnityEngine;
        
public class BackToCkeck : MonoBehaviour
{
    private GameObject EndGameCanvas;
    public GameObject[] g;
    public void Function()
    {
        EndGameCanvas = GameObject.FindWithTag("End");
        GameObject.FindWithTag("Player").GetComponent<BotScript>()._anim.SetBool("IsDeath", false);
        //GameObject.FindWithTag("Player").GetComponent<BotScript>()._anim.SetBool("IsMover", true);
        GameObject.FindWithTag("Player").transform.position = new Vector3(GameObject.FindWithTag("Saver").GetComponent<Saver>().CheckCoorX, GameObject.FindWithTag("Saver").GetComponent<Saver>().CheckCoorY, 0);
        EndGameCanvas.SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<BotScript>().iTisGG = false;
        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        g = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject i in g)
        {
            if (i.GetComponent<EnemyScript>() != null)
            {
                i.transform.position = new Vector3(i.GetComponent<EnemyScript>().initCoorX, i.GetComponent<EnemyScript>().initCoorY, 0);
                i.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                i.GetComponent<EnemyScript>().iTisGG = false;
            }
            else if (i.GetComponent<OmonScript>() != null)
            {
                i.transform.position = new Vector3(i.GetComponent<OmonScript>().initCoorX, i.GetComponent<OmonScript>().initCoorY, 0);
                i.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                i.GetComponent<OmonScript>().iTisGG = false;
            }
            
        }
    }
}

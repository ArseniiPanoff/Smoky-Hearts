using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CkeckScript : MonoBehaviour
{
    public bool ItWasNotHere = true;
    public bool colider;
    public GameObject[] g;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && ItWasNotHere)
        {
            colider = true;
            GameObject.FindWithTag("Saver").GetComponent<Saver>().CheckCoorX = gameObject.transform.position.x;
            GameObject.FindWithTag("Saver").GetComponent<Saver>().CheckCoorY = gameObject.transform.position.y;
            ItWasNotHere = false;
            SetAlpha(0.5f);
            g = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject i in g)
            {
                i.GetComponent<EnemyScript>().initCoorX = i.transform.position.x;
                i.GetComponent<EnemyScript>().initCoorY = i.transform.position.y;
            }
        }        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        colider = false;
    }
    private void SetAlpha(float alpha)
    {
        SpriteRenderer[] children = gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer child in children)
        {
            var newColor = child.color;
            newColor.a = alpha;
            child.color = newColor;
        }
    }
}

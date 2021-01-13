using System;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject EndGameCanvas;
    public bool colider;
    public GameObject[] g;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.FindWithTag("Player").GetComponent<BotScript>().iTisGG = true;
            g = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject i in g)
            {
                if (i.GetComponent<EnemyScript>() != null)
                    i.GetComponent<EnemyScript>().iTisGG = true;
                else if (i.GetComponent<OmonScript>() != null)
                    i.GetComponent<OmonScript>().iTisGG = true;
            }
            colider = true;
            EndGameCanvas.SetActive(true);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)//land
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.FindWithTag("Player").GetComponent<BotScript>().iTisGG = true;
            g = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject i in g)
            {
                if (i.GetComponent<EnemyScript>() != null)
                    i.GetComponent<EnemyScript>().iTisGG = true;
                else if (i.GetComponent<OmonScript>() != null)
                    i.GetComponent<OmonScript>().iTisGG = true;
            }
            colider = true;
            EndGameCanvas.SetActive(true);
        }
    }
}

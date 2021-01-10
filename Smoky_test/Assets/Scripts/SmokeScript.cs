using System;
using UnityEngine;

public class SmokeScript : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer[] aplhas;
    public bool In;
    public float x;
    public bool iT = true;
    private void Start()
    {
        aplhas = player.transform.GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {
        x = Math.Abs(player.transform.position.x - gameObject.transform.position.x);
        if (Math.Abs(player.transform.position.x - gameObject.transform.position.x) < 10f && Math.Abs(player.transform.position.y - gameObject.transform.position.y) < 10f)
        {
            In = true;
            iT = true;
            foreach (GameObject g  in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (g.GetComponent<EnemyScript>() != null)
                    g.GetComponent<EnemyScript>().iSeeU = false;
                else if (g.GetComponent<OmonScript>() != null)
                    g.GetComponent<OmonScript>().iSeeU = false;
            }
            SetAlpha(0.5f);
        }
        else
        {
            In = false;
        }
        if (Math.Abs(player.transform.position.x - gameObject.transform.position.x) > 5f && iT)
        {
            foreach (GameObject g  in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (g.GetComponent<EnemyScript>() != null)
                    g.GetComponent<EnemyScript>().iSeeU = true;
                else if (g.GetComponent<OmonScript>() != null)
                    g.GetComponent<OmonScript>().iSeeU = true;
            }
            SetAlpha(1f);
            iT = false;
        }
    }
    
    private void SetAlpha(float alpha) {
        SpriteRenderer[] children = player.GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer child in children) {
            var newColor = child.color;
            newColor.a = alpha;
            child.color = newColor;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maskpoint : MonoBehaviour
{
    public GameObject endPoint;
    public GameObject Toho1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "End")
        {
            Toho1.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "End")
        {
            Toho1.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoTiro : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Alien" || collision.tag == "Base")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }


    public float speed = 5.0f;

    void Update()
    {
        gameObject.transform.position += Vector3.up * speed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}

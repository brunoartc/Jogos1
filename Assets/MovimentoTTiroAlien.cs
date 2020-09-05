using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MovimentoTTiroAlien : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Base")
        { 
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }

    }


    public float speed = 5.0f;

    void Update()
    {
        gameObject.transform.position += Vector3.down * speed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}

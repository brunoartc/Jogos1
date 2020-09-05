using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject bullet;


    public float speed = 25.0f;
    private float bound = 9;

    private float timer = 0;
    public float wait = 0.3f;

    private Vector3 position;

    AudioSource audioData;



    void Start()
    {
        position = transform.position;
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        position += Vector3.right * Input.GetAxis("Horizontal") * speed;

        if (Input.GetAxis("Mouse X") != 0)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.x = worldPosition.x;
        }

        timer += Time.deltaTime;
        if (timer > wait && Input.GetButton("Fire1"))
        {
            audioData.Play(0);
            timer = 0;
            Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        }

        if (position.x < -bound)
        {
            position.x = -bound;
        }
        else if (position.x > bound)
        {
            position.x = bound;
        }

        transform.position = position;
    }
}


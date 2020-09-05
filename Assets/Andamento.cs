using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Andamento : MonoBehaviour
{
    public GameObject bullet;
    public GameObject tudo;


    public float speed = 0.5f;
    public float wait = 0.4f;
    private bool invert = false;

    void Start()
    {
        InvokeRepeating("AliensAttack", 0, wait);
    }

    void AliensAttack()
    {

        if (invert)
        {
            speed = -speed;
            gameObject.transform.position += Vector3.down * Mathf.Abs(speed);
            invert = false;
            return;
        }
        else
        {
            gameObject.transform.position += Vector3.right * speed;
        }

        foreach (Transform alien in gameObject.transform)
        {
            if (alien.position.x < -8 || alien.position.x > 8)
            {
                invert = true;
                break;
            }

            if (alien.position.y < -8.0)
            {
                StartCoroutine(HandleIt());
            }

            if (Random.value < 0.02f)
            {
                Instantiate(bullet, alien.position, alien.rotation);
            }


        }
    }

    private IEnumerator HandleIt()
    {
        // process pre-yield
        yield return new WaitForSeconds(1.0f);
        Destroy(tudo);
        // process post-yield
        SceneManager.LoadScene("um", LoadSceneMode.Additive);
        Destroy(tudo);
    }
}




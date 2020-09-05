using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ganharperder : MonoBehaviour
{
    public GameObject tudo;
    public GameObject aliens;
    public GameObject player;

    void Update()
    {
        if (player == null)
        {
            gameObject.GetComponent<Text>().text = "Vitória dos Aliens";
            StartCoroutine(HandleIt());
        }
            
        else if (aliens.transform.childCount == 0)
        {
            gameObject.GetComponent<Text>().text = "Vitória do Jogador";
            StartCoroutine(HandleIt());

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

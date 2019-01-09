using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishZone : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name == "SecondScene")
        {
            if (collision.tag == "Player" || collision.name == "Player" || collision.gameObject.name == "Player")
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
        else if(SceneManager.GetActiveScene().name == "FirstScene")
        {
            if (collision.tag == "Player" || collision.name == "Player" || collision.gameObject.name == "Player")
            {
                SceneManager.LoadScene("SecondScene");
            }
        }
    }
}

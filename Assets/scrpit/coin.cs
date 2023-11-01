using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class coin : MonoBehaviour
{
    public bool killCoin = false;
    public AudioSource audio;
    public TextManager textManager;
    public int value;

    void OnTriggerEnter(Collider collider)
    {
        textManager.AddCoins(value);
        audio.Play();
        if (killCoin)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        Destroy(gameObject);
    }
}
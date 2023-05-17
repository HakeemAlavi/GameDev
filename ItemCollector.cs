using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    int coins = 0;

    [SerializeField] Text coinsText;
    [SerializeField] AudioSource collectionSound;
    [SerializeField] AudioSource finishSound;
    [SerializeField] AudioSource deathSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            coinsText.text = "Coins: " + coins;
            collectionSound.Play();

        }

        if (other.gameObject.CompareTag("Star") && coins >=4)
        {
            finishSound.Play();
            Invoke(nameof(NewLevel), 1.0f);
        }

        if (other.gameObject.CompareTag("Star") && coins <=3)
        {
            deathSound.Play();
            Invoke(nameof(RestartLevel), 1.0f);
        }
        
    }

    void NewLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
}

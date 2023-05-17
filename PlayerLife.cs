using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    bool dead = false;
    bool time = false;

    [SerializeField] AudioSource deathSound;

    float currentTime = 0f;
    [SerializeField] float startingTime = 30f;

    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        if (transform.position.y < -1f && !dead)
        {
            Die();
        }
        
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString ("0");

        if (currentTime <= 0 && !time)
        {
            currentTime = 0; 
            time = true;
            Restart();   
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        Invoke(nameof(RespawnLevel), 1.0f);
        dead = true;
        deathSound.Play();
    }

    void Restart()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        Invoke(nameof(RestartLevel), 1.0f);
        dead = true;
        deathSound.Play();
    }

    void RespawnLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

     void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
}

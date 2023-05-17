using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenuTwo : MonoBehaviour
{
    [SerializeField] AudioSource restartSound;

    public void RestartGame()
    {
        restartSound.Play();
        SceneManager.LoadScene(2);
    }
}

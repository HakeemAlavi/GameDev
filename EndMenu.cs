using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    [SerializeField] AudioSource endSound;

    public void QuitGame()
    {
        endSound.Play();
        Application.Quit();
    }
}

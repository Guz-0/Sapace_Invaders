using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool isResuming;
    private bool paused;
    [SerializeField] private float resumeSpeed = 1f;

    [SerializeField] private GameObject pauseMenu;

    void Awake()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        PauseGame();
    }


    public void PauseGame()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!paused)
            {
                Time.timeScale = 0f;
                paused = true;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 0.01f;
                pauseMenu.SetActive(false);
                isResuming = true;
                paused = false;
            }
        }
        if (isResuming && !paused)
        {
            resumePlaying();
            //Debug.Log("IS RESUMING: " + Time.timeScale);
        }

    }

    private void resumePlaying()
    {
        Time.timeScale = Mathf.MoveTowards(Time.timeScale, 1f, resumeSpeed * Time.deltaTime);

        if (Time.timeScale == 1f)
        {
            isResuming = false;

        }
        else
        {
            isResuming = true;
        }
    }
}

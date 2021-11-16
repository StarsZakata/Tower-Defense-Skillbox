using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SpeedUp()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 2;
        else if (Time.timeScale == 2)
            Time.timeScale = 4;
        else if (Time.timeScale == 4)
            Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }
}

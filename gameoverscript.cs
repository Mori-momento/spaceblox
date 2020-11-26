using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameoverscript : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Text score;
    private bool isgameover;

    private void Start()
    {
        FindObjectOfType<player>().OnDeath += GameOver;
    }

    private void Update()
    {
        if(isgameover)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void GameOver()
    {
        score.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOverScreen.SetActive(true);
        isgameover = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour
{
    public Controller controller;
    public GameObject ground;
    public Canvas canvas;
    public Text[] winTexts;
    public Buttonscript reset;
    private float t;
    private bool hasWon = false;

    void Start()
    {
        canvas.enabled = false;
        winTexts[1].enabled = false;
        winTexts[0].enabled = false;
        ground.SetActive(true);
        t = 0;
    }

    void Update()
    {
        if (hasWon == true)
        {
            t = t + 1 * Time.deltaTime;
            if (t > 1)
            {
                Win_();
            }
        }
    }

    public void Win_()
    {
        if (hasWon == true)
        {
            canvas.enabled = true;
            ground.SetActive(false);
            if (controller.turn == 2)
            {
                winTexts[1].enabled = true;
            }
            else
            {
                winTexts[0].enabled = true;
            }
            hasWon = false;
        }

        hasWon = true;

    }
    public void ResetGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

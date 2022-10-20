using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public TMP_Text timerText;

    public float timeLimit = 180f;

    float currentTime;

    void Start()
    {
        currentTime = timeLimit;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        string formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        timerText.text = formattedTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            GameManager.instance.UpdateGameState(GameState.GameOver);
        }
    }
}

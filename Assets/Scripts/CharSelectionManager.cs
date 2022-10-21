using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharSelectionManager : MonoBehaviour
{
    public TMP_InputField fireboyInput;

    public TMP_InputField watergirlInput;

    void Start()
    {
        GameManager.instance.UpdateGameState(GameState.None);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setCharNames()
    {
        GameManager
            .instance
            .setCharNames(fireboyInput.text, watergirlInput.text);
    }

    public void handleStart()
    {
        setCharNames();
        SceneManager.LoadScene(2);
    }
}

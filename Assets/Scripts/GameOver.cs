using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Panel GameOverScreen;

    public Panel AdPanel;

    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen = gameObject.getComponent<GameOverScreen>;
        AdPanel = gameObject.getComponent<AdPanel>;
    }

    // Update is called once per frame
    void Update()
    {
    }
}

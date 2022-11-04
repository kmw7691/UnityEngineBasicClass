using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject player;

    int score = 0;

    public Text scoreText;

    public static GameManager instance;

    private void Awake()
    {
        if(GameManager.instance == null)
        {
            GameManager.instance = this;
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Invoke("StartGame", 3f);
    }

    void StartGame()
    {
        player.GetComponent<Player>().
    }
}

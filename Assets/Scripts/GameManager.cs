using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance => _instance;

    private GameController _gameController;

    public GameController GameController { get => _gameController; set => _gameController = value; }

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public float ERA(int totalAttempts, int totalGameCount)
    {
        return (float)totalAttempts / (float)totalGameCount;
    }
}

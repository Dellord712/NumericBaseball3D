using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Result : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _number;
    [SerializeField] private TextMeshProUGUI _round;

    public void Open(int[] question, int round)
    {
        gameObject.SetActive(true);
        _number.text = $"정답 : {question[0]}{question[1]}{question[2]}";
        _round.text = $"라운드 : {round}";
    }

    public void EventQuit()
    {
        Application.Quit();
    }

    public void EventReset()
    {
        SceneManager.LoadScene(0);
    }
}

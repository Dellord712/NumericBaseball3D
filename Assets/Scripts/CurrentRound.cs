using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentRound : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _round;
    [SerializeField] private Image[] _bases;

    private bool isInitalized = false;

    private void Start()
    {
        _round.text = "1";
    }

    public void SetRound(int round)
    {
        _round.text = round.ToString();
    }

    public void SetBases(int index, int[] question)
    {
        if (isInitalized)
        {
            for (int i = 0; i < _bases.Length; i++) SetBase(i, question[i]);
            isInitalized = false;
        }
        else SetBase(index, question[index]);
    }

    private void SetBase(int index, int number)
    {
        if (number == -1) _bases[index].color = Color.white;
        else _bases[index].color = Color.yellow;
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BeforeNumber : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _number;
    [SerializeField] private Image[] _strike;
    [SerializeField] private Image[] _ball;

    public void SetInfo(int[] question,int strike,int ball)
    {
        Initialized();
        _number.text = $"{question[0]}{question[1]}{question[2]}";
        for (int i = 0; i < strike; i++) _strike[i].color = Color.yellow;
        for (int i = 0; i < ball; i++) _ball[i].color = Color.green;

    }

    private void Initialized()
    {
        for (int i = 0; i<_strike.Length; i++) _strike[i].color = Color.black;
        for (int i = 0; i < _ball.Length; i++) _ball[i].color = Color.black;
    }
}

using UnityEngine;
using TMPro;

public class ElectronicBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _round;
    [SerializeField] private TextMeshProUGUI _strike;
    [SerializeField] private TextMeshProUGUI _ball;
    [SerializeField] private TextMeshProUGUI _number;
    [SerializeField] private RectTransform _content;

    public void SetInfo(int round, int strike, int ball, int[] question )
    {
        if (round == 7) _round.text += $"   {round + 1}   {round + 2}";
        else if (round > 7)
        {
            _round.text += $"  {round + 2}";
            _content.anchoredPosition = new Vector2(-(600f + 158.98f*(round-7)), _content.anchoredPosition.y);
        }
        if(round == 1)
        {
            _strike.text += $"  {strike}";
            _ball.text += $"  {ball}";
        }
        else
        {
            _strike.text += $"   {strike}";
            _ball.text += $"   {ball}";
        }
        _number.text += $" {question[0]}{question[1]}{question[2]}";
    }
}

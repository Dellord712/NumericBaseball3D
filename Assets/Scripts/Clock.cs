using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _clock;
    [SerializeField] private Sun _sun;

    private void Update()
    {
        // 실제시간
        //_clock.text = DateTime.Now.ToString("HH:mm");

        // 가상게임시간
        VirtualGameTime();
    }

    private void VirtualGameTime()
    {
        float time = 1440f * (_sun.RotationX / 180f);
        int hour = (int)(time / 60f);
        int min = (int)(time % 60f);

        string txtHour = hour >= 10 ? hour.ToString() : $"0{hour}";
        string txtMin = min >= 10 ? min.ToString() : $"0{min}";
        _clock.text = $"{txtHour}:{txtMin}";
    }
}

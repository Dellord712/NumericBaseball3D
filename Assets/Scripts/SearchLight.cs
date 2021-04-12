using UnityEngine;
using UnityEngine.UI;

public class SearchLight : MonoBehaviour
{
    [SerializeField] private GameObject[] _searchLights;
    [SerializeField] private Image[] _searchUI;
    [SerializeField] private Sprite _searchOn;
    [SerializeField] private Sprite _searchOff;

    public void SwitchLight(bool isOn)
    {
        for (int i = 0; i < _searchLights.Length; i++) _searchLights[i].SetActive(isOn);
        if (isOn)
            for (int i = 0; i < _searchUI.Length; i++) _searchUI[i].sprite = _searchOn;
        else
            for (int i = 0; i < _searchUI.Length; i++) _searchUI[i].sprite = _searchOff;
    }
}

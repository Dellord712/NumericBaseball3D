using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Sun _sun;
    [SerializeField] private SearchLight _searchLight;
    [SerializeField] private float _searchOnAngle;
    [SerializeField] private float _searchOffAngle;

    private bool _searchOn = false;

    private const float _range = 10f;

    private void Update()
    {
        if((_sun.RotationX >= _searchOnAngle && _sun.RotationX <= _searchOnAngle + _range && !_searchOn) 
            || _sun.RotationX >= _searchOffAngle && _sun.RotationX <= _searchOffAngle + _range && _searchOn)
        {
            _searchOn = !_searchOn;
            _searchLight.SwitchLight(_searchOn);
        }
    }
}

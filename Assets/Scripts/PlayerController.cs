using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameSet _gameSet;
    [SerializeField] private Image _accelerationBtn;
    [SerializeField] private Sprite _accelerationOn;
    [SerializeField] private Sprite _accelerationOff;

    private bool _useAcceleration = false;

    private void Update()
    {
#if UNITY_EDITOR
        UnityEditorController();
#elif UNITY_ANDROID
        AndroidController();
#endif
    }

    public void SwitchGyro()
    {
        _useAcceleration = !_useAcceleration;
        if (!_useAcceleration)
        {
            _gameSet.Initialized();
            _accelerationBtn.sprite = _accelerationOff;
        }
        else _accelerationBtn.sprite = _accelerationOn;
    }

    private void UnityEditorController()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_player.FirstPress) _player.FirstPress = true;
            _player.Press = true;
        }

        if (Input.GetMouseButton(0)) _player.TouchPoint = Input.mousePosition;

        if (Input.GetMouseButtonUp(0)) _player.Press = false;

        if (_useAcceleration)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) _gameSet.Rotation += Vector3.forward;
            if (Input.GetKey(KeyCode.RightArrow)) _gameSet.Rotation += Vector3.back;
            if (Input.GetKey(KeyCode.UpArrow)) _gameSet.Rotation += Vector3.right;
            if (Input.GetKey(KeyCode.DownArrow)) _gameSet.Rotation += Vector3.left;
            if (Input.GetKey(KeyCode.A)) _gameSet.Rotation += Vector3.down;
            if (Input.GetKey(KeyCode.D)) _gameSet.Rotation += Vector3.up;
        }
    }

    private void AndroidController()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (!_player.FirstPress) _player.FirstPress = true;
            _player.Press = true;
        }

        if (Input.touchCount > 0) _player.TouchPoint = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) _player.Press = false;

        if (_useAcceleration) _gameSet.Rotation = Input.acceleration;
    }
}

using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _downUpSpeed = 1f;

    private float _playerY = 20f;

    private const float _minHigh = 1f;
    private const float _maxHigh = 10f;

    private Vector3 pos;
    private Vector3 a;
    private Vector3 b;

    public bool Press { get; set; }
    public bool FirstPress { get; set; }
    public Vector3 TouchPoint { get; set; }

    private void Start()
    {
        a = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
    }

    private void FixedUpdate()
    {
        if(FirstPress) Move();
    }

    public void Move()
    {
        b = Camera.main.ScreenToViewportPoint(TouchPoint) * 2 - Vector3.one;
        pos = new Vector3(a.x * b.x, 0f, a.z * b.y);
        if (Press)
        {
            if (_playerY > _minHigh) _playerY -= _downUpSpeed;
            else if (_playerY < _minHigh) _playerY = _minHigh;
            if (_playerY == _minHigh && !_rigidbody.isKinematic) _rigidbody.isKinematic = true;
        }
        else
        {
            if (_playerY != _minHigh && _rigidbody.isKinematic) _rigidbody.isKinematic = false;
            if (_playerY < _maxHigh) _playerY += _downUpSpeed;
            else if (_playerY > _maxHigh) _playerY = _maxHigh;
            else return;
        }
        pos.y = _playerY;
        transform.localPosition = pos;
    }
}

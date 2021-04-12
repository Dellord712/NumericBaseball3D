using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] private Transform _rotation;
    [SerializeField] private float _speed = 1f;
    
    private Vector3 _vector3;

    public float RotationX { get; private set; } = 90f;

    private void Start()
    {
        _vector3 = new Vector3(RotationX, -90f, -90f);
    }

    private void Update()
    {
        RotationX += Time.deltaTime * _speed;
        if (RotationX >= 180f) RotationX = 0f;
        _vector3.x = RotationX;
        _rotation.localRotation = Quaternion.Euler(_vector3);
    }
}

using UnityEngine;

public class GameSet : MonoBehaviour
{
    private Vector3 _rotation;
    private Vector3 _rotationByAcceleration;

    public Vector3 Rotation { get => _rotation; set => _rotation = value; }

    private void Start() => Initialized();

    private void Update()
    {
#if UNITY_EDITOR
        transform.rotation = Quaternion.Euler(_rotation);
#elif UNITY_ANDROID
        ChangeRotaitionByAcceleration();
#endif
    }

    public void Initialized() => _rotation = Vector3.zero;

    private void ChangeRotaitionByAcceleration()
    {
        _rotationByAcceleration = new Vector3(_rotation.y,_rotation.z,-_rotation.x);
        transform.rotation = Quaternion.Euler(_rotationByAcceleration * 90f);
    }
}

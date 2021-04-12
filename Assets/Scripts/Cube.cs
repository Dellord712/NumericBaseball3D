using UnityEngine;

public class Cube : MonoBehaviour
{
    private int _number;

    public int Number { get => _number; set => _number = value; }

    public void SetMaterialNum(Material material) => GetComponent<MeshRenderer>().material = material;
}

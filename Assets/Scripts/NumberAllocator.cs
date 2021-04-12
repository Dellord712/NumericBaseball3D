using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberAllocator : MonoBehaviour
{
    [SerializeField] private Cube[] _cubes;
    [SerializeField] private Material[] _numbers;

    public void SetCubeNumbers()
    {
        int[] numbers = CustomMath.Combination(10, 0, 9);
        for (int i = 0; i < _cubes.Length; i++)
        {
            _cubes[i].Number = numbers[i];
            _cubes[i].SetMaterialNum(_numbers[numbers[i]]);
        }
    }
}

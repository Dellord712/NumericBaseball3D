using UnityEngine;

public class HoleBottom : MonoBehaviour
{
    [SerializeField] private int _num;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            GameManager.Instance.GameController.SetQuestion(_num,collision.gameObject.GetComponent<Cube>().Number);
            GameManager.Instance.GameController.CheckSolution();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            GameManager.Instance.GameController.SetQuestion(_num, -1);
        }
    }
}

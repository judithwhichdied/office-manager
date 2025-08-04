using UnityEngine;
using UnityEngine.Rendering;

public class RandomColor : MonoBehaviour
{
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color((Random.Range(0, 2)), (Random.Range(0, 2)), (Random.Range(0, 2)));
    }
}
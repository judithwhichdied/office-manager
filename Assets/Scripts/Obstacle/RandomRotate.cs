using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    void Start()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,Random.Range(0, 4) * 90f,transform.localEulerAngles.z);
    }
}
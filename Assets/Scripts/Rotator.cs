using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotSpeed = 45f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotSpeed * Time.deltaTime, 0, 0);
    }
}

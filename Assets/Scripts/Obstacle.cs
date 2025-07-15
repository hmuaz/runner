using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 2f; 

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
    }
}

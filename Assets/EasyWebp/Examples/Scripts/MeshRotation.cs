using UnityEngine;

// This script is just used to rotate the cube
public class MeshRotation : MonoBehaviour
{
    private float dir = 1;
    public float speed = 10;

    void Update()
    {

        transform.Rotate(new Vector3(0, dir, 0) * speed * Time.deltaTime);
        if (transform.rotation.y > 0.8)
        {
            dir = -1f;
        }
        if (transform.rotation.y < 0.0)
        {
            dir = 1f;
        }
    }
}

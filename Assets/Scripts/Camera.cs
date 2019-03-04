using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float speed = 2f;
    public Transform who;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = who.position;
    }

    // Update is called once per frame
    void Update()
    {
        position = who.position;
        position.z = -10f;
        position.y= position.y+1.5f;
        position.x = -0f;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform CameraTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(CameraTarget.position.x, transform.position.y, transform.position.z);

    //camera limit
        if(transform.position.x > 95.6f)
            transform.position = new Vector3(95.6f, transform.position.y, transform.position.z);

        if(transform.position.x < -1)
            transform.position = new Vector3(-1, transform.position.y, transform.position.z);

        if(transform.position.y > 4.8f)  
            transform.position = new Vector3(transform.position.x, 4.8f, transform.position.z);

        if(transform.position.y < -0.7f)  
        transform.position = new Vector3(transform.position.x, -0.7f, transform.position.z);

    }

}

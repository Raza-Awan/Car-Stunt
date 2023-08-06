using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public float rotation_speed = 100;
    private float rot_z;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rot_z += rotation_speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0,0,rot_z);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMover : MonoBehaviour
{

    private Vector3 initPos;

    public bool ison = false;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(ison)
        transform.position = new Vector3(initPos.x, initPos.y + Mathf.Sin(Time.time * 2f) * 4f, initPos.z);
    }
}

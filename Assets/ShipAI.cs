using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAI : MonoBehaviour
{

    public float speed = 1500f;
    public float turnSpeed = 5f;

    public GameObject player;

    public GameObject rocket;
    private float rocketSpawnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update(){
        Quaternion initRotation = transform.rotation;
        Quaternion lookAtPlayer = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(initRotation, lookAtPlayer, turnSpeed * Time.deltaTime);

                    rocketSpawnCount += Time.deltaTime;

            if(rocketSpawnCount > 2f){
                rocketSpawnCount = 0f;
                Instantiate(rocket, transform.position, Quaternion.identity);
            }
       
    }

    
    void FixedUpdate()
    {
        Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
        gameObject.GetComponent<Rigidbody>().velocity =  new Vector3(v.x * 0.5f, v.y * 0.5f, v.z * 0.5f);
        gameObject.GetComponent<Rigidbody>().velocity += transform.TransformDirection(new Vector3(0,0, speed * Time.deltaTime));


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBlockInteraction : MonoBehaviour
{

    public float innerGrowRate = 16f;

    public float innerDecayRate = 5f;

    public bool isPlayerAttached = false;

    public bool isCharged = false;

    public GameObject innerCube;

    
    public ParticleSystem particles;

    public GameObject[] rockets;
    private float rocketSpawnCount = 0;

    public AudioSource chargedSound;

    private Vector3 initPos;

    private float initSize;

    public GameObject redLight;
    public GameObject blueLight;

    System.Random random;

    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
        initPos = transform.position;
        initSize = innerCube.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerAttached && !isCharged){
            initSize = innerCube.transform.localScale.x;
            initSize += Time.deltaTime * innerGrowRate / 100f;
            


            if(initSize >= 1f) {
                //Just charged
                initSize = 1.1f;
                isCharged = true;

                particles.Play();
                chargedSound.Play();

                redLight.SetActive(false);
                blueLight.SetActive(true);
            }

            innerCube.transform.localScale = new Vector3(initSize, initSize, initSize);

        }else if(!isCharged){
            float initSize = innerCube.transform.localScale.x;
            initSize -= Time.deltaTime * innerDecayRate / 100f;
            initSize = initSize < 0 ? 0 : initSize;
            innerCube.transform.localScale = new Vector3(initSize, initSize, initSize);
        }

        if(!isCharged){
            rocketSpawnCount += Time.deltaTime;

            if(rocketSpawnCount > 5f){
                rocketSpawnCount = 0f;
                 int rocketId = random.Next(0, rockets.Length);
                 //Instantiate(rockets[rocketId], transform.position, Quaternion.identity);
            }
        }

        //spinny
        
        transform.position = new Vector3(initPos.x, initPos.y + Mathf.Sin(Time.time * 2f) * 4f, initPos.z);
        transform.Rotate(new Vector3(Time.deltaTime * 200f * (initSize * initSize + 0.1f), 0, 0), Space.World);


    }
}

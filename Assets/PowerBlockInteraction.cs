using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBlockInteraction : MonoBehaviour
{

    public float innerGrowRate = 16f;

    public float innerDecayRate = 5f;

    public bool isPlayerAttached = false;

    private bool isCharged = false;

    public GameObject innerCube;

    
    public ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerAttached && !isCharged){
            float initSize = innerCube.transform.localScale.x;
            initSize += Time.deltaTime * innerGrowRate / 100f;
            


            if(initSize >= 1f) {
                //Just charged
                initSize = 1.1f;
                isCharged = true;

                particles.Play();
            }

            innerCube.transform.localScale = new Vector3(initSize, initSize, initSize);

        }else if(!isCharged){
            float initSize = innerCube.transform.localScale.x;
            initSize -= Time.deltaTime * innerDecayRate / 100f;
            initSize = initSize < 0 ? 0 : initSize;
            innerCube.transform.localScale = new Vector3(initSize, initSize, initSize);
        }
        
    }
}

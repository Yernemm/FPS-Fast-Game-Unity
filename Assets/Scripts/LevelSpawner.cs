using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{

    public GameObject[] pieces;

    System.Random random;

    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();

        for(int i = 0; i < 20; i ++){
            int pieceId = random.Next(0, pieces.Length);
            Instantiate(pieces[pieceId], new Vector3(100 * i, 0f, 0f), Quaternion.Euler(0f,0f,-90f));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{

    public string sceneName;

    private void OnTriggerEnter(Collider other) {
        if(other.name == "Player"){
            SceneManager.LoadScene(sceneName);
        }
    }
}

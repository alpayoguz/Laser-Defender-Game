using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MainSceneBg : MonoBehaviour
{

    float offSetValue = 0.3f;
    Vector2 offSetVector;
    [SerializeField] [Range(1, 2)] float speed = 1;

    // display score
    
   
    void Start()
    {


        offSetVector = new Vector2(offSetValue, 0);

      

    }

   
    void Update()
    {
        GetComponent<MeshRenderer>().sharedMaterial.mainTextureOffset += offSetVector * Time.deltaTime * speed;

    }




}

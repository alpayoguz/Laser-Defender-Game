using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBackground : MonoBehaviour
{

    float offsetValue = 0.5f;
    Vector2 offsetVector;
   


    
    



    
    

    void Start()
    {


        offsetVector = new Vector2(0, offsetValue);

      
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshRenderer>().sharedMaterial.mainTextureOffset += offsetVector * Time.deltaTime;
      
        

    }


  
    


    
}

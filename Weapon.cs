using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform bulletPos;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float ProjectileFiringPeriod = 0.1f;

    Coroutine coroutineToFire;
    public GameObject bullet;


    //Mothership ms;

    private void Start()
    {
          
    }






    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
           coroutineToFire =  StartCoroutine(FireNonStop());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(coroutineToFire);
        }

        

        




    }


   
    // Burası ateşin devamlı olmasını sağlıyor. Yani boşluğa basılı tutunca durmadan ateş eder. Sürekli bas çek yapmama gerek bırakmayan yer burası :))
    IEnumerator FireNonStop()
    {
        while (true)
        {
              bullet = Instantiate(bulletPrefab, bulletPos.position, Quaternion.identity) as GameObject;
              yield return new WaitForSeconds(ProjectileFiringPeriod);
            
        }
    }

    // Ekrandan çıkan kurşunu yokeder.

   /* private void BulletDestroyer()
    {
       if(bullet.transform.position.y > Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y)
        {
            Destroy(bullet);
        }

    }*/


    
}

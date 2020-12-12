using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] GameObject fireball;
    [SerializeField] GameObject explosion;
    [SerializeField] AudioClip enemyExplosionSound;
    [SerializeField] AudioClip enemyProjectileSound;
    [SerializeField] float setEnemyExplosionSound = 1;

    
   
 
    
    

    


    // Those variables are  used to adjust frequency of projectile of enemy
    float maxProjectileFrequency = 0.5f;
    float minProjectileFrequency = 1.5f;
    float projectileCountdown;
   



    
    

    [SerializeField] Transform bulletPos;





    private void Start()
    {

        projectileCountdown = Random.Range(minProjectileFrequency, maxProjectileFrequency);
        




    }









    private void OnCollisionEnter2D(Collision2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        DamageProcess(other, damageDealer);

    }

    private void DamageProcess(Collision2D other, DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        Destroy(other.gameObject);
        DestroyEnemy();

        
    }

    private void DestroyEnemy()
    {
        if (health == 0)
        {
            AudioSource.PlayClipAtPoint(enemyExplosionSound, Camera.main.transform.position, setEnemyExplosionSound);
            GameObject explosionEnemyParticle = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(explosionEnemyParticle, 1f);
            Destroy(gameObject);
            GetScore();
           
            

        }
    }



    private void Update()
    {
        
        MakeEnemyFire();



    }


    private void MakeEnemyFire()
    {
        projectileCountdown -= Time.deltaTime;
        if(projectileCountdown  <= 0)
        {

            Fire();
            projectileCountdown = Random.Range(minProjectileFrequency, maxProjectileFrequency);

        }

        
      

    }

    private void Fire()
    {


        
        Instantiate(fireball, bulletPos.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(enemyProjectileSound, transform.position);
        
        /*
             * Mermiye velocity vermek için diğer bir yöntem.
             * 
            GameObject frb = Instantiate(fireball, transform.position, Quaternion.identity) as GameObject;
            frb.GetComponent<Rigidbody2D>().velocity = -transform.up * 20;
            */
    }

    public void GetScore()
    {
        GameObject.Find("GameHandler").GetComponent<GameHandler>().AddScore();
    }

   
}






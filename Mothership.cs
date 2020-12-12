using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mothership : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;


    public float speed = 12;

    

    float xMin;
    float xMax;

    float yMin;
    public float yMax;

    float objectWidth;
    float objectHeight;

    private int maxHealth = 300;
    public int currentHealth;
    private int damage = 75;
    [SerializeField] HealthBar healthBar;
    [SerializeField] GameObject enemyBullet;
    [SerializeField] Image healthBarImage;
    [SerializeField] GameObject boomEffectName;
    [SerializeField] GameObject boomEffect;
    [SerializeField] AudioClip destroyedAudio;
    [SerializeField] AudioClip mothershipProjectile;
    [SerializeField] [Range(0,1)]float setMothershipProjectileSound;
    [SerializeField] [Range(0, 10)]float setMothershipDestroyedSound;
    
    

   

    

    void Start()
    {
        ShipMoveBoundaries();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        




    }
    
    void Update()
    {
        MotherShipMove();
        GetDamage();
        healthBarImage.fillAmount = healthBar.GetComponent<Slider>().value / healthBar.GetComponent<Slider>().maxValue;
        MakeProjectileSound();


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        

        if(other.gameObject.tag == "wayy")
        {
            currentHealth = 0;
            healthBar.GetComponent<Slider>().value = 0;
            DyingShip();
            Destroy(other.gameObject);
        }






        if(other.gameObject.tag =="EnemyFire")
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            Destroy(other.gameObject);
            DyingShip();
           
        }
    }
   



    private  void MotherShipMove()
    {
        var DeltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var DeltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;


        var newXPos = Mathf.Clamp(transform.position.x + DeltaX, -5.543682f, 5.48734f);    
        var newYPos = Mathf.Clamp(transform.position.y + DeltaY, -11.17448f, 10.98886f);


        transform.position = new Vector2(newXPos, newYPos) ;
      
    }

    private void ShipMoveBoundaries()
    {
        Camera gameCamera = Camera.main;


        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        // Normalde burayı yazmazsak geminin yarısı ekranın dışına çıkıyor. Bu değişkenleri oluşturup  Mathf.Clamp'ın içine eklemek gerekiyor.
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

    }

    public int GetDamage() { return maxHealth; }


    private void DyingShip()
    {
        if(currentHealth <= 0)
        {
            AudioSource.PlayClipAtPoint(destroyedAudio, Camera.main.transform.position, setMothershipDestroyedSound);
            Destroy(gameObject);
            
            GameObject boomName =  Instantiate(boomEffectName, transform.position, Quaternion.identity) as GameObject ;
            GameObject boomRealEffect = Instantiate(boomEffect, transform.position, Quaternion.identity) as GameObject;

            Destroy(GameObject.FindGameObjectWithTag("AnimatorExp"), 1f);
            Destroy(boomName, 3f);

            StartCoroutine(GetNextScene());
            







        }
    }

    private void MakeProjectileSound()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            AudioSource.PlayClipAtPoint(mothershipProjectile, Camera.main.transform.position, setMothershipProjectileSound);
        }
            
    }

    IEnumerator GetNextScene()
    {

        if(currentHealth <= 0)
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(0);

        }
        




    }

   





}







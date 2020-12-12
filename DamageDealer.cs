using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageDealer : MonoBehaviour
{
    private int damage = 75;
    private int health = 350;

    public int GetDamage() { return damage; }
   

    public void Hit()
    {
        Destroy(gameObject);
    }





    
}

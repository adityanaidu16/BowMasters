using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class damageInterface : MonoBehaviour
{
    // Start is called before the first frame update
   // [SerializedField]
    private float Health; 
    // this is a script on the projectile, its target is either the player or the enemy
    //depending on turn the "target" gameobject will change, that gameobjects health would do down.

    Collider2D[] hitColliders;
    Vector3 beginning;
    GameObject target;
    bool damageDone;
    GameObject current;


    private void Start()
    {
        damageDone = false;
        beginning = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        //here is where we put varible for ground
        
    }
    void FixedUpdate()
    {
        target = whosTurn();
       if (Physics2D.OverlapBoxAll(transform.position, transform.localScale / 2, 0, Physics2D.AllLayers) != null )// check to see if the projectile is in range
       {
            hitColliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale / 2, 0, Physics.AllLayers);
            Damage(hitColliders);
       }
        
    }
     GameObject whosTurn()
    {
        //checks to see whose turn it is so who the  damage will be going to... NO SELF DAMAGE!


        bool turn = GameObject.FindGameObjectWithTag("Enemy").GetComponent<basicsOfObjects>().turn;
        target = turn ? GameObject.FindGameObjectWithTag("Player") : GameObject.FindGameObjectWithTag("Enemy");
        current = target == GameObject.FindGameObjectWithTag("Player") ? GameObject.FindGameObjectWithTag("Enemy") : GameObject.FindGameObjectWithTag("Player");
        return target;
    }
    void Damage(Collider2D[] c)
    {
        // should damage only happen on contact? right now I just have it running all the time
        if (Array.Find(c, element => element.name == target.name)&& !damageDone)
        {
            whosTurn().GetComponent<basicsOfObjects>().Health -= 10;
            Debug.Log(target.GetComponent<basicsOfObjects>().Health);
            damageDone = true;
            Debug.Log("position: " + target.transform.position.y);
            // target position supposed to be -3.7
            Debug.Log("transform position: " + transform.position.y);
            if (transform.position.y - 1.5f < target.transform.position.y)
            {
                GameObject.Find("EnemyProjectile").GetComponent<EnemyCircleScript>().initialCall = false;
                nextTurn();
            }
            //yield WaitForSecondsRealtime(3);  
        }
        
        /*    
        if (Array.Find(c, element=>element.name=="torso"))
            Health -= 30;
        if (Array.Find(c, element=>element.name=="arms") | Array.Find(c, element=>element.name=="legs"))
            Health -= 10;
        if (Array.Find(c, element=>element.name=="feet"))
            Health -= 5;*/
    }

    // need something to check that the projectile landed and a new turn has started
    void nextTurn()
    {
        //checking the amt of turns the player/ target has
        current.GetComponent<basicsOfObjects>().turn= !(current.GetComponent<basicsOfObjects>().turn);

        damageDone = false;
        transform.position=beginning;
        //restarts turn also there is a problem here at the start on the enemys turn
        GetComponent<circlescript>().onStart();
            
        
    }
}

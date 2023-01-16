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
     public GameObject whosTurn()
    {
        //checks to see whose turn it is so who the  damage will be going to... NO SELF DAMAGE!
        target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<basicsOfObjects>().turn ? GameObject.FindGameObjectWithTag("Player") : GameObject.FindGameObjectWithTag("Enemy");
        current = target == GameObject.FindGameObjectWithTag("Player") ? GameObject.FindGameObjectWithTag("Enemy") : GameObject.FindGameObjectWithTag("Player");
        return target;
    }
    void Damage(Collider2D[] c)
    {
        // should damage only happen on contact? right now I just have it running all the time
        if (Array.Find(c, element => element.name == target.name)&& !damageDone)
        {
            target.GetComponent<basicsOfObjects>().Health -= 10;
            
            damageDone = true;
        }

    }

    // need something to check that the projectile landed and a new turn has started
    public void nextTurn()
    {
        Debug.Log("next turn");
        //checking the amt of turns the player/ target has

        damageDone = false;
        transform.position=beginning;
        //restarts turn also there is a problem here at the start on the enemys turn
        /*target.GetComponent<basicsOfObjects>().turn = !target.GetComponent<basicsOfObjects>().turn;
        Debug.Log("target "+target);
        current.GetComponent<basicsOfObjects>().turn = !current.GetComponent<basicsOfObjects>().turn;
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<basicsOfObjects>().turn)
            GetComponent<circlescript>().onStart();
        if(GameObject.FindGameObjectWithTag("Enemy").GetComponent<basicsOfObjects>().turn)
            GetComponent<EnemyCircleScript>().onStart();
        whosTurn();
        */


    }
}

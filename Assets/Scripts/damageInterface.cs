using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageInterface : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializedField] public float health; public boolean turn;
    
    void Start()
    {
        health = 100f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //&& GameObject.FindGameObjectWithTag("Player")
        if (!circlescript.playerOneTurn)
        {
            if(Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.FromToRotation(angleThrown, Vector2.down), Physics.DefaultRaycastLayers!=null)
                Damage(Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.FromToRotation(angleThrown, Vector2.down),Physics.DefaultRaycastLayers)
        }
    }

    void Damage(Colliders[] c)
    {
        if (c.contatins("head"))
            health -= 50;
        if (c.contains("torso"))
            health -= 30;
        if (c.contains("arms") || c.contains("torso"))
            health -= 10;
        if (c.contains("feet"))
            health -= 5;
    }
}

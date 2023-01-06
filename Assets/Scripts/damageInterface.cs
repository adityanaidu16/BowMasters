using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageInterface : MonoBehaviour
{
    // Start is called before the first frame update
   // [SerializedField]
    private float Health; public bool turn;

    Collider[] hitColliders;
    Vector3 angleThrown;
    GameObject oppenent;


    void Start()
    {
        Health = 100f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //&& GameObject.FindGameObjectWithTag("Player")
        if (circlescript.playerOneTurn)
        {
            if (Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.FromToRotation(angleThrown, Vector2.down), Physics.DefaultRaycastLayers) != null)
            {
                hitColliders = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.FromToRotation(angleThrown, Vector2.down), Physics.DefaultRaycastLayers);
                Damage(hitColliders);
            }
                
        }
    }

    void Damage(Collider[] c)
    {
        if (c.contatins(Gameobject.name("head")))
            Health -= 50;
        if (c.contains(Gameobject.name("torso")))
            Health -= 30;
        if (c.contains(Gameobject.name("arms")) || c.contains(Gameobject.name("torso")))
            Health -= 10;
        if (c.contains(Gameobject.name("feet")))
            Health -= 5;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicsOfEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float Health;
    public bool turn;
    public int amtOfTurns;

    void Start()
    {
        turn = GameObject.FindGameObjectWithTag("Player") == gameObject ? true : false;
        amtOfTurns = gameObject == GameObject.FindGameObjectWithTag("Player") ? 3 : -5;
        Health = 20f;
    }
    private void Update()
    {
        Debug.Log("Turn: " + turn);
        if (amtOfTurns > -1)
            turn = true;
        else
            turn = false;
        if (Health < 0f)
            Destroy(gameObject);
        //amtOfTurns = turn && amtOfTurns == -5 ? 3 : -5;
        //something that will end level or see that level failed
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicsOfObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public float Health;
    public bool turn;
    public int amtOfTurns;

    void Start()
    {
        turn = GameObject.FindGameObjectWithTag("Player") == gameObject ? true : false;
        Health = 20f;
    }
    private void Update()
    {
        /*Debug.Log("Turn: " + turn);
        if (amtOfTurns > -1)
            turn = true;
        else
            turn = false;*/
        
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<basicsOfObjects>().turn= !(GameObject.FindGameObjectWithTag("Player").GetComponent<basicsOfObjects>().turn);
        if (Health < 0f)
            Destroy(gameObject);
        //amtOfTurns = turn && amtOfTurns == -5 ? 3 : -5;
        //something that will end level or see that level failed
    }

}

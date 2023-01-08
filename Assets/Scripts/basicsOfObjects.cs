using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicsOfObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public float Health;
    public bool turn;

    void Start()
    {
        turn = GameObject.FindGameObjectWithTag("Player") == gameObject ? true : false;
        Health = 100f;
    }
    private void Update()
    {
        if (Health < 0f)
            Destroy(gameObject);
    }

}

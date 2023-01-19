using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trajectoryScript : MonoBehaviour
{
    public GameObject Trajectory;
    public GameObject Trajectory1;
    public GameObject Trajectory2;


    private Vector3 trajMove;
    private Vector3 trajMove1;
    private Vector3 trajMove2;

    public Vector3 current;
    public Vector3 current1;
    public Vector3 current2;

    // Start is called before the first frame update
    void Start()
    {
        Trajectory = GameObject.FindGameObjectWithTag("Trajectory");
        Trajectory1 = GameObject.Find("traj (1)");
        Trajectory2 = GameObject.Find("traj (2)");

        current = transform.position;
        current1 = transform.position;
        current2 = transform.position;

        Trajectory.GetComponent<Renderer>().enabled = false;
        Trajectory1.GetComponent<Renderer>().enabled = false;
        Trajectory2.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Projectile").GetComponent<circlescript>().trajOn == true)
        {

            Trajectory.GetComponent<Renderer>().enabled = true;
            Trajectory1.GetComponent<Renderer>().enabled = true;
            Trajectory2.GetComponent<Renderer>().enabled = true;

            trajMove.x = current.x + GameObject.Find("Projectile").GetComponent<circlescript>().targMult / 42f;
            trajMove.y = current.y + GameObject.Find("Projectile").GetComponent<circlescript>().heightMult / 21f;

            trajMove1.x = current.x + GameObject.Find("Projectile").GetComponent<circlescript>().targMult / 16f;
            trajMove1.y = current.y + GameObject.Find("Projectile").GetComponent<circlescript>().heightMult / 6f;

            trajMove2.x = current.x + GameObject.Find("Projectile").GetComponent<circlescript>().targMult / 4f;
            trajMove2.y = current.y + GameObject.Find("Projectile").GetComponent<circlescript>().heightMult / 2f;

            Trajectory.transform.localPosition = trajMove;
            Trajectory1.transform.localPosition = trajMove1;
            Trajectory2.transform.localPosition = trajMove2;
        }
        else
        {
            Trajectory.GetComponent<Renderer>().enabled = false;
            Trajectory1.GetComponent<Renderer>().enabled = false;
            Trajectory2.GetComponent<Renderer>().enabled = false;
        }
    }
}

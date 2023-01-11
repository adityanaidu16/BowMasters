using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircleScript : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public Rigidbody2D rb;

    public float speed = 10f;

    public Vector3 movePosition;
    public Vector3 current;

    private float playerX;
    private float targetX;
    private float nextX;
    private float dist;
    private float baseY;
    private float height;
    private bool fire;
    private bool trajOn;
    private float heightMult;
    private float targMult;
    public bool playerOneTurn;

    // Start is called before the first frame update
    void Start()
    {
        current = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Enemy");
        fire = false;
       // playerOneTurn = true;
        //so it doesnt move initially
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
    }




    public void onStart()
    {
        fire = false;
        transform.position = current;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("enemy turn: " + target.GetComponent<basicsOfObjects>().turn);

        if (target.GetComponent<basicsOfObjects>().turn)
        {
            onStart();
            //transform.position = current;
            trajOn = true;
            
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            fire = true;
            heightMult = Random.Range(4.7f, 6.5f);

            Debug.Log(fire);
            if (fire)
            {
                Debug.Log("in fire loop");


                /**/ playerX = target.transform.position.x;
                 targetX = 9 - targMult;
                 dist = targetX - playerX;
                 nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
                 baseY = Mathf.Lerp(target.transform.position.y, player.transform.position.y, (nextX - playerX) / dist);
                 height = heightMult * (nextX - playerX) * (nextX - targetX) / (-0.25f * dist * dist);

                 movePosition = new Vector3(nextX, baseY + height, transform.position.z);

                 transform.rotation = LookAtTarget(movePosition - transform.position);
                 transform.position = movePosition;//*/

               // gameObject.GetComponent<Rigidbody2D>().AddForce((target.transform.position - player.transform.position) * 2/10, ForceMode2D.Impulse);

            }
        }

        
    }

    public static Quaternion LookAtTarget(Vector2 r)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg);
    }
}
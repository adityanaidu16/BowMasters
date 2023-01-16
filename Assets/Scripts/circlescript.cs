using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circlescript : MonoBehaviour
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
    public bool fire;
    private bool trajOn;
    private float heightMult;
    private float targMult;
    public bool playerOneTurn, pressed, letGo;
   

    // Start is called before the first frame update
    void Start()
    {
        current = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Enemy");
        fire = false;
        playerOneTurn = player.GetComponent<basicsOfObjects>().turn;
        //so it doesnt move initially
        GetComponent<Rigidbody2D>().constraints=RigidbodyConstraints2D.FreezePosition;
        letGo = false; pressed = false;
    }




    public void onStart()
    {
        fire = false;
        transform.position=current;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        target.GetComponent<basicsOfObjects>().turn = false; player.GetComponent<basicsOfObjects>().turn = true;
        letGo = false; pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (player.GetComponent<basicsOfObjects>().turn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                pressed = true;
                Debug.Log("pressed down");
                transform.position = current;
                trajOn = true; 
            }
            if (Input.GetMouseButtonUp(0))
            {
                letGo = true;
                Debug.Log("let go");
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                fire = true;
                playerOneTurn = false;
                heightMult = 4 * (player.transform.position.y - mousePos.y);
                targMult = 8 * (player.transform.position.x - mousePos.x);
               // Debug.Log(heightMult);
                //Debug.Log(targMult);
                //Debug.Log(target.transform.position.x);
            
            
            }

            if (fire&pressed&letGo)
            {
                
                Vector3 prevPosition=transform.position;
            
                playerX = player.transform.position.x;
                targetX = targMult-7;
                dist = targetX - playerX;
                nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
                baseY = Mathf.Lerp(player.transform.position.y, target.transform.position.y, (nextX - playerX) / dist);
                height = heightMult * (nextX - playerX) * (nextX - targetX) / (-0.25f * dist * dist);

                movePosition = new Vector3(nextX, baseY + height, transform.position.z);

                transform.rotation = LookAtTarget(movePosition - transform.position);
                transform.position = movePosition;

                if (transform.position == prevPosition)
                {
                    letGo = false;pressed = false;
                    player.GetComponent<basicsOfObjects>().turn = false;
                    target.GetComponent<basicsOfObjects>().turn = true;
                    gameObject.GetComponent<damageInterface>().nextTurn();
                    

                }
                    

            }
        }
        
    }

    public static Quaternion LookAtTarget(Vector2 r)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl: MonoBehaviour
{

    public float speed = 100.0f;
    public float maxHealth = 6f;
    public static float health = 6f;
    public Image healthBar;

    public static bool gameOver = false;

    public float fireRate = 0.1f;
    private float nextFire = 0.0f;

    public float hitIframes = 3f;
    private float nextHit = 0.0f;
    private int blinkValue = 0;

    public Rigidbody2D rb;
    public MapController mapScript;
    public GameObject projectile;

    private float translationX;
    private float translationY;
    private Vector3 heading = new Vector3(0, 1, 0);


    Vector2 lookDirection = new Vector2(1, 0);

    private Animator animation;
    public SpriteRenderer CharacterSprite;
    public SpriteRenderer CompanionSprite;
    public Sprite CharacterSpriteUp;
    public Sprite CharacterSpriteDn;

    public AudioClip hitClip;
    public AudioClip shootClip;
    //private Sprite CompanionSprite;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        health = maxHealth;
        animation = GetComponent<Animator>();
        AudioSource audio = GetComponent<AudioSource>();
    }


    public GameObject FindClosestTile()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("WorldTile");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }

       // Debug.Log(distance);

        if (distance < 200) // if tiles are resized this number might need to change.
        {
            return closest;
        }
        else
        {
            return null;
        }
    }


    void OnGUI()
    {

        if ( Event.current.Equals(Event.KeyboardEvent("space")) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            GetComponent<AudioSource>().clip = shootClip;
            GetComponent<AudioSource>().Play();

            GameObject shotInstance = Instantiate(projectile, transform.position, transform.rotation);
            shotInstance.GetComponent<Rigidbody2D>().velocity = -heading*10; //shoots in opposite of heading direction cause its just easier to attack approaching enemies that way
        }



    }



    void OnCollisionEnter2D(Collision2D other)
    {
        //detect if player touches something that can damage them
        if (other.gameObject.CompareTag("Enemy") && Time.time > nextHit)
        {
            nextHit = Time.time + hitIframes;
            health -= 1;

            GetComponent<AudioSource>().clip = hitClip;
            GetComponent<AudioSource>().Play();

            float increment = health / maxHealth; //how much the bar will move up/down based on max hp and 260 (number mask reaches when the bar looks empty)

            //Debug.Log($"Health: {health}, increment: {increment}");

            healthBar.fillAmount = increment;

            if (health <=0)
            {
                Debug.Log("YOU DEAD");
                gameOver = true;
                
                speed = 0;
            }
        }
        //detect if player touches a piece
        if (other.gameObject.CompareTag("Piece"))
        {
            Debug.Log("pick up piece" + other.transform.name);
            if (other.transform.name == "Piece2")
            {
                Destroy(other.gameObject);
                mapScript.addTile(1);
            }
            if (other.transform.name == "Piece3")
            {
                Destroy(other.gameObject);
                mapScript.addTile(2);
            }
            if (other.transform.name == "Piece4")
            {
                Destroy(other.gameObject);
                mapScript.addTile(3);
            }
            if (other.transform.name == "Piece5")
            {
                Destroy(other.gameObject);
                mapScript.addTile(4);
            }
            if (other.transform.name == "Piece6")
            {
                Destroy(other.gameObject);
                mapScript.addTile(5);
            }
            if (other.transform.name == "Piece7")
            {
                Destroy(other.gameObject);
                mapScript.addTile(6);
            }
            if (other.transform.name == "Piece8")
            {
                Destroy(other.gameObject);
                mapScript.addTile(7);
            }
            if (other.transform.name == "Piece9")
            {
                Destroy(other.gameObject);
                mapScript.addTile(8);
            }
        }

        //detect if player touches win area
        if (other.gameObject.CompareTag("Winner"))
        {
            gameOver = true;
            Debug.Log("WINNER SCREEN :D");
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0,0,0); //keep the character at the same rotation even when parented to a tile that gets rotated

        translationX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        translationY = Input.GetAxis("Vertical") * speed * Time.deltaTime;


        Vector2 move = new Vector2(translationX, translationY);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animation.SetFloat("Horizontal", lookDirection.x);
        animation.SetFloat("Vertical", lookDirection.y);
        animation.SetFloat("Speed", move.magnitude);



        if ((Mathf.Abs(Input.GetAxisRaw("Horizontal")) + Mathf.Abs(Input.GetAxisRaw("Vertical"))) > 0)
        {

            //if holding any direction, update player's heading direction which is used elsewhere to choose which direction to shoot projectile
            heading = Vector3.Normalize(rb.velocity);
        }




        rb.AddForce(Vector3.up * translationY);
        rb.AddForce(Vector3.right * translationX);

        //set parent to closest tile
        if (FindClosestTile() != null)
        {
            transform.SetParent(FindClosestTile().transform);
        }

        //damage blink
        if (Time.time < nextHit)
        {
            blinkValue += 1;

            if (blinkValue>=8)
            {
                blinkValue = 0;
            }
            if (blinkValue <= 4)
            {
                CharacterSprite.enabled = true;
            }
            else
            {
                CharacterSprite.enabled = false;
            }
        }
        else if (CharacterSprite.enabled == false)
        {
            CharacterSprite.enabled = true;
        }

    }
}

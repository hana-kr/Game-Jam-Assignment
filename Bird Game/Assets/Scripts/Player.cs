using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 initialPoint;
    bool surface = false;
    public int BirdCount = 0 ;
    public int CoinCount = 0;
    public EventSystemCustom eventSystem;
    public Animator anim;
    public GameObject Chest;
    public GameObject Coin;
    public void Awake()
    {
        anim = GetComponent<Animator>();
        initialPoint = transform.position;
    }
    private void Update()
    {
        if(surface == true)
        {
            StartCoroutine(ExecuteAfterTime(3));
            surface = false;
            Debug.Log( "birds:" + BirdCount);
        }
        if(Coin != null)
        {
            CoinCount += 20;
            Debug.Log( "coins:" +CoinCount);
            Destroy(Coin);
            Debug.Log("hereeee");
            eventSystem.UpdatedCoins.Invoke();
        }
        if(BirdCount >= 30)
        {
            eventSystem.GameOver.Invoke();
        }
        if(Chest != null && CoinCount>= 240)
        { 
            eventSystem.Win.Invoke();
            Debug.Log("you wonn");
            Destroy(this.gameObject);
        }
        
    }
    
    public void OnMouseUp()
    {
        Vector2 direction = initialPoint - transform.position;
        GetComponent<Rigidbody2D>().AddForce(direction *350);
        GetComponent<Rigidbody2D>().gravityScale = 0.4f;
        BirdCount++;
        eventSystem.UpdatedBirds.Invoke();
    }
    public void OnMouseDrag()
    {
        Vector3 PlayerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(PlayerPosition.x , PlayerPosition.y);
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone")) 
        {
         
            StartCoroutine(ExecuteAfterTime(3));

        }
        if (collision.gameObject.CompareTag("Coin"))
        {
        
            Coin = collision.gameObject;

        }
        if (collision.gameObject.CompareTag("Chest"))
        {
            Chest = collision.gameObject;
        }
    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("Hit", true);
        if (collision.gameObject.CompareTag("Surface"))
        {
            surface = true;
           
        }
        

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("Hit", false);
      
        if (collision.gameObject.CompareTag("Surface"))
        {
            surface = false;
            Debug.Log(surface);

        }

    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Vector2 StopForce = new Vector2(0,0);

        transform.position = initialPoint;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        transform.position = initialPoint;
        

    }
}

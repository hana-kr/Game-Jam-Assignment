using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 initialPoint;

    public void Awake()
    {
        initialPoint = transform.position;
    }
    private void Update()
    {
        
    }
    private void OnMouseDown()
    {
        
    }
    public void OnMouseUp()
    {
        Vector2 direction = initialPoint - transform.position;
        GetComponent<Rigidbody2D>().AddForce(direction *300);
        GetComponent<Rigidbody2D>().gravityScale = 0.4f;
    }
    public void OnMouseDrag()
    {
        Vector3 PlayerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(PlayerPosition.x , PlayerPosition.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Surface"))
        {
            StartCoroutine(ExecuteAfterTime(5));

           
        }


    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        transform.position = initialPoint;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

    }
}

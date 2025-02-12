using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class KamikadzeMove : MonoBehaviour
{
    public MovePlayer player;
    public float moveSpeed;
    Rigidbody2D rb;
    private Vector2 movement;
    public GameObject BoomEff;
    
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<MovePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
       // if (winText.active == true) Destroy(gameObject);    
        Vector2 direction = player.trans.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        rb.rotation = angle;
        movement = direction;
        rb.MovePosition((Vector2)transform.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            
            Instantiate(BoomEff,gameObject.transform.position, Quaternion.identity);    
            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Instantiate(BoomEff, gameObject.transform.position, Quaternion.identity);
            if (player.winText.active == false) 
            {
                player.HP -= 20f;
                player.HPbar.fillAmount = player.HP / 100;
            }
                Destroy(gameObject);
            

        }
    }
}

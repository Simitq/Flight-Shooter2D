using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public float speed;
    Vector2 direction;
    public Rigidbody2D _rb;
    public Rigidbody2D rbGun;
    public float HP = 100f;
    public Image HPbar;
    public Transform trans;
    public GameObject winText;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); 
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");


    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + direction * speed * Time.fixedDeltaTime);
        rbGun.MovePosition(_rb.position);
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            if (winText.active == false)
            {
                HP -= 10;
                HPbar.fillAmount = HP / 100;
            }
            Destroy(collision.gameObject);
        }
    }
    
}

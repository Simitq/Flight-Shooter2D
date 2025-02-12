using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float attackSpeed;
    Vector2 mousePosition;
    public Camera cam;
    public GameObject bulletPrefab;
    public float speedBullet;
    public Transform spawnBullet;
    Rigidbody2D rb;
    public Rigidbody2D rbGun;
    public GameObject winText;


    private void Start()
    {
        StartCoroutine(spawnSpeedBullet());
    }

    private void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePosition - rbGun.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rbGun.rotation = angle;
    }

    IEnumerator spawnSpeedBullet()
    {
        while (winText.active == false)
        {
            yield return new WaitForSeconds(attackSpeed);
            GameObject bullet = Instantiate(bulletPrefab, spawnBullet.position, Quaternion.identity);
            rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(rbGun.transform.up * speedBullet, ForceMode2D.Impulse);

        }
    }
}

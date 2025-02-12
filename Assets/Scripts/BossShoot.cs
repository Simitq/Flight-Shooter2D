using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speedBullet;
    public BossHPBar bossHPBar;

    private void Start()
    {
        StartCoroutine(spawnBullet());
    }

    IEnumerator spawnBullet()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(bossHPBar.AttackSpeed());
            GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * speedBullet, ForceMode2D.Impulse);

        }
    }
}

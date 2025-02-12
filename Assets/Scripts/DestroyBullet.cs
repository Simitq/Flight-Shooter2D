using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyBull());
    }
    IEnumerator DestroyBull()
    {

        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    
}

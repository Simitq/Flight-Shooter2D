using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using static UnityEditor.Timeline.TimelinePlaybackControls;


public class BossHPBar : MonoBehaviour
{
    public float HP = 1000f;
    public float MaxHP = 1000f;
    public float speedRotate = 1f;
    public float attackSpeed = 1f;
    public Image img;
    bool infinity = false;
    bool maxSpeed = false;
    public GameObject infText;
    public GameObject winText;
   


    private void Update()
    {
        gameObject.transform.Rotate(0, 0, -speedRotate/1000);
        if(HP <= 0)
        {
            
            winText.SetActive(true);
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PlayerBullet")
        {
            if (!maxSpeed && HP <= MaxHP / 20) StartCoroutine(Infinity());
            if (!infinity)
            {
                HP -= 10;
                img.fillAmount = HP / 1000;
                if (!maxSpeed) speedRotate += 1;
            }
            Destroy(collision.gameObject);
        }
    }
    public float AttackSpeed()
    {
        if (!maxSpeed) attackSpeed = HP / 1000f + 0.5f;
        return attackSpeed;
    }

    IEnumerator Infinity()
    {
        infinity = true;
        maxSpeed = true;
        infText.SetActive(true);
        yield return new WaitForSeconds(30);
        infText.SetActive(false);
        infinity = false;


    }
}

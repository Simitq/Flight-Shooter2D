using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKamikadze : MonoBehaviour
{
    public GameObject kamikadze;
    public BossHPBar bossHPBar;
    int num = 11;
    int change = 200;
    bool changeBool = false;
    

    private void Start()
    {
        bossHPBar = FindFirstObjectByType<BossHPBar>();
        StartCoroutine(TimeSpawnKamikadze());
        
    }


    public IEnumerator TimeSpawnKamikadze()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.3f,1f));
            Debug.Log(bossHPBar.HP);
            if (!changeBool && bossHPBar.HP <= bossHPBar.MaxHP / 4)
            {
                changeBool = true;
                change /= 2;
            }
            while (bossHPBar.HP <= bossHPBar.MaxHP/2 && Random.Range(0,change) == num)
            {
                Debug.Log("Spawn");
                Instantiate(kamikadze, gameObject.transform.position, Quaternion.identity);
            }
            
        }
    }
}

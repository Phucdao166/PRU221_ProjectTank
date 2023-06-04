using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanw : MonoBehaviour
{
    [SerializeField] GameObject enemytank;
    [SerializeField] GameObject enemytank11;
    public GameObject fwpalyer;
    public float speed;
    private float distance;
    [SerializeField] float secondSpawn = 3.5f;
    [SerializeField] float secondSpawn11 = 10f;
    [SerializeField] float minTras;
      [SerializeField] float maxTras;
    private static int enemyTankInstanceCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn( secondSpawn,enemytank));
        StartCoroutine(EnemySpawn(secondSpawn11, enemytank11));
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position,fwpalyer.transform.position);
        Vector2 direction = fwpalyer.transform.position - transform.position;
        direction.Normalize();

       // float angle = Mathf.Atan2(direction.x,direction.y) * Mathf.Rad2Deg;
        if (distance > 1)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, fwpalyer.transform.position, speed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        
    }
    private IEnumerator EnemySpawn(float interval, GameObject enemy){
       
        while (true)
        {
            yield return new WaitForSeconds(interval);
            if (enemyTankInstanceCount < 5)
            {
                GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
                enemyTankInstanceCount++;
                //StartCoroutine(EnemySpawn( interval, newEnemy));
            }
        }
    }
    private void OnDestroy()
    {
        enemyTankInstanceCount--;
    }
}


  

 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    public float enemySpeed;
    public float enemyMaxFollow;
    private float distance;

    public Vector3 SpawnRoom;

    public float bulletDamage;
    public float enemyHealth;
    private GameObject currentTarget;

    private EnemiesDefeated enemyDefeatScript;
    public GameObject enemyPS;
    private Transform enemyPos;

    private bool playerInRoom;

    // Start is called before the first frame update
    void Start()
    {
        enemyDefeatScript = GameObject.Find("DontDestroyED").GetComponent<EnemiesDefeated>();
        player = GameObject.Find("Player");
        SpawnRoom = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        enemyPos = this.gameObject.transform;
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < enemyMaxFollow)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemySpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        if (enemyHealth == 0)
        {
            Instantiate(enemyPS, enemyPos.transform.position, Quaternion.identity);
            enemyDefeatScript.enemyNum -= 1;
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" )
        {
            currentTarget = collision.gameObject;
            enemyHealth -= bulletDamage;
            Destroy(currentTarget);
        }
        if (collision.gameObject.tag == "Wall")
        {
            this.gameObject.transform.position = SpawnRoom;
        }
    }
}

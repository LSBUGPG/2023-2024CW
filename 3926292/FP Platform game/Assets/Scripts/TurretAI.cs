using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public Transform player;
    public float attackTimer = 1;
    bool attackRest;
    public GameObject projectile;

    public float attackRange = 20;
    public float sightRange = 25;

    void Update()
    {
        attackRange = Vector3.Distance(player.position, transform.position);
        if(attackRange <= sightRange)
        {
            AttackPlayer();
        }
    }
    private void AttackPlayer()
    {
        transform.LookAt(player);

        if (!attackRest)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 50f, ForceMode.Impulse);
            rb.AddForce(transform.up * 2f, ForceMode.Impulse);

            attackRest = true;
            Invoke(nameof(ResetAttack), attackTimer);
        }
    }
    private void ResetAttack()
    {
        attackRest = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void Reset()
    {
        player = GameObject.Find("PlayerObj").transform;
    }
}

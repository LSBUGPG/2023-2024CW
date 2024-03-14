using UnityEngine;

public class KnifeValues : MonoBehaviour
{
    public int weaponDmg = 2;
    public Rigidbody rb;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyAttributes currentHealth = collision.gameObject.GetComponent<EnemyAttributes>();
            if (currentHealth != null)
                currentHealth.TakeDamage(weaponDmg);
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("whatIsGround"))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;

        }
        rb.velocity = new Vector3(0, 0, 0);

    } 
    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > 0.1f)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(GetComponent<Rigidbody>().velocity), Time.deltaTime * 10);
               
    }

}

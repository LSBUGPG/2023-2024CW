using UnityEngine;

public class ProjectileExpire : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HP currentHp = collision.gameObject.GetComponent<HP>();
            if (currentHp != null)
                currentHp.Damage(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Level"))
        {
            Destroy(gameObject);
        }
    }
  
}

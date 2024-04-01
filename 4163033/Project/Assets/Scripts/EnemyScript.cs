using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Target;
    public GameObject Gun;

    private GameObject CurrentBullet;

    private Vector3 Direction;

    void Shoot()
    {
        Direction = (Target.transform.position - gameObject.transform.position); // endposition - startposition
        Direction = Vector3.Normalize(Direction);
        CurrentBullet = Instantiate(Bullet, Gun.transform.position, Quaternion.identity);
        CurrentBullet.transform.LookAt(Target.transform);
        CurrentBullet.GetComponent<MeshRenderer>().enabled = true;
        CurrentBullet.GetComponent<Rigidbody>().AddForce(Direction * 1000.0f, ForceMode.Force);
        StartCoroutine(BreakBullet(CurrentBullet));
        Invoke("Shoot", 1.0f);
    }

    IEnumerator BreakBullet(GameObject Bullet)
    {
        yield return new WaitForSeconds(5f);
        Destroy(Bullet);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Shoot", 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

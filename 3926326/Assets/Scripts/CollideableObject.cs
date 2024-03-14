using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideableObject : MonoBehaviour
{

    private Collider2D z_Collider;
    [SerializeField]
    private ContactFilter2D z_filter;
    private List<Collider2D> z_CollideObjects = new List<Collider2D>(1);

    // Start is called before the first frame update
    protected virtual void Start()
    {
        z_Collider= GetComponent<Collider2D>();
    }

    protected virtual void Update()
    {
        z_Collider.OverlapCollider(z_filter, z_CollideObjects);
        foreach(var o in z_CollideObjects)
        {
            OnCollided(o.gameObject);
        }
    }

    protected virtual void OnCollided(GameObject collidedobject)
    {
        Debug.Log("Collided with " + collidedobject.name);
    }
}

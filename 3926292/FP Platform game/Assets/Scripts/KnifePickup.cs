using UnityEngine;
using UnityEngine.UI;

public class KnifePickup : MonoBehaviour
{
    public bool hasKnife = true;
    public float pickUpDistance = 5f;
    public GameObject player;
    public GameObject KnifePrefab;
    public GameObject handKnife;
    public float throwForce = 75f;
    public Transform knifeOrigin;

    private bool canReturnKnife = true;
    private float returnKnifeCooldown = 3f;
    public Text cooldownText;

    public bool hasYellowKey = false;
    public bool hasRedKey = false;

    public Canvas knifeUI;

    public Camera cam;

    public void Start()
    {
        hasKnife = false;
        knifeUI.enabled = false;
        handKnife.SetActive(false);

    }
    void Update()
    {
       if (Input.GetMouseButtonDown(0) && hasKnife)
        {
            ThrowKnife();
            hasKnife = false;
        } 
       if (Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
       
        KnifeInHand(); 
        
       if (Input.GetMouseButtonUp(1))
       {
            ReturnKnife();
       }

        if (!canReturnKnife)
        {
            returnKnifeCooldown -= Time.deltaTime;

            if (returnKnifeCooldown <= 0f)
            {
                canReturnKnife = true;
                returnKnifeCooldown = 3f;
            }
            UpdateCooldownText(returnKnifeCooldown);
        }
    }

    public void PickUp()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickUpDistance);

        foreach (Collider collider in colliders)
        {
            switch (collider.tag)
            {
                case "Knife":
                    GrabKnife();
                    Destroy(collider.gameObject);
                    break;
                case "RedKey":
                    Destroy(collider.gameObject);
                    hasRedKey = true;
                    break;
                case "YellowKey":
                    Destroy(collider.gameObject);
                    hasYellowKey = true;
                    break;
                case "YellowDoor":
                case "RedDoor":
                    if ((collider.tag == "YellowDoor" && hasYellowKey) || (collider.tag == "RedDoor" && hasRedKey))
                    {
                        Destroy(collider.gameObject);
                    }
                    break;
                   
            }
        }

    }

    public void ThrowKnife()
    {
        knifeUI.enabled = false;

        GameObject knifeIns = Instantiate(KnifePrefab, knifeOrigin.position, knifeOrigin.rotation);
        Rigidbody knifeRb = knifeIns.GetComponent<Rigidbody>();
        knifeIns.transform.rotation = Quaternion.LookRotation(cam.transform.forward);

        knifeRb.AddForce(knifeOrigin.forward * throwForce, ForceMode.Impulse);       

    } 
    public void KnifeInHand()
    {
        if (hasKnife)
        {
            handKnife.SetActive(true);
        }
        else
        {
            handKnife.SetActive(false);
        }
    }

    private void ReturnKnife()
    {
        if (!canReturnKnife)
        {
            return;
        }

        GameObject[] knives = GameObject.FindGameObjectsWithTag("Knife");
        foreach (GameObject knife in knives)
        {
            ReturnObject(knife);
        }
        canReturnKnife = false;
    } 

    private void UpdateCooldownText(float cooldownTime)
    {
        if (cooldownText != null)
        {
            if (cooldownTime > 0f)
            {
                cooldownText.text = $"Cooldown: {Mathf.Max(0, cooldownTime):F1}s";
            }
            if (cooldownTime > 2.9f)
            {
                cooldownText.text = "";
            }
        }
    }
    void ReturnObject(GameObject knifeObject)
    {
        knifeObject.transform.position = player.transform.position;
        Rigidbody rb = knifeObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero; 
            rb.isKinematic = true;
        }
        Destroy(knifeObject, 0.1f);
        GrabKnife();
    }
    public void GrabKnife()
    {
        hasKnife = true;
        knifeUI.enabled = true;
    }

    private void Reset()
    {
        cam = FindObjectOfType<Camera>();
    }

}

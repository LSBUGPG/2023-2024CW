using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float playerSpeed;
    public bool speedBoostActive;

    private Camera cam;
    public Rigidbody2D rb;
    private Vector2 mousePosition;

    private GameObject currentRoom;
    private Vector3 currentRoomFixed;
    private GameObject room1;

    public float playerHealth;
    private bool damageAgain = true;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
        room1 = GameObject.Find("Room1");
        currentRoom = room1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.up * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * playerSpeed * Time.deltaTime;
        }

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        if (playerHealth == 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg -90;
        rb.rotation = angle;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Room"))
        {
            currentRoom = collision.gameObject;
            currentRoomFixed = new Vector3(currentRoom.transform.position.x, currentRoom.transform.position.y, currentRoom.transform.position.z -10);
            cam.transform.position = currentRoomFixed;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && damageAgain == true)
        {
            playerHealth -= 1;
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            damageAgain = false;
            StartCoroutine(DamageCooldown());
        }
    }
    public void ActivateSpeedBoost()
    {
        if (!speedBoostActive)
        {
            speedBoostActive = true;
            playerSpeed += 5;
            StartCoroutine(SpeedBoostTime());
        }
    }

    IEnumerator SpeedBoostTime()
    {
        yield return new WaitForSeconds(5);
        speedBoostActive = false;
        playerSpeed -= 5;
    }
    IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        damageAgain = true;
    }
}

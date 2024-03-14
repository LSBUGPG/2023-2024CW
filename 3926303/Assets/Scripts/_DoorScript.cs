using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _DoorScript : MonoBehaviour
{
    [SerializeField] Animator doorAnim;
    [SerializeField] int randomTimer;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
        randomTimer = Random.Range(20, 30);
        StartCoroutine(doorKiller());
    }
    public void doorTrigger()
    {
        doorAnim.SetBool("doorOpen", true);
        StartCoroutine(doorLongevity());
    }
    IEnumerator doorLongevity()
    {
        yield return new WaitForSeconds(10);
        doorAnim.SetBool("doorOpen", false);
    }
    IEnumerator doorKiller()
    {
        yield return new WaitForSeconds(randomTimer);
        randomTimer = Random.Range(5, 30);
        doorAnim.SetBool("doorOpen", true);
        StartCoroutine(doorLongevity());
        StartCoroutine(doorKiller());
    }
}

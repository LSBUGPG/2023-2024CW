using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public HP HPMngr;
    public Renderer Renderer;

    public Material checkpointOn;
    public Material checkpointOff;
    void Start()
    {
        HPMngr = FindObjectOfType<HP>(); 
    }
    private void CheckpointOn()
    {
        Renderer.material = checkpointOn;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HPMngr.SetSpawnPoint(transform.position);
            CheckpointOn();

        }
    }
}

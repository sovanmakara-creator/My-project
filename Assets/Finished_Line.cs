using UnityEngine;

public class Finished_Line : MonoBehaviour
{
    public GameObject Player;
    public GameObject Line;

    // Use OnTriggerEnter if the finish line has "Is Trigger" checked
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finished"))
        {
            
            
        }
    }
}
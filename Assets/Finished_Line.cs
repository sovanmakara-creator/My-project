using UnityEngine;
using System.Collections;

public class Finished_Line : MonoBehaviour
{
    public GameObject Player;
    public GameObject Line;
    public GameObject WinningPanel;

    // Use OnTriggerEnter if the finish line has "Is Trigger" checked
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finished"))
        {
            StartCoroutine(ShowGameOverAfterDelay());
            
        }
    }
    IEnumerator ShowGameOverAfterDelay(){
            Debug.Log("You have reached the finish line");
            yield return new WaitForSeconds(0.5f);
            WinningPanel.SetActive(true);
             
                    }
}
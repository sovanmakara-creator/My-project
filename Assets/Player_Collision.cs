using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    public PlayerMovement01 movement;
    void OnCollisionEnter( Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log("We hit an obstacle");
            movement.enabled = false;
        }
    }

    void OnTriggerEnter (Collider col)
    {
 if (col.tag == "Obstacle"){
     Debug.Log("We hit an obstacle");
            movement.enabled = false;
 }
    }
}

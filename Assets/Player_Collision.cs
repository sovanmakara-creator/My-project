using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    public PlayerMovement01 movement;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log("We hit an obstacle");
            movement.enabled = false;
        }
    }
    // void OCollisionEnter(Collision collisionFin)
    // {
    //     if (collisionFin.collider.tag == "Finished")
    //     {
    //         Debug.Log("Hit the finished Line");
    //     }
    // }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Obstacle")
        {
            Debug.Log("We hit an obstacle");
            movement.enabled = false;
        }
    }
}

using UnityEngine;

public class DoorTriggerController : MonoBehaviour
{
    public Transform cameraTransform;
    public Vector3 test;

    void moveCamera(){

        cameraTransform.position = test;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            moveCamera();
        }
    }
}

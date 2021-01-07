using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    //bullet variables
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float lastFireTime;
    public float fireDelayTime;

    // Update is called once per frame
    void Update() //input
    {
        //wasd/arrows
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        float shootHor = Input.GetAxisRaw("ShootHorizontal");
        float shootVer = Input.GetAxisRaw("ShootVertical");

        if((shootHor != 0 || shootVer !=0) && Time.time > lastFireTime + fireDelayTime)
        {
            Shoot(shootHor, shootVer);
            lastFireTime = Time.time;
        }
    }

    void FixedUpdate() //best for movement/physics
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //no velocity
    }
    
    void Shoot(float x, float y)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y).normalized * bulletSpeed;
    }
}

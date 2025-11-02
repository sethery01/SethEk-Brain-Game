using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // We need this so we can determine strength later
    public int bulletNumber;
    
    // Speed of the bullet
    public float speed = 12f;

    // Update is called once per frame
    void Update()
    {
        // Moves the bullet upwards after shot
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet collided with: " + collision.gameObject.name);

        // Use a tag to identify what the bullet hit
        if (collision.gameObject.CompareTag("Crate"))
        {
            // Access the Crate script on the hit object
            Crate crate = collision.gameObject.GetComponent<Crate>();
            if (crate != null)
            {
                crate.TakeDamage(bulletNumber);
            }
            Destroy(gameObject);
        }
    }
}

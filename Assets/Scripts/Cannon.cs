using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Listen for input to shoot with proper values
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Shoot(1);
            GameManager.Instance.FireShot(1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GameManager.Instance.FireShot(2);
            Shoot(2);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            GameManager.Instance.FireShot(3);
            Shoot(3);
        }
    }
    
    // Shoots a bullet with the given value
    void Shoot(int value)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().bulletNumber = value;
    }
}

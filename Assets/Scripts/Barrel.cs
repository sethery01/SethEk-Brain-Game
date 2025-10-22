using UnityEngine;

public class Barrel : MonoBehaviour
{
    float angle = 0;

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 direction = mousePos3D - transform.position;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (Mathf.Abs(angle - 90f) < 80f)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle-90);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public int crateValue;
    public float fallSpeed = 2f;
    private TextMeshPro text;

    void Start()
    {
        text = GetComponentInChildren<TextMeshPro>();
        UpdateCrateText();
    }

    void Update()
    {
        // Move down
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Destroy if off screen
        if (transform.position.y < -6f)
        {
            // GameManager.Instance.MissedCrate(); 
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        crateValue -= damage;
        UpdateCrateText();
        
        if (crateValue == 0)
        {
            // GameManager.Instance.AddScore(10);
            Destroy(gameObject);
        }
        else if (crateValue < 0)
        {
            // GameManager.Instance.AddScore(-5);
            Destroy(gameObject);
        }
    }

    void UpdateCrateText()
    {
        if (text != null)
        {
            text.text = crateValue.ToString();
        }
    }
}

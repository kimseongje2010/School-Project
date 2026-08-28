using UnityEngine;

public class Bullet_Destroy : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (this.transform.position.x >= Camera.main.gameObject.transform.position.x + 9f
        || this.transform.position.x <= Camera.main.gameObject.transform.position.x - 9f
        || this.transform.position.y >= Camera.main.gameObject.transform.position.y + 5.2f
        || this.transform.position.y <= Camera.main.gameObject.transform.position.y -5.2f)
        {
            Destroy(this.gameObject);
            // Debug.Log("the bullet is delete");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor") || other.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}

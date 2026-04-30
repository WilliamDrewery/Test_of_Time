   using UnityEngine;

public class BulletBehaviourDefault : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletRB;
    [SerializeField] private float bulletSpeed = 5f;
    private Vector3 target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector2 direction=(target - transform.position).normalized;
        bulletRB.linearVelocity= direction*bulletSpeed;
        if (target == null) return;
    }
    public void SetTarget(Vector3 bulletTarget)
    {
        target = bulletTarget;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            collision.gameObject.GetComponent<EnemyMovement>().health-=1;
        }
        Destroy(gameObject);
    }
}

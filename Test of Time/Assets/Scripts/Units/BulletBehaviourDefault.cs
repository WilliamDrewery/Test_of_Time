   using UnityEngine;

public class BulletBehaviourDefault : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletRB;
    [SerializeField] private float bulletSpeed = 5f;
    public Vector2 target;
    public float bulletDamage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector2 direction=(target - (Vector2)transform.position).normalized;
        bulletRB.linearVelocity= direction*bulletSpeed;
        if ((Mathf.Round(bulletRB.position.x), Mathf.Round(bulletRB.position.y))==(Mathf.Round(target.x), Mathf.Round(target.y))){
            Destroy(gameObject);
        }
    }
    public void SetTarget(Vector3 bulletTarget)
    {
        target = bulletTarget;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            collision.gameObject.GetComponent<EnemyMovement>().health-=bulletDamage;
        }
        Destroy(gameObject);
    }
}

using UnityEngine;

public class BulletBehaviourDefault : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletRB;
    [SerializeField] private float bulletSpeed = 5f;
    private Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!target) return;
        Vector2 direction=(target.position - transform.position).normalized;
        bulletRB.linearVelocity= direction*bulletSpeed;
    }
    public void SetTarget(Transform bulletTarget)
    {
        target = bulletTarget;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //hurt enemy
        Destroy(gameObject);
    }
}

using UnityEngine;

public class TowerGenericManager : MonoBehaviour
{
    public float range;
    private Transform target;
    public float damage;
    public float attackSpeed;
    public float attackCooldown;
    public float cost;
    public GameObject bulletPrefab;
    [SerializeField] public LayerMask enemyMask;
    private GameObject cannon;
    
    void Start()
    {
        cannon = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        AimAtTarget();
        if (!TargetInRange())
        {
            target = null;
        }
        else
        {
            attackCooldown += Time.deltaTime;
            if (attackCooldown >= 1f / attackSpeed)
            {
                GameObject bullet=Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                BulletBehaviourDefault bulletScript=bullet.GetComponent<BulletBehaviourDefault>();
                bulletScript.SetTarget(target.position);
                attackCooldown = 0f; 
                bullet.GetComponent<BulletBehaviourDefault>().bulletDamage=damage;
            }
        }

    }
    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, range, (Vector2)transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
    private void AimAtTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        // Tower and cannon sprites are separate; rotate cannon while keeping the base object stationary
        cannon.transform.rotation = targetRotation;
    }
    private bool TargetInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= range;
    }

}

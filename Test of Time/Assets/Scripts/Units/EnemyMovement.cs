using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject[] path;
    private Transform baseTransform;
    public float speed;
    public float health;
    public bool spawnOne;
    public bool spawnTwo;
    public bool spawnThree;
    public bool spawnFour;
    
    public Sprite spr_idle;
    public Sprite spr_walk_1;
    public Sprite spr_walk_2;
    public float animationSpeed = 6;

    private int spawnNumber;
    private SpriteRenderer renderer;
    private float animationSalt;

    
    void Start()
    {
        baseTransform = GameObject.FindGameObjectWithTag("Base").transform;
        path = GameObject.FindGameObjectsWithTag("Path");
        
        renderer = GetComponent<SpriteRenderer>();
        animationSalt = Random.Range(0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        spawnNumber = spawnFour ? 0 : spawnThree ? 1 : spawnTwo ? 2 : spawnOne ? 3 : -1;
        Vector3 targetPosition = spawnNumber == -1 ? baseTransform.position : path[spawnNumber].transform.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        float angle = Vector2.Angle(transform.position, targetPosition) + 90;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = targetRotation;

        renderer.sprite = (Time.time * animationSpeed + animationSalt) % 2 < 1 ? spr_walk_1 : spr_walk_2;
        

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

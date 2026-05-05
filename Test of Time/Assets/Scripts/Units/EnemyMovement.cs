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
    void Start()
    {
        baseTransform = GameObject.FindGameObjectWithTag("Base").transform;
        path = GameObject.FindGameObjectsWithTag("Path");
    }

    // Update is called once per frame
    void Update()
    {

        if (spawnOne)
        {
            transform.position = Vector2.MoveTowards(transform.position, path[3].transform.position, speed * Time.deltaTime);
        }

        if (spawnTwo)
        {
            transform.position = Vector2.MoveTowards(transform.position, path[2].transform.position, speed * Time.deltaTime);
        }

        if (spawnThree)
        {
            transform.position = Vector2.MoveTowards(transform.position, path[0].transform.position, speed * Time.deltaTime);
        }

        if (spawnFour)
        {
            transform.position = Vector2.MoveTowards(transform.position, path[1].transform.position, speed * Time.deltaTime);
        }

        else
        {
            transform.position = Vector2.MoveTowards(transform.position, baseTransform.position, speed * Time.deltaTime);
        }
        

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

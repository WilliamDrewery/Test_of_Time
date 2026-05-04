using UnityEngine;

public class Paths : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("collided");
            collision.gameObject.GetComponent<EnemyMovement>().spawnOne = false;
            collision.gameObject.GetComponent<EnemyMovement>().spawnTwo = false;
            collision.gameObject.GetComponent<EnemyMovement>().spawnThree = false;
            collision.gameObject.GetComponent<EnemyMovement>().spawnFour = false;
        }
    }
}

using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float speed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3 (speed * horizInput, speed * vertInput, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }
}

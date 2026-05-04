using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed = 10f;
    
    public Sprite spr_idle;
    public Sprite spr_walk1;
    public Sprite spr_walk2;
    public float animationSpeed = 5f;
    
    private SpriteRenderer renderer;
    
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3 (speed * horizInput, speed * vertInput, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement, Space.World);
        
        bool idle = movement == Vector3.zero;
        if (idle) {
		transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
		renderer.sprite = spr_idle;
        } else {
		float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg + 90f;
		Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
		transform.rotation = targetRotation;
		renderer.sprite = Time.time * animationSpeed % 2 < 1 ? spr_walk1 : spr_walk2;
        }
    }
}

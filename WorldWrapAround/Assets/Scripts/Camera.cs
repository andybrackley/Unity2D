using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] float speed = 1;
    private float z;
    private Vector3 position;

    private float left = -1.5f;
    private float right = 1.5f;
    private float leftMax = -2.5f;
    private float rightMax = 2.5f;

    [SerializeField] Transform leftCam;
    [SerializeField] Transform rightCam;
    
    void Start()
    {
        this.z = transform.position.z;
        this.position = transform.position;
    }

    void Update()
    {
        var horz = Input.GetAxis("Horizontal");

        position += Vector3.right * horz * this.speed * Time.deltaTime;
    
        if(position.x < this.leftMax)
        {
            this.position = new Vector3(this.right, 0, this.z);
        }
        else if(position.x > this.rightMax)
        {
            this.position = new Vector3(this.left, 0, this.z);
        }
    }

    void LateUpdate() {
        transform.position = this.position;
        this.leftCam.position = new Vector3(-4f, 0, this.z) + transform.position;
        this.rightCam.position = new Vector3(4f, 0, this.z) + transform.position;
    }
}

using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public DynamicJoystick joystick;
    public float speed = 6.0f;

    private void Start()
    {
    }

    private void Update()
    {
        Vector3 direction = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        direction = direction.normalized * (speed * Time.deltaTime);
        transform.position += direction;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
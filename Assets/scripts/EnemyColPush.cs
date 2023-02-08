using UnityEngine;

public class EnemyColPush : MonoBehaviour
{
    [SerializeField] private float _force;
    private float _backForce, _frontForce;
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        SetForce();
    }

    private void SetForce()
    {
        _frontForce = _force *= _enemy.sizeMultiplier;
        _backForce = _force /= _enemy.sizeMultiplier;
    }

    public void ForceUp()
    {
        _force++;
        SetForce();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {

            Vector3 direction = collision.contacts[0].point - transform.position;
            direction = new Vector3(direction.x, 0f, direction.z).normalized;

            float force = Vector3.Dot(direction, transform.forward) > 0f ? _backForce : _frontForce;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);
            StartCoroutine(_enemy.DelaySetPos());
        }
    }
}
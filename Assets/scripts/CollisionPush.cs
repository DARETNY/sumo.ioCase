using UnityEngine;

public interface IPushable
{
    public void ForceUp();
}

public class CollisionPush : MonoBehaviour, IPushable
{
    [SerializeField] private float _force;
    private float _backForce, _frontForce;
    private BaseSumo _baseSumo;
    private void Start()
    {
        _baseSumo = GetComponent<BaseSumo>();
        SetForce();
    }

    private void SetForce()
    {
        _frontForce = _force *=_baseSumo.sizeMultiplier; // yemedurumu durumunda score eklenecek
        _backForce = _force /=_baseSumo.sizeMultiplier;
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
        }
    }
}
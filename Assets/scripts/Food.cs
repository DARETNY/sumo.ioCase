using UnityEngine;

public class Food : MonoBehaviour, IDetectable
{

    public Transform DetectTransform()
    {
        return this.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IEatable eatable))
        {

            FoodSpawner.Instance.DeactiveFood(this.gameObject);
            eatable.Eat();
        }
    }
}
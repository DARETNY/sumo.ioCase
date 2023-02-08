using UnityEngine;
using UnityEngine.Serialization;

namespace Abstract
{
    public abstract class BaseSumo : MonoBehaviour, IDetectable, IEatable
    {
        public float sizeMultiplier = 1.1f;
        public float scoreMultiplier = 10.0f;
        private int _currentScore = 0;
        private Vector3 _startingScale;
        
       
        [SerializeField] private Score _score;


        protected virtual void Start()
        {
            _startingScale = transform.localScale;
            transform.localScale = _startingScale;

        }
        protected virtual void GrowUp()
        {
            _currentScore += (int)(scoreMultiplier * transform.localScale.x);

            // ScoreManager.instance.UpdateScore(currentScore);
            if (transform.localScale.magnitude < 20)
            {
                _score.UpdateScore(_currentScore);
                transform.localScale *= sizeMultiplier;
            }


        }
        public Transform DetectTransform()
        {
            return this.transform;
        }

        public virtual void Eat()
        {
            GrowUp();
        }


    }
}
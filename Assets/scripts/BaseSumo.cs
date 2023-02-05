using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSumo : MonoBehaviour,IDetectable ,IEatable
{
    public float sizeMultiplier = 1.1f;
    public float scoreMultiplier = 10.0f;
    private int currentScore = 0;
    private Vector3 startingScale;
    [SerializeField] private Score _score;
    

    protected virtual void Start()
    {
        startingScale = transform.localScale;
        transform.localScale = startingScale;

    }
    protected virtual void GrowUp()
    {
        currentScore += (int)(scoreMultiplier * transform.localScale.x);
       
        // ScoreManager.instance.UpdateScore(currentScore);
        if (transform.localScale.magnitude<20)
        {
            _score.UpdateScore(currentScore);
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
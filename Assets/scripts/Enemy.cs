using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class Enemy :BaseSumo
{
    
    private bool isDetected;
    private IDetectable _detectedObject;
    private Vector3 _spawnPosition;
    private EnemyColPush _colPush;
    [SerializeField] private Vector3 spawnArea = new Vector3(5, 0, 5);


    
    override protected void Start()
    {
        base.Start();
        SetLocation();
        _colPush = GetComponent<EnemyColPush>();
    }

    
    void Update()
    {


        if (isDetected && _detectedObject != null)
        {

            if (Vector3.Distance(transform.position, _detectedObject.DetectTransform().position) >= 0.2f)
            {
                transform.rotation = Quaternion.LookRotation(_detectedObject.DetectTransform().position);
                transform.position = Vector3.MoveTowards(transform.position, _detectedObject.DetectTransform().position,
                                                         10 * Time.deltaTime);
            }

        }
        else
        {
            if ((Math.Abs(transform.position.x) >= 26.26741f) || (Math.Abs(transform.position.z) >= 26.26741f))
            {
                SetLocation();
            }
            Vector3 dir = new Vector3(_spawnPosition.x, 0, _spawnPosition.z);
            transform.position += dir.normalized * (2 * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(dir);
            
        }
        
        Fall();
        
        
    }
    void Fall()
    {
        if (transform.position.y<0)
        {
            GameManager.Instance.Count();
            Destroy(this.gameObject);
        }
    }

    private void SetLocation()
    {
        _spawnPosition = new Vector3(
                Random.Range(-spawnArea.x, spawnArea.x),
                0,
                Random.Range(-spawnArea.z, spawnArea.z)
        );
    }

    override protected void GrowUp()
    {
        base.GrowUp();
        _colPush.ForceUp();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_detectedObject == null && other.TryGetComponent(out IDetectable detectable))
        {
            isDetected = true;
            _detectedObject = detectable;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IDetectable detectable))
        {
            isDetected = false;
            _detectedObject = null;
            SetLocation();
        }
    }

    public override void Eat()
    {
        base.Eat();
        _detectedObject = null;
    }


   

    
    public IEnumerator DelaySetPos()
    {
        yield return new WaitForSeconds(0.1f);
        SetLocation();
    }
}
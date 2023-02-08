using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    [SerializeField] private TMP_Text _scoreText;
    private Camera _mainCamera;

    [SerializeField] private Transform _canvastTransform;


    private void Start()
    {
        _mainCamera = Camera.main;
        _scoreText.text = "0";
        _canvastTransform.GetComponent<Canvas>().worldCamera = _mainCamera;
    }
    private void LateUpdate()
    {
        _canvastTransform.LookAt(transform.position + _mainCamera.transform.forward);
    }


    public void UpdateScore(int score)
    {
        _scoreText.text = score.ToString();
    }


}
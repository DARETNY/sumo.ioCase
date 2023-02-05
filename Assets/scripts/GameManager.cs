using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : Monosingleton<GameManager>
{

    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text _wingame;

    [SerializeField] private TMP_Text _losegame;
    private float _startTime;
    [SerializeField] private Button _button;


    [SerializeField] private float timer = 60;
    private float _currentTime;
    [SerializeField] private int enemyCount;
    private Vector3 _targetScale = new Vector3(1.5f, 1.5f, 1.5f);
    private float _duration = 0.5f;
    private bool _isStop;

    private void Start()
    {
        _button.gameObject.SetActive(false);
        _currentTime = timer;
        timerText.text = timer.ToString("F1");
        _button.onClick.AddListener(ReloadScene);
        _wingame.gameObject.SetActive(false);
        _losegame.gameObject.SetActive(false);

    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;
        timerText.text = _currentTime.ToString("F1");
        if (!_isStop)
        {
            if (_currentTime <= 0f)
            {
                StopGame();
                _isStop = true;

            }
            else
            {
                Time.timeScale = 1;
            }
        }


    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Buttonactive()
    {
        _button.gameObject.SetActive(true);
        _button.transform.DORotate(new Vector3(0f, 0f, 360), _duration, RotateMode.FastBeyond360).SetEase(Ease.Linear)
                .OnComplete(() => _button.transform.DORotate(Vector3.zero, _duration));
    }


    public void WinGame()
    {
        _wingame.rectTransform.DOScale(_targetScale, _duration).SetEase(Ease.OutBounce);
        _wingame.gameObject.SetActive(true);
        _wingame.text = "Player won ";
        StopGame();

    }

    public void LoseGame()
    {

        _losegame.rectTransform.DOScale(_targetScale, _duration).SetEase(Ease.OutBounce);

        _losegame.gameObject.SetActive(true);
        _losegame.text = "Enemies won ";
        StopGame();

    }


    public void Count()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            WinGame();
        }
    }

    private void StopGame()
    {
        Time.timeScale = 0;
        Buttonactive();
    }
}
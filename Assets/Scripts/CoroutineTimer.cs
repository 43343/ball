using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoroutineTimer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject timerTextObject;
    [SerializeField] private GameObject count;
    [SerializeField] private Rigidbody2D ballRigidbody;
    [SerializeField] private Button ballButton;
    [SerializeField] private Animation animBall;
    [SerializeField] private Animation animTimer;

    private float _timeLeft = 0f;
    RectTransform rectTransform;

    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }

    private void Start()
    {
        _timeLeft = time;
        StartCoroutine(StartTimer());
        rectTransform = timerTextObject.GetComponent<RectTransform>();
        timerTextObject.SetActive(true);
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        if (seconds == 0)
        {
            timerText.text = "GO!";
            animTimer.Play("TimerAnimation2");
            animBall.Play("BallAnimation2");
            Invoke("RunGame", 1.0f);
        }
        else
        {
            animTimer.Play("TimerAnimation");
            timerText.text = seconds.ToString();
        }
    }
    private void RunGame()
    {
        animBall.Play("BallAnimation");
        count.SetActive(true);
        ballButton.interactable = true;
        ballRigidbody.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject);
        Destroy(timerTextObject);
    }
}
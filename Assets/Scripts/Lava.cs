using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro;

public class Lava : MonoBehaviour
{

    private float moveSpeed = .35f;
    [SerializeField] private float timePassed;
    public TextMeshProUGUI TimerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        MoveLava();
    }

    public void MoveLava()
    {
        if (timePassed < 60)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        if (timePassed >= 60)
        {
            transform.Translate(Vector2.up * (moveSpeed + 0.15f) * Time.deltaTime);
        }
    }

    public void Timer()
    {
        timePassed += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timePassed / 60);
        int seconds = Mathf.FloorToInt(timePassed % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

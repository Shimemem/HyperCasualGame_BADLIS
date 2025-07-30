using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro;

public class Lava : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 0.5f;
    public float timePassed;
    public TextMeshProUGUI TimerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timePassed / 60);
        int seconds = Mathf.FloorToInt(timePassed % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        MoveLava();
    }

    public void MoveLava()
    {
        if (timePassed < 30)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        
        if (timePassed >=30)
        {
            transform.Translate(Vector2.up * (moveSpeed + 0.1f) * Time.deltaTime);
        }
    }
}

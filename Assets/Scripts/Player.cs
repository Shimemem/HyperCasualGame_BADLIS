using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float Magnitude, playerSpeed;
    [SerializeField] private int Score;
    public TextMeshProUGUI ScoreText;
    public GameObject LavaPos;
    [SerializeField] private float playerCollision = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Death();
    }

    public void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += Vector3.up;
            Score += 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += Vector3.down;
            Score -= 1;
        }
        ScoreText.text = Score.ToString();
    }

    public void Death()
    {
        Vector2 distance = transform.position - LavaPos.transform.position;
        float magnitude = distance.magnitude;

        if (magnitude <= playerCollision)
        {
            Debug.Log("Dead!!!!");
        }
    }
}

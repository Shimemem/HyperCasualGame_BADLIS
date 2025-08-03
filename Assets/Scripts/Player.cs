using System.Collections;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    public GameObject LavaPos, player;
    [SerializeField] private float playerCollision = 1f;
    private bool isDead = false;
    Maths maths;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maths = FindObjectOfType<Maths>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 distance;
        float magnitude;
        distance = transform.position - LavaPos.transform.position;
        magnitude = distance.magnitude;

        if (magnitude <= playerCollision)
        {
            Death();
        }
    }

    //public void MovePlayer()
    //{
    //    if (Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        transform.position += Vector3.up;
    //        Score += 1;
    //    }
    //    if (Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        transform.position += Vector3.down;
    //        Score -= 1;
    //    }
    //    ScoreText.text = Score.ToString();
    //}
    public void Death()
    {
        if (isDead) return;
        isDead = true;
        Debug.Log("Dead!!!!");
        StartCoroutine(DeathScreen());
    }

    IEnumerator DeathScreen()
    {
        if (maths != null)
        {
            maths.answerInput.interactable = false;
            maths.question.text = "YOU DIED!!!";
            maths.answerInput.DeactivateInputField();
        }

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

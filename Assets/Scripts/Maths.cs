using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class Maths : MonoBehaviour
{
    public TextMeshProUGUI question, ScoreText;
    public TMP_InputField answerInput;
    public GameObject playerPos;
    public Player player;
    private int Score;

    private int correctAnswer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateQuestions();
        

        answerInput.onSubmit.AddListener(AnswerSubmit);
        answerInput.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnswerSubmit(string answerInput)
    {
        CheckAnswer();
    }

    public void GenerateQuestions()
    {
        if (Score > 30)
        {
            GenerateHarderQuestion();
        }
        else
        {
            GenerateEasyQuestion();
        }
        
    }

    public void GenerateEasyQuestion()
    {
        int a,b;
        int op = Random.Range(0,2);

        switch (op)
        {
            case 0: //Addition
                a = Random.Range(0,10);
                b = Random.Range(0,10);
                correctAnswer = a + b;
                question.text = $"{a} + {b}?";
                break;

            case 1: //Subtraction
                a = Random.Range(0, 20);
                b = Random.Range(0, a + 1);
                correctAnswer = a - b;
                question.text = $"{a} - {b}?";
                break;
        }
    }
    public void GenerateHarderQuestion()
    {
        int a,b;
        int op = Random.Range(0,4);

        switch (op)
        {
            case 0: //Addition
                a = Random.Range(0,20);
                b = Random.Range(0,20);
                correctAnswer = a + b;
                question.text = $"{a} + {b}?";
                break;

            case 1: //Subtraction
                a = Random.Range(0, 20);
                b = Random.Range(0, a + 1);
                correctAnswer = a - b;
                question.text = $"{a} - {b}?";
                break;

            case 2: //Multiplication
                a = Random.Range(1, 10);
                b = Random.Range(1, 10);
                correctAnswer = a * b;
                question.text = $"{a} x {b}?";
                break;

            case 3: //Division
                b = Random.Range(1, 10);
                correctAnswer = Random.Range(1, 10);
                a = correctAnswer * b;
                question.text = $"{a} ÷ {b}?";
                break;
        }
    }

    public void CheckAnswer()
    {
        if (int.TryParse(answerInput.text, out int playerAnswer))
        {
            if (playerAnswer == correctAnswer)
            {
                playerPos.transform.position += new Vector3(0, 1, 0);
                Score += 1;
                GenerateQuestions();
            }
            else
            {
                question.text = "Wrong Answer!";
                StartCoroutine(WrongAnswerDelay());
            }
        }

        answerInput.text = "";
        answerInput.ActivateInputField();
        ScoreText.text = Score.ToString();
    }

    IEnumerator WrongAnswerDelay()
    {
        answerInput.interactable = false;
        answerInput.text = "Wrong!";
        yield return new WaitForSeconds(1f);

        answerInput.text = "";
        answerInput.interactable = true;
        answerInput.ActivateInputField();
        GenerateQuestions();
    }
}

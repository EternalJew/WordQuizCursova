using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;

    [SerializeField] private QuestionData question;
    [SerializeField] private WordData[] answerWordArray;
    [SerializeField] private WordData[] optionsWordArray;

    private char[] charArray = new char[12];
    private int currentAnswerIndex = 0; 

    private void Awake()
    {
        if (instance == null) instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        SetQuestion();
    }

    private void SetQuestion()
    {
        currentAnswerIndex = 0;

        ResetQuestion();

        for (int i = 0; i < question.answer.Length; i++)
        {
            charArray[i] = char.ToUpper(question.answer[i]);
        }

        for(int i = question.answer.Length; i < optionsWordArray.Length; i++)
        {
            charArray[i] = (char)UnityEngine.Random.Range(65, 91);
        }
        charArray = ShuffleList.ShuffleListItems<char>(charArray.ToList()).ToArray();

        for(int i = 0; i < optionsWordArray.Length; i++)
        {
            optionsWordArray[i].SetChar(charArray[i]);
        }
    }
    public void SelectedOption(WordData wordData)
    {
        if (currentAnswerIndex >= answerWordArray.Length) return;
        answerWordArray[currentAnswerIndex].SetChar(wordData.charValue);
        wordData.gameObject.SetActive(false);
        currentAnswerIndex++;
    }
    private void ResetQuestion()
    {
        for(int i = 0; i < answerWordArray.Length; i++)
        {
            answerWordArray[i].gameObject.SetActive(true);
            answerWordArray[i].SetChar('_');
        }
        for (int i = question.answer.Length; i < answerWordArray.Length; i++)
        {
            answerWordArray[i].gameObject.SetActive(false);
        }
    }
}

[System.Serializable]
public class QuestionData
{
    public Sprite questionImage;
    public string answer;
}

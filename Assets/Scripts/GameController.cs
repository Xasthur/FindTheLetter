/*
 TODO
!make sure that the target letter is appearign in the list of letter
 */

using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameController: MonoBehaviour 
{
    [SerializeField] List<AudioClip> _audioClips;
    public char TheLetter;

    public int _correctClicks = 0;

    public static GameController Instance { get; private set; }

    AudioSource _audioSource;

    private void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {        
        GeneratePanel();
    }

    private void GeneratePanel()
    {
        //randomly selecting the target letter and display it in the task placeholder
        TheLetter = TargetLetter();
        Debug.Log("amount of correct clicks" + _correctClicks);

        var letters = FindObjectsOfType<ClickableLetters>();
        List<char> lettersList = new List<char>();

        //there can be only one correct letter
        for (int i = 0; i < 1; i++)
        {
            lettersList.Add(TheLetter);
            
        }
        
        for (int i = 1; i < letters.Length; i++)
        {
            var chosenLetter = ChooseInvalidRandLetter();
            lettersList.Add(chosenLetter);
        }
        //reshufling the list
        lettersList = lettersList.OrderBy(t => UnityEngine.Random.Range(0, 10000)).ToList();
        for (int i = 0; i < letters.Length; i++)
        {
            letters[i].SetLetter(lettersList[i]);
        }
    }

    internal void CorrectLetterClick()
    {
        var clip = _audioClips.FirstOrDefault(t => t.name == "ButtonPress");
        _audioSource.PlayOneShot(clip);
        GeneratePanel();
        _correctClicks++;
        FindObjectOfType<scoreDisplay>().updateScore(_correctClicks);
    }

    private char ChooseInvalidRandLetter()
    {
        int a = UnityEngine.Random.Range(0, 26);
        var randLetter = (char)('A' + a);

        while (randLetter == TheLetter)
        {
            a = UnityEngine.Random.Range(0, 26);
            randLetter = (char)('A' + a);
        }
        return randLetter;
    }

    private char TargetLetter()
    {
        int upperRange = 26;
        int randTarget = UnityEngine.Random.Range(0, upperRange);
        char _theLetter = (char)('A' + randTarget); //A == 65;
        GetComponent<TMP_Text>().text = $"Find {_theLetter}";
        Debug.Log("This is the target2" + _theLetter.ToString());
        return _theLetter;
    }
}

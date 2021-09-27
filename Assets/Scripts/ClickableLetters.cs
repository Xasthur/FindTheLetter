/*
 Tasks
Make the random populator for the letters -> Rand
The tap on the letters should register
Add effects for the wrong/right letter
 */

using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableLetters : MonoBehaviour, IPointerClickHandler
{
    char _randLetter;


    IEnumerator waiter()
    {
        //maybe do the effect, but for now change the color to green
        GetComponent<TMP_Text>().color = Color.green;
        yield return new WaitForSeconds(0.25f);
        GameController.Instance.CorrectLetterClick();
    }

    // cant figure out why OnPointerClick didnt work, using this for now.
    //nvm it does work now :D
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked on the Letter: " + _randLetter);
        if (_randLetter == GameController.Instance.TheLetter)
        {
            
            StartCoroutine(waiter());

            
        }
        else
        {
            GetComponent<TMP_Text>().color = Color.red;
        }
    }

    public void SetLetter (char letter)
    {
        //reset the effect 
        _randLetter = letter;
        GetComponent<TMP_Text>().color = Color.white;
        GetComponent<TMP_Text>().text = _randLetter.ToString();
    }
}

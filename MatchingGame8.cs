using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MatchingGame8 : MonoBehaviour
{
    public Button[] pair1Buttons; // First pair of buttons
    public Button[] pair2Buttons; // Second pair of buttons
    public Button[] pair3Buttons; // Third pair of buttons
    public Button[] pair4Buttons; // Fourth pair of buttons
    public Button[] pair5Buttons; // Fifth pair of buttons
    public Button[] pair6Buttons; // Sixth pair of buttons
    public Button[] pair7Buttons; // Seventh pair of buttons
    public Button[] pair8Buttons; // Eighth pair of buttons

    public GameObject[] feedbackObjects; // Array of feedback objects to display after each pair is found
    public GameObject winObject; // Reference to the win object to enable after all pairs are found

    private Button lastClickedButton; // Keep track of the last clicked button
    private int pairsFound = 0; // Keep track of the number of matching pairs found

    void Start()
    {
        AttachEventListeners(pair1Buttons);
        AttachEventListeners(pair2Buttons);
        AttachEventListeners(pair3Buttons);
        AttachEventListeners(pair4Buttons);
        AttachEventListeners(pair5Buttons);
        AttachEventListeners(pair6Buttons);
        AttachEventListeners(pair7Buttons);
        AttachEventListeners(pair8Buttons);
    }

    void AttachEventListeners(Button[] buttons)
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    void OnButtonClick(Button clickedButton)
    {
        if (lastClickedButton == clickedButton)
        {
            // Ignore the double tap
            return;
        }

        if (lastClickedButton == null)
        {
            lastClickedButton = clickedButton;
        }
        else
        {
            if (AreMatchingPairs(lastClickedButton, clickedButton))
            {
                Debug.Log("Matching pair found!");
                pairsFound++;
                DisableButtons(lastClickedButton, clickedButton); // Disable buttons once a pair is found

                if (pairsFound == 8)
                {
                    Debug.Log("All pairs found!");
                    ActivateFeedbackObjects();
                    // Enable the win object
                    if (winObject != null)
                    {
                        winObject.SetActive(true);
                    }
                }
                else
                {
                    feedbackObjects[pairsFound - 1].SetActive(true);
                }
            }
            else
            {
                Debug.Log("Not a matching pair!");
            }
            lastClickedButton = null;
        }
    }

    bool AreMatchingPairs(Button button1, Button button2)
    {
        return ArrayContainsButton(pair1Buttons, button1) && ArrayContainsButton(pair1Buttons, button2) ||
               ArrayContainsButton(pair2Buttons, button1) && ArrayContainsButton(pair2Buttons, button2) ||
               ArrayContainsButton(pair3Buttons, button1) && ArrayContainsButton(pair3Buttons, button2) ||
               ArrayContainsButton(pair4Buttons, button1) && ArrayContainsButton(pair4Buttons, button2) ||
               ArrayContainsButton(pair5Buttons, button1) && ArrayContainsButton(pair5Buttons, button2) ||
               ArrayContainsButton(pair6Buttons, button1) && ArrayContainsButton(pair6Buttons, button2) ||
               ArrayContainsButton(pair7Buttons, button1) && ArrayContainsButton(pair7Buttons, button2) ||
               ArrayContainsButton(pair8Buttons, button1) && ArrayContainsButton(pair8Buttons, button2);
    }

    bool ArrayContainsButton(Button[] buttons, Button button)
    {
        return System.Array.Exists(buttons, b => b == button);
    }

    void DisableButtons(Button button1, Button button2)
    {
        button1.interactable = false;
        button2.interactable = false;
    }

    void ActivateFeedbackObjects()
    {
        foreach (GameObject feedbackObject in feedbackObjects)
        {
            feedbackObject.SetActive(true);
        }
    }
}



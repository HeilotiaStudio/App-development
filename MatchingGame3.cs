using UnityEngine;
using UnityEngine.UI;

public class MatchingGame3 : MonoBehaviour
{
    public Button[] buttons; // Array of buttons
    public GameObject[] feedbackObjects; // Array of feedback objects to display after each button click
    public GameObject winObject; // Game object to enable after all buttons are clicked

    private int buttonsClicked = 0; // Keep track of the number of buttons clicked

    void Start()
    {
        // Attach event listeners to all buttons
        AttachEventListeners(buttons);
    }

    void AttachEventListeners(Button[] buttons)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Capture the current index in the loop
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    void OnButtonClick(int buttonIndex)
{
    // Check if the button is already clicked
    if (buttons[buttonIndex].interactable == false)
    {
        // Ignore the click if the button is already clicked
        return;
    }

    buttonsClicked++;

    // Disable the button to prevent double-clicking
    buttons[buttonIndex].interactable = false;

    // Check if all buttons have been clicked
    if (buttonsClicked == buttons.Length)
    {
        Debug.Log("All buttons clicked!");

        // Enable the winObject
        if (winObject != null)
        {
            winObject.SetActive(true);
        }
    }

    // Check if the button index is valid
    if (buttonIndex >= 0 && buttonIndex < feedbackObjects.Length)
    {
        // Activate the corresponding feedback object
        feedbackObjects[buttonIndex].SetActive(true);
    }
}
}

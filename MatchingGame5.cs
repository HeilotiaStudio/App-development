using UnityEngine;
using UnityEngine.UI;

public class MatchingGame5 : MonoBehaviour
{
    // Arrays of buttons for each pair
    public Button[] pair1Buttons;
    public Button[] pair2Buttons;
    public Button[] pair3Buttons;
    public Button[] pair4Buttons;
    public Button[] pair5Buttons;

    // Feedback objects corresponding to each pair
    public GameObject pair1FeedbackObject;
    public GameObject pair2FeedbackObject;
    public GameObject pair3FeedbackObject;
    public GameObject pair4FeedbackObject;
    public GameObject pair5FeedbackObject;

    public GameObject winObject; // Reference to the win object to enable after all pairs are found

    private int pairsFound = 0; // Keep track of the number of matching pairs found

    void Start()
    {
        // Attach event listeners to all buttons in each pair
        AttachEventListeners(pair1Buttons, pair1FeedbackObject);
        AttachEventListeners(pair2Buttons, pair2FeedbackObject);
        AttachEventListeners(pair3Buttons, pair3FeedbackObject);
        AttachEventListeners(pair4Buttons, pair4FeedbackObject);
        AttachEventListeners(pair5Buttons, pair5FeedbackObject);
    }

    void AttachEventListeners(Button[] buttons, GameObject feedbackObject)
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button, buttons, feedbackObject));
        }
    }

    void OnButtonClick(Button clickedButton, Button[] buttons, GameObject feedbackObject)
    {
        if (pairsFound == 5) return; // All pairs already found

        clickedButton.interactable = false; // Disable the button to prevent further clicks

        if (AreMatchingPairs(buttons))
        {
            Debug.Log("Matching pair found!");
            pairsFound++;
            if (pairsFound == 5)
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
                feedbackObject.SetActive(true); // Activate the corresponding feedback object
            }
        }
        else
        {
            Debug.Log("Not a matching pair!");
        }
    }

    bool AreMatchingPairs(Button[] buttons)
    {
        // Check if all buttons in the array are interactable (i.e., they have not been matched yet)
        foreach (Button button in buttons)
        {
            if (button.interactable)
            {
                return false; // If any button is still interactable, it means the pair is not complete
            }
        }
        return true; // All buttons in the array are disabled, indicating a matching pair
    }

    void ActivateFeedbackObjects()
    {
        // No need to activate feedback objects individually since we're using only one for each pair
        pair1FeedbackObject.SetActive(true);
        pair2FeedbackObject.SetActive(true);
        pair3FeedbackObject.SetActive(true);
        pair4FeedbackObject.SetActive(true);
        pair5FeedbackObject.SetActive(true);
    }
}

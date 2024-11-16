using UnityEngine;
using UnityEngine.UI;

public class EnableGameObjectOnButtonDisable : MonoBehaviour
{
    public GameObject targetGameObject; // Game object to enable when the button becomes uninteractable

    void Update()
    {
        // Check if the button attached to this game object is uninteractable
        if (!GetComponent<Button>().interactable && !targetGameObject.activeSelf)
        {
            // Enable the target game object if it's not already active
            targetGameObject.SetActive(true);
        }
    }
}

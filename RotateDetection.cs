using UnityEngine;
using UnityEngine.UI;

public class RotateDetection : MonoBehaviour
{
    public RectTransform panel1; // Portrait panel
    public RectTransform panel2; // Landscape panel

    private ScreenOrientation currentOrientation;

    void Start()
    {
        // Initial check for screen orientation
        currentOrientation = Screen.orientation;
        OnPanelOrientationChange();
    }

    void Update()
    {
        // Check for changes in screen orientation
        if (currentOrientation != Screen.orientation)
        {
            currentOrientation = Screen.orientation;
            OnPanelOrientationChange();
        }
    }

    void OnPanelOrientationChange()
    {
        // Check if the screen orientation is landscape
        bool isLandscape = currentOrientation == ScreenOrientation.LandscapeLeft || currentOrientation == ScreenOrientation.LandscapeRight;

        // Set the active panel based on the screen orientation
        panel1.gameObject.SetActive(!isLandscape);
        panel2.gameObject.SetActive(isLandscape);
    }
}
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    public float pauseTime = 5.0f; // Time in seconds to pause the video
    public Button buttonToEnable1; // Reference to the first button to enable when video is paused
    public Button buttonToEnable2; // Reference to the second button to enable when video is paused
    public Button buttonToUnpause; // Reference to the button to unpause the video

    private float elapsedTime = 0.0f; // Elapsed time since video started

    void Update()
    {
        // Check if the video is playing and if it's time to pause
        elapsedTime += Time.deltaTime;
        if (videoPlayer.isPlaying && elapsedTime >= pauseTime)
        {
            // Pause the video
            videoPlayer.Pause();

            // Enable the buttons
            if (buttonToEnable1 != null)
            {
                buttonToEnable1.interactable = true;
            }

            if (buttonToEnable2 != null)
            {
                buttonToEnable2.interactable = true;
            }

            if (buttonToUnpause != null)
            {
                buttonToUnpause.interactable = true;
            }
        }
    }

    public void ResumeVideo()
    {
        // Resume the video
        videoPlayer.Play();
        elapsedTime = 0.0f; // Reset elapsed time

        // Disable the buttons
        if (buttonToEnable1 != null)
        {
            buttonToEnable1.interactable = false;
        }

        if (buttonToEnable2 != null)
        {
            buttonToEnable2.interactable = false;
        }

        if (buttonToUnpause != null)
        {
            buttonToUnpause.interactable = false;
        }
    }
}







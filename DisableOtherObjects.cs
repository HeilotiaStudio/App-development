using UnityEngine;

public class DisableOtherObjects : MonoBehaviour
{
    public GameObject[] objectsToDisable; // Array of objects to disable except the one this script is attached to

    void Start()
    {
        if (objectsToDisable != null)
        {
            foreach (GameObject obj in objectsToDisable)
            {
                if (obj != gameObject && obj != null)
                {
                    obj.SetActive(false);
                }
            }
        }
    }
}

using UnityEngine;

public class AutoDeactivate : MonoBehaviour
{
    private void OnEnable()
    {
        // Using lambda expression to directly set the current game object to inactive after 1.5 seconds
        Invoke("DeactivateObject", 1.5f);
    }

    private void DeactivateObject()
    {
        // Set the current game object to inactive
        gameObject.SetActive(false);
    }
}

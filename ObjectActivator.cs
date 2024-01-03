using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public void ActivateAnObject(GameObject objectToActivate)
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
        else
        {
            Debug.LogWarning("ObjectToActivate is null. Cannot activate null object.");
        }
    }
}

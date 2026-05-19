using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class M_GameManager : MonoBehaviour
{

    private void Update()
    {

    }

    
    public void SetActiveObject(GameObject obj)
    {
        if (obj == null)
        {
            Debug.LogWarning("Object not assigned!");
            return;
        }
        if (obj.activeSelf)
        {
            obj.SetActive(false);
            return;
        }
        obj.SetActive(true);
    }



}

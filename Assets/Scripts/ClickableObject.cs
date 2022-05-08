using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    GameObject GameManager;
    ObjectManager objectManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        if(GameManager == null)
        {
            Debug.LogError("GameManager game object is null in ClickableObject");
        } else
        {
            objectManager = GameManager.GetComponent<ObjectManager>();
            if(objectManager == null)
            {
                Debug.LogError("objectManager script is null in ClickableObject");
            }
        }
    }

    void OnMouseDown()
    {
        bool DoObjectsMatch = objectManager.CompareWithHiddenObject(this.gameObject);
        if(DoObjectsMatch)
        {
            Destroy(this.gameObject);
            //hiddenObjectManager.HandleChooseHiddenObject();
        }
        else
        {
            Debug.Log("No match");
        }
    }

    private void OnDestroy()
    {
        objectManager.HandleChooseHiddenObject();
    }
}

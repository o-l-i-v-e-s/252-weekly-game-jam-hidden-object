using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    UIManager uiManager;
    private GameObject HiddenObject;

    private void Awake()
    {
        uiManager = gameObject.GetComponent<UIManager>();
        if (uiManager == null)
        {
            Debug.LogError("uiManager is null in ObjectManager");
        }
    }

    void Start()
    {
        HandleChooseHiddenObject();
        Debug.Log(HiddenObject.name);
    }

    GameObject ChooseHiddenObject()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Object");
        if ((gameObjects != null) && (gameObjects.Length > 0))
        {
            Debug.Log(gameObjects.Length + " game objects found");
            return gameObjects[Random.Range(0, gameObjects.Length - 1)];
        }
        else
        {
            return null;
        }
    }

    private void UpdateSpriteActiveObject(string objectName)
    {
        uiManager.UpdateSpriteActiveObject(objectName);
    }

    public void HandleChooseHiddenObject()
    {
        HiddenObject = ChooseHiddenObject();
        if (HiddenObject == null)
        {
            UpdateSpriteActiveObject("None");
        }
        else
        {
            UpdateSpriteActiveObject(HiddenObject.name);
        }
    }

    public bool CompareWithHiddenObject(GameObject selectedObject)
    {
        bool DoObjectsMatch = GameObject.ReferenceEquals(HiddenObject, selectedObject);
        return DoObjectsMatch;
    }

}

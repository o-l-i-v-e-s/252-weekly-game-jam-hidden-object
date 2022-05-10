using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    Menus menus;
    UIManager uiManager;
    private GameObject HiddenObject;

    private void Awake()
    {
        uiManager = gameObject.GetComponent<UIManager>();
        if (uiManager == null)
        {
            Debug.LogError("uiManager is null in ObjectManager");
        }
        menus = gameObject.GetComponent<Menus>();
        if (menus == null)
        {
            Debug.LogError("menus is null in ObjectManager");
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
            menus.ShowWinMenu();
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

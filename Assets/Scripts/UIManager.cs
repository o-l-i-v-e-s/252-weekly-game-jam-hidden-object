using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameObject canvas;
    Image ActiveObjectImage;
    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas");
        if (canvas == null)
        {
            Debug.LogError("Canvas is null in UIManager");
        }
        else
        {
            Debug.Log("Canvas found");
        }
        ActiveObjectImage = canvas.transform.Find("ActiveObjectImage").GetComponent<Image>();
        if (ActiveObjectImage == null)
        {
            Debug.Log("ActiveObjectImage is null in UIManager");
        }
    }
    public void UpdateSpriteActiveObject(string objectName)
    {
        Debug.Log(objectName);
        if (objectName != null)
        {
            string pathName = "Sprites/" + objectName;
            Debug.Log(pathName);
            Sprite sprite = Resources.Load<Sprite>(pathName);
            Debug.Log(sprite);
            Debug.Log(ActiveObjectImage);
            ActiveObjectImage.sprite = sprite;
        }
    }
}

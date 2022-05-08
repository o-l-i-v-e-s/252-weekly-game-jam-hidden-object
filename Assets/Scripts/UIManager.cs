using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameObject canvas;
    Image ActiveObjectImage;
    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas");
        if (canvas == null)
        {
            Debug.LogError("Canvas is null in UIManager");
        }
        ActiveObjectImage = canvas.transform.Find("ActiveObjectImage").GetComponent<Image>();
        if (ActiveObjectImage == null)
        {
            Debug.Log("ActiveObjectImage is null in UIManager");
        }
    }
    public void UpdateSpriteActiveObject(string objectName)
    {
        if (objectName != null)
        {
            string pathName = "Sprites/" + objectName;
            ActiveObjectImage.sprite = Resources.Load<Sprite>(pathName);
        }
    }
}

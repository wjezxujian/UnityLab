using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Script_03_08
{
    [MenuItem("GameObject/UI/Image")]
    static void creatImage()
    {
        if(Selection.activeTransform)
        {
            if(!Selection.activeTransform.GetComponentInParent<Canvas>())
            {
                Canvas canvas = new GameObject("Canvas").AddComponent<Canvas>();
                //canvas.AddComponent<RectTransform>();
                //canvas.AddComponent<CanvasScaler>();
                //canvas.AddComponent<GraphicRaycaster>();
                canvas.transform.SetParent(null, false);
            }

            Image image = new GameObject("Image").AddComponent<Image>();

            image.raycastTarget = false;
            image.transform.SetParent(Selection.activeTransform, false);
            //设置选中状态
            Selection.activeTransform = image.transform;
        }
    }
}

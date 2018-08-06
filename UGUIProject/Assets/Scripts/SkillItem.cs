using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillItem : MonoBehaviour {
    public float coldTime = 2f;
    public KeyCode keyCode;

    private float timer = 0;
    private bool isStartTimer = false;

    private Image filledImage;
	// Use this for initialization
	void Start () {
        filledImage = transform.Find("FillRect").GetComponent<Image>();
        filledImage.fillAmount = 0f;
    }
	
	// Update is called once per frame
	void Update () {
		if(isStartTimer)
        {
            timer += Time.deltaTime;

            if (timer >= coldTime)
            {
                filledImage.fillAmount = 0f;
                isStartTimer = false;
                timer = 0;
            }
            else
            {
                filledImage.fillAmount = 1.0f - timer / coldTime;
            }
        }

        if(Input.GetKeyDown(keyCode))
        {
            OnClick();
        }
	}

    public void OnClick()
    {
        if(!isStartTimer)
        {
            isStartTimer = true;
            filledImage.fillAmount = 1.0f;
            //TODO Something
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarToogle : MonoBehaviour
{
 

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnValueChanged(bool isOn)
    {
        if(isOn)
        {
            if (gameObject.name == "boy" || gameObject.name == "girl")
            {
                AvatarSys._instance.SexChange();
                return;
            }

            string[] names = gameObject.name.Split('-');
            Debug.Log("name0:" + names[0] + ",name1:" + names[1]);
            AvatarSys._instance.OnChangePeople(names[0], names[1]);

            string animName;
            switch(names[0])
            {
                case "pants":
                    PlayAnimation("item_pants");
                    break;
                case "shoes":
                    PlayAnimation("item_boots");
                    break;
                case "top":
                    PlayAnimation("item_shirt");
                    break;
                default:
                    break;
            }
        }
    }

    //换装动画名称
    public void PlayAnimation(string animName)
    {
        Animation anim = GameObject.FindWithTag("Player").GetComponent<Animation>();
        if (!anim.IsPlaying(animName))
        {
            anim.Play(animName);
            anim.PlayQueued("idle1");
        }

    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
        //Application.LoadLevel("");
    }
}

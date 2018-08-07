using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    /// <summary>
    /// 单例模式的核心要点
    /// 1.定义一个静态的对象
    /// 2.构造方法是私有化
    /// </summary>
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
    }

    //存储所有的画布
    private Transform canvasTransfrom;
    private Transform CanvasTransform
    {
        get
        {
            if(canvasTransfrom == null)
            {
                canvasTransfrom = GameObject.Find("Canvas").transform;
            }
            return canvasTransfrom;
        }
    }
    //存储所有面板Prefab的路径
    private Dictionary<UIPanelType, string> panelPathDict;
    //保存所有面板的游戏物体身上的BasePanel
    private Dictionary<UIPanelType, BasePanel> panelDict;
    private Stack<BasePanel> panelStack;

    private UIManager()
    {
        ParseUIPanelTypeJson();
    }

    /// <summary>
    /// 把某个页面入栈，把某个界面显示在界面上
    /// </summary>
    public void PushPanel(UIPanelType panelType)
    {
        if(panelStack == null)
        {
            panelStack = new Stack<BasePanel>();
        }
        BasePanel panel = GetPanel(panelType);

        if(panelStack.Count > 0)
        {
            BasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }

        panel.OnEnter();
        panelStack.Push(panel);
    }

    /// <summary>
    /// 出栈，把某个界面移除
    /// </summary>
    public void PopPanel()
    {
        if(panelStack != null && panelStack.Count > 0)
        {
            BasePanel  panel = panelStack.Pop();
            panel.OnExit();

            if(panelStack.Count >0)
            {
                panelStack.Peek().OnResume();
            }
        }
    }

    private BasePanel GetPanel(UIPanelType panelType)
    {
        if(panelDict == null)
        {
            panelDict = new Dictionary<UIPanelType, BasePanel>();
        }

        //BasePanel panel;
        //panelDict.TryGetValue(panelType, out panel);

        BasePanel panel = panelDict.TryGet(panelType);

        if(panel == null)
        {
            //如果找不到，那么就找这个面板的Prefab路径
            //string path;
            //panelPathDict.TryGetValue(panelType, out path);
            string path = panelPathDict.TryGet(panelType);
            GameObject _instancePanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            _instancePanel.transform.SetParent(CanvasTransform, false);
            panelDict.Add(panelType, _instancePanel.GetComponent<BasePanel>());
            panel =  _instancePanel.GetComponent<BasePanel>();
        }

        return panel;
    }
    
    [SerializeField]
    class UIPanelTypeJson
    {
        public List<UIPanelInfo> infoList;
    }

    private void ParseUIPanelTypeJson()
    {
        panelPathDict = new Dictionary<UIPanelType, string>();

        TextAsset ta = Resources.Load<TextAsset>("UIPanelType");

        UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);

        foreach (UIPanelInfo info in jsonObject.infoList)
        {
            panelPathDict.Add(info.panelType, info.path);
        }
    }

    public void Test()
    {
        string path;
        panelPathDict.TryGetValue(UIPanelType.Knapsack, out path);
        Debug.Log(path);
    }
}

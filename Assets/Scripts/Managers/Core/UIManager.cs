using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class UIManager
{
    public GameObject UI_LobbyScene { get; set; }

    public GameObject UI_Minimap { get; set; }
    public GameObject UI_Worldmap { get; set; }

    public GameObject UI_ShopDialog { get; set; }
    public GameObject UI_Shop { get; set; }
    public GameObject UI_Inventory { get; set; }

    public GameObject UI_GameScene { get; set; }
    public GameObject UI_Inven { get; set; }
    public GameObject UI_Skill { get; set; }
    public GameObject UI_Timer { get; set; }

    public GameObject DragItem { get; set; }
    public GameObject DragSkill { get; set; }

    public GameObject UI_ItemInfo { get; set; }
    public GameObject UI_SkillInfo { get; set; }

    int _order = 10;

    // 팝업 UI 기능을 구현하기 위해 스택 생성
    Stack<UI_PopupBase> _popupStack = new Stack<UI_PopupBase>();
    UI_SceneBase _sceneUI = null;

    public GameObject UI_Root
    {
        get
        {
            GameObject ui_root = GameObject.Find("@UI_Root");
            if (ui_root == null)
                ui_root = new GameObject { name = "@UI_Root" };

            return ui_root;
        }
    }
        
    public GameObject UI_PopupRoot
    {
        get
        {
            GameObject popupRoot = GameObject.Find("@Popup_Root");
            if (popupRoot == null)
            {
                popupRoot = new GameObject { name = "@Popup_Root" };
                popupRoot.transform.SetParent(UI_Root.transform);
            }

            return popupRoot;
        }
    }

    public GameObject UI_SceneRoot
    {
        get
        {
            GameObject sceneRoot = GameObject.Find("@Scene_Root");
            if (sceneRoot == null)
            {
                sceneRoot = new GameObject { name = "@Scene_Root" };
                sceneRoot.transform.SetParent(UI_Root.transform);
            }

            return sceneRoot;
        }
    }

    // 캔버스의 Sorting Order를 설정해주는 함수
    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        
        // 부모 캔버스와 독립적인 order를 갖겠다.
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order+=1;
        }

        // UI_PopupBase 가 아닌 경우
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T MakeWorldSpaceUI<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"Prefabs/UI/WorldSpaceUI/{name}");
        if (parent != null)
            go.transform.SetParent(parent);

        Canvas canvas = go.GetOrAddComponent<Canvas>();
        if (!typeof(T).Name.Contains("HUD"))
        {
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.worldCamera = Camera.main;
        }

        return Util.GetOrAddComponent<T>(go);
    }

    public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"Prefabs/UI/SubItem/{name}");
        if (parent != null)
            go.transform.SetParent(parent);

        return Util.GetOrAddComponent<T>(go);
    }

    // 스택에 넣고 팝업 UI 생성하는 함수
    public T OpenPopupUI<T>(string name = null) where T : UI_PopupBase
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        // 프리팹 생성하고,
        GameObject go = Managers.Resource.Instantiate($"Prefabs/UI/Popup/{name}");
        // 프리팹에 알맞는 기능(함수) 추가해주기
        Util.GetOrAddComponent<T>(go);

        T popupUI = go.GetComponent<T>();
        _popupStack.Push(popupUI);

        go.transform.SetParent(UI_PopupRoot.transform);

        return popupUI;
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        UI_PopupBase popupUI = _popupStack.Pop();
        Managers.Resource.Destroy(popupUI.gameObject);
        popupUI = null;

        _order -= 1;
    }

    // 더 안전한 ClosePopupUI() 함수
    public void ClosePopupUI(UI_PopupBase popupUI)
    {
        if (_popupStack.Count == 0)
            return;

        if (_popupStack.Peek() != popupUI)
        {
            Debug.Log("Close PopupUI Failed!");
            return;
        }

        ClosePopupUI();
    }

    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }

    // 스택에 넣고 팝업 UI 생성하는 함수
    public T OpenSceneUI<T>(string name = null) where T : UI_SceneBase
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        // 프리팹 생성하고
        GameObject go = Managers.Resource.Instantiate($"Prefabs/UI/Scene/{name}");
        // 프리팹에 알맞은 기능 추가해주기
        T sceneUI = Util.GetOrAddComponent<T>(go);
        _sceneUI = sceneUI;

        go.transform.SetParent(UI_SceneRoot.transform);

        return sceneUI;
    }

    public void Clear()
    {
        CloseAllPopupUI();
        _sceneUI = null;
    }
}

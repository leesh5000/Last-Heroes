using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Managers 는 싱글톤으로 구현
public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance {  get { Init();  return s_instance; } }

    #region Contents
    GameManager _game = new GameManager();
    public static GameManager Game { get { return Instance._game; } }
    #endregion

    #region Core
    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    UI_Manager _ui = new UI_Manager();
    SceneManagerEx _scene = new SceneManagerEx();
    SoundManager _sound = new SoundManager();
    PoolManager _pool = new PoolManager();
    DataManager _data = new DataManager();

    public static InputManager Input {  get { return Instance._input; } }
    public static ResourceManager Resource {  get { return Instance._resource; } }
    public static UI_Manager UI { get { return Instance._ui; } }
    public static SceneManagerEx Scene {  get { return Instance._scene; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static DataManager Data { get { return Instance._data; } }
    #endregion

    void Start()
    {
        Init();
    }

    void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");

            if ( go == null)
            {
                go = new GameObject() { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();

            s_instance._data.Init();
            s_instance._pool.Init();
            s_instance._sound.Init();
        }
    }

    // Scene이 이동할때 클리어하는 함수
    public static void Clear()
    {
        Sound.Clear();
        Input.Clear();
        Scene.Clear();
        UI.Clear();

        Pool.Clear();
    }
}

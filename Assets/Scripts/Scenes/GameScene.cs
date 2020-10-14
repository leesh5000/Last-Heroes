using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        // 스텟데이터 가져오기
        //Dictionary<string, ContentsData.ChracterStat> chracterStatDict = Managers.Data.ChracterStatDict;
        //Dictionary<string, ContentsData.WaveMonsterStat> waveMonsterStatDict = Managers.Data.WaveMonsterStatDict;

        // GameScene UI 생성
        if (Managers.Game.Ui_GameScene == null)
            Managers.Game.Ui_GameScene = Managers.UI.OpenSceneUI<UI_GameScene>().gameObject;

        // 캐릭터 생성
        if (Managers.Game.Statue == null)
            Managers.Game.Statue = GameObject.Find("Statue");
        Vector3 pos = new Vector3(Managers.Game.Statue.transform.position.x - 3, Managers.Game.Statue.transform.position.y, Managers.Game.Statue.transform.position.z);
        //if (Managers.Game.Player == null)
        //    Managers.Game.Player = Managers.Game.Spawn(Define.WorldObject.Chracter, "Prefabs/Character/Knight", pos);
        if (Managers.Game.Player == null && Managers.Game.PlayerName != null)
        {
            Managers.Game.Player
                = Managers.Game.Spawn(Define.WorldObject.Chracter, $"Prefabs/Character/{Managers.Game.PlayerName}", pos);

            Managers.Game.Player.GetOrAddComponent<PlayerController>();
        }

        // 카메라 생성
        Transform cameraRoot = new GameObject().transform;
        cameraRoot.name = "@Camera_Root";
        if (Managers.Game.MainCamera == null)
            Managers.Game.MainCamera = Managers.Resource.Instantiate("Prefabs/Camera/MainCamera", cameraRoot).GetOrAddComponent<MainCameraController>().gameObject;
        if (Managers.Game.MinimapCamera == null)
            Managers.Game.MinimapCamera = Managers.Resource.Instantiate("Prefabs/Camera/MinimapCamera", cameraRoot).GetOrAddComponent<MinimapCameraController>().gameObject;
        if (Managers.Game.WorldmapCamera == null)
            Managers.Game.WorldmapCamera = Managers.Resource.Instantiate("Prefabs/Camera/WorldmapCamera", cameraRoot).GetOrAddComponent<WorldmapCameraController>().gameObject;

        // 스포닝풀 생성        
        if (Managers.Game.SpawningPool == null)
        {
            Managers.Resource.Instantiate("Prefabs/SpawningPool", new Vector3(5.0f, 5.0f, 50.0f));
        }
    }

    public override void Clear()
    {

    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    Managers.Scene.LoadScene(Define.Scene.Login);
        //}
    }

}
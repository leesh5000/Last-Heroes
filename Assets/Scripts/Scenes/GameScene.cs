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
        if (Managers.Game.Player == null)
            Managers.Game.Player = Managers.Game.Spawn(Define.WorldObject.Chracter, "Prefabs/Character/Knight", pos);

        // 카메라 생성
        if (Managers.Game.MainCamera == null)
            Managers.Game.MainCamera = Managers.Resource.Instantiate("Prefabs/Camera/MainCamera").GetOrAddComponent<MainCameraController>().gameObject;
        if (Managers.Game.MinimapCamera == null)
            Managers.Game.MinimapCamera = Managers.Resource.Instantiate("Prefabs/Camera/MinimapCamera").GetOrAddComponent<MinimapCameraController>().gameObject;
        if (Managers.Game.WorldmapCamera == null)
            Managers.Game.WorldmapCamera = Managers.Resource.Instantiate("Prefabs/Camera/WorldmapCamera").GetOrAddComponent<WorldmapCameraController>().gameObject;

        // 스포닝풀 생성
        if (Managers.Game.SpawningPool == null)
        {
            GameObject original = Resources.Load<GameObject>("Prefabs/SpawningPool");
            Managers.Game.SpawningPool = Instantiate(original, new Vector3(5.0f, 5.0f, 50.0f), Quaternion.identity);
        }


        //// TEMP
        //GameObject statue = GameObject.Find("Statue");

        //// 캐릭터 생성
        //Vector3 pos = new Vector3(statue.transform.position.x - 3, statue.transform.position.y, statue.transform.position.z);
        //GameObject player = Managers.Game.Spawn(Define.WorldObject.Chracter, "Prefabs/Character/Knight", pos);

        //// 카메라 생성
        //GameObject mainCamera = GameObject.Find("MainCamera");
        //if (mainCamera == null)
        //    mainCamera = Managers.Resource.Instantiate("Prefabs/Camera/MainCamera");
        //GameObject minimapCamera = GameObject.Find("MinimapCamera");
        //if (minimapCamera == null)
        //    minimapCamera = Managers.Resource.Instantiate("Prefabs/Camera/MinimapCamera");
        //GameObject worldmapCamera = GameObject.Find("WorldmapCamera");
        //if (worldmapCamera == null)
        //    worldmapCamera = Managers.Resource.Instantiate("Prefabs/Camera/WorldmapCamera");

        //// 카메라에 스크립트 추가 & 캐릭터 넣어주기
        ////mainCamera.GetOrAddComponent<CameraController>().SetPlayer(player);
        //mainCamera.GetOrAddComponent<MainCameraController>().SetPlayer(player);
        //minimapCamera.GetOrAddComponent<MinimapCameraController>().SetPlayer(player);
        //worldmapCamera.GetOrAddComponent<WorldmapCameraController>();

        //// 스포닝풀 생성
        //Object original = Resources.Load("Prefabs/SpawningPool");
        //Instantiate(original, new Vector3(5.0f, 5.0f, 50.0f), Quaternion.identity);
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
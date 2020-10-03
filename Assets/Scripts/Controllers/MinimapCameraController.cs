using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraController : MonoBehaviour
{
    [SerializeField]
    Vector3 _offset = new Vector3(0.0f, 100.0f, 0.0f);

    [SerializeField]
    GameObject _player = null;

    [SerializeField]
    LayerMask _cullingMask = ~(1<<(int) Define.Layer.Monster | 1<<(int) Define.Layer.Player | 1<<(int) Define.Layer.Shop
            | 1<<(int) Define.Layer.Statue | 1<<(int) Define.Layer.Tent);

    public void SetPlayer(GameObject player) { _player = player; }

    void Start()
    {
        gameObject.GetComponent<Camera>().cullingMask = _cullingMask;
    }

    void Update()
    {
        transform.position = _player.transform.position + _offset;
    }
}

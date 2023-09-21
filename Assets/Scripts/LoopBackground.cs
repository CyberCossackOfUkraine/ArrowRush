using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    private Renderer backgroundRenderer;

    private void Start()
    {
        backgroundRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(0f, PlayerController.instance.playerSpeed / 11 * Time.deltaTime);
    }
}

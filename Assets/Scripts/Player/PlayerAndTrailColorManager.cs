using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAndTrailColorManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _arrowSprite;
    [SerializeField] private LineRenderer _trailSprite;
    [SerializeField] private Color[] colors;
    private void Start()
    {
        _arrowSprite.color = colors[DataInfo.equippedArrowColor];
        _trailSprite.material.color = colors[DataInfo.equippedTrailColor];
    }
}

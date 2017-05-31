using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestResizeSprite : MonoBehaviour {
    [SerializeField]
    SpriteRenderer sr;

    private void Start()
    {
        ResizeSpriteToScreen(sr);
    }
    public void ResizeSpriteToScreen(SpriteRenderer sr)
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        float width = sr.bounds.size.x;
        float height = sr.bounds.size.y;

        float worldScreenHigh = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHigh / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHigh / height);
    }
}

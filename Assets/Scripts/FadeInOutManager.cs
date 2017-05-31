using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FadeInOutManager : Singleton<FadeInOutManager>{
    // guarantee this will be always a singletone only - cant use the constructor.
    protected FadeInOutManager() { }

    // The texture to display when fading
    private Material fadeMaterial;
    
    // FadingParam
    private float fadeOutTime, fadeInTime;
    private Color fadeColor;

    // Place holder for the level you will be navigating to (by name or index)
    private string navigateToLevelName = "";
    private int navigateToLevelIndex = 0;

    // State to control if a level is fading or not, including public property if access through code
    private bool fading = false;
    public static bool Fading
    {
        get { return Instance.fading; }
    }

    private void Awake()
    {
        // Setup a default blank texture for fading if none is supplied
        fadeMaterial = Resources.Load("Shader/Fade") as Material;
    }

    private IEnumerator Fade ()
    {
        float t = 0.0f; 
        while (t < 1.0f)
        {
            yield return new WaitForEndOfFrame();
            t = Mathf.Clamp01(t + Time.deltaTime / fadeOutTime);
            DrawningUtilities.DrawQuad(fadeMaterial, fadeColor, t);
        }

        if (navigateToLevelName != "")
        {
            SceneManager.LoadScene(navigateToLevelName);
        }
        else
        {
            SceneManager.LoadScene(navigateToLevelIndex);
        }
        while(t > 0.0f)
        {
            yield return new WaitForEndOfFrame();
            t = Mathf.Clamp01(t - Time.deltaTime / fadeInTime);
            DrawningUtilities.DrawQuad(fadeMaterial, fadeColor, t);
        }
        fading = false;
    }
    #region Fade to level by string name

    public static void FadeToLevel(string aLevelName, float aFadeOutTime, float aFadeInTime, Color aColor)
    {
        if (Fading) return;
        Instance.navigateToLevelName = aLevelName;
        Instance.StartFade(aFadeOutTime, aFadeInTime, aColor);
    }

    public static void FadeToLevel(string aLevelName)
    {
        if (Fading) return;
        Instance.navigateToLevelName = aLevelName;
        FadeToLevel(aLevelName, 2f, 2f, Color.black);
    }

    public static void FadeToLevel(Material aFadeMaterial, string aLevelName)
    {
        Instance.fadeMaterial = aFadeMaterial;
        FadeToLevel(aLevelName);
    }

    public static void FadeToLevel(Material aFadeMaterial, string aLevelName, float aFadeOutTime, float aFadeInTime, Color aColor)
    {
        Instance.fadeMaterial = aFadeMaterial;
        FadeToLevel(aLevelName, aFadeOutTime, aFadeInTime, aColor);
    }

    #endregion

    #region Fade to level by level index
    //Lana Rhoades
    //Giselle Palmer
    public static void FadeToLevel(int aLevelIndex, float aFadeOutTime, float aFadeInTime, Color aColor)
    {
        if (Fading) return;
        Instance.navigateToLevelName = "";
        Instance.navigateToLevelIndex = aLevelIndex;
        Instance.StartFade(aFadeOutTime, aFadeInTime, aColor);
    }

    public static void FadeToLevel(int aLevelIndex)
    {
        if (Fading) return;
        FadeToLevel(aLevelIndex, 2f, 2f, Color.black);
    }

    public static void FadeToLevel(Material aFadeMaterial, int aLevelIndex)
    {
        Instance.fadeMaterial = aFadeMaterial;
        FadeToLevel(aLevelIndex);
    }

    public static void FadeToLevel(Material aFadeMaterial, int aLevelIndex, float aFadeOutTime, float aFadeInTime, Color aColor)
    {
        Instance.fadeMaterial = aFadeMaterial;
        FadeToLevel(aLevelIndex, aFadeOutTime, aFadeInTime, aColor);
    }

    #endregion
    private void StartFade(float aFadeOutTime, float aFadeInTime, Color aColor)
    {
        fading = true;
        Instance.fadeOutTime = aFadeOutTime;
        Instance.fadeInTime = aFadeInTime;
        Instance.fadeColor = aColor;
        StopAllCoroutines();
        StartCoroutine(Fade());
    }

    public void ResizeSpriteToScreen(SpriteRenderer sr)
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHigh = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHigh / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHigh / height);
    }

    public static class DrawningUtilities
    {
        public static void DrawQuad(Material aMaterial, Color aColor, float aAlpha)
        {
            aColor.a = aAlpha;
            aMaterial.SetPass(0);
            GL.PushMatrix();
            GL.LoadOrtho();
            GL.Begin(GL.QUADS);
            GL.Color(aColor);
            GL.Vertex3(0, 0, -1);
            GL.Vertex3(0, 1, -1);
            GL.Vertex3(1, 1, -1);
            GL.Vertex3(1, 0, -1);
            GL.End();
            GL.PopMatrix();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TestNavigateTo : SingletoneAsComponent<TestNavigateTo>
{   
    /*
    [SerializeField]
    string destenation1;
    [SerializeField]
    string destenation2;
    */

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(2); // загрузка уровня по индексу
        }
        */
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            
            //FadeInOutManager.FadeToLevel("The Home", 2.0f, 2.0f, Color.yellow);
            //NavigationManager.NavigateTo("The Home");
        }
    }
    public void ResizeSpriteToScreen(Sprite sr)
    {
        sr = GetComponent<Sprite>();
        if (sr == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        float width = sr.bounds.size.x;
        float height = sr.bounds.size.y;

        float worldScreenHigh = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHigh / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHigh / height);
    }
    /*
    IEnumerator TransitionLevelFromFade(float timeTransition,float FadeOut, float FadeIn, string destenation, Color color)
    {
        
    }
  */
}

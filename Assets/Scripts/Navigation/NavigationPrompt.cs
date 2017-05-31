using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigationPrompt : MonoBehaviour
{
    bool showDialog;

    void OnCollisionEnter2D(Collision2D col)
    {
        //Only allow the player to travel if allowed
        if (NavigationManager.CanNavigate(this.tag))
        {
            DialogVisible(true);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        DialogVisible(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Only allow the player to travel if allowed
        // Доступно только тогда когда путь не false
        if (NavigationManager.CanNavigate(this.tag))
        {
            DialogVisible(true);
        }
    }

    void OnGUI()
    {
        if (showDialog)
        {
            //layout start
            GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, 250));

            //the menu background box
            GUI.Box(new Rect(0, 0, 300, 250), "");

            //Dialog detail - updated to get better detail
            GUI.Label(new Rect(15, 10, 300, 68), "Do you want to travel to " + NavigationManager.GetRouteInfo(this.tag) + "?");

            //Player wants to leave this location
            if (GUI.Button(new Rect(55, 100, 180, 40), "Travel"))
            {
                DialogVisible(false);
                NavigationManager.NavigateTo(this.tag);
            }

            //Player wants to stay at this location
            if (GUI.Button(new Rect(55, 150, 180, 40), "Stay"))
            {
                DialogVisible(false);
            }

            //layout end
            GUI.EndGroup();
        }
    }

    void DialogVisible(bool visibility)
    {
        showDialog = visibility;
        EventManager.Instance.PostNotification(EVENT_TYPE.TRAVEL, this, visibility);
    }
    /*
    bool showDialog;
    GameObject canvas;
    [SerializeField]
    TMPro.TextMeshProUGUI text;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    private void Start()
    {
        showDialog = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (NavigationManager.CanNavigate(this.tag))
        {
            showDialog = true;
        }
        /*
        {
            canvas.gameObject.SetActive(true);
            text.text = "Do you want to travel to " + this.tag;
        }     
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        showDialog = false;
    }
    
    private void OnGUI()
    {
        if (showDialog)
        {
            canvas.SetActive(true);
            text.text = "Do you want to travel to " + NavigationManager.GetRouteInfo(this.tag) + "?";
        }
        /*
        if (showDialog)
        {
            
            // layout start
            GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, 200));

            // the menu background box
            GUI.Box(new Rect(0, 0, 300, 250), "");

            // Information text
            GUI.Label(new Rect(15, 10, 300, 68), "Do you want to travel to " + this.tag + "?");

            // Player wants to leave this location
            if (GUI.Button(new Rect(55, 100, 180, 40), "Travel"))
            {
                showDialog = false;

                // The foolowing line is commented out.
                // Application.LoadLevel(1);
            }
            if (GUI.Button(new Rect(55, 150, 180, 40), "Stay"))
            {
                showDialog = false;
            }
            // layout end
            GUI.EndGroup();
            
            }
        }

    public void Travel()
    {
        if (showDialog)
        {
            showDialog = false;
            NavigationManager.NavigationTo(this.tag);
        }
    }
     public void Stay()
    {
        if (showDialog)
        {
            showDialog = false;
        }   
    }*/
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMovement : MonoBehaviour, IListener
{
    Vector3 StartLocation;
    Vector3 TargetLocation;
    float timer = 0;
    bool startedTravelling = false;
    bool inputActive = true;
    bool inputReady = true;
    [SerializeField]
    AnimationCurve movementCureve;

    int EncounterChance = 5; // Шанс боя в процентах
    float EncounterDistance = 0.0f;

    private void Awake()
    {
        this.GetComponent<Collider2D>().enabled = false;
        Vector3 lastPosition = GameState.GetLastScenePosition(SceneManager.GetActiveScene().name);

        if (lastPosition != Vector3.zero)
        {
            transform.position = lastPosition;
        }
    }

    private void Start()
    {
        EventManager.Instance.AddListener(EVENT_TYPE.TRAVEL, this);
    }
    /*
    void TwoInts(int int1, int int2)
    {
    }
    */
    public void OnEvent(EVENT_TYPE Event_Type, Component Sender, object Param = null)
    {
        switch (Event_Type)
        {
            case EVENT_TYPE.TRAVEL:
                UpdateInputAction((bool)Param);
                //TwoInts((int)Param, (int)Param);// тест 2 Param
                break;
        }
    }
    private void OnDestroy()
    {
        GameState.SetLastScenePosition(SceneManager.GetActiveScene().name, transform.position);
        EventManager.Instance.RemoveEvent(EVENT_TYPE.TRAVEL);
    }

    private void UpdateInputAction(bool uiVisible)
    {
        inputReady = !uiVisible;
       
    }

    private void Update()
    {
        if (inputActive && Input.GetMouseButtonUp(0))
        {
            StartLocation = transform.position.ToVector3_2D();
            timer = 0;
            TargetLocation = WorldExtension.GetScreenPositionFor2D(Input.mousePosition);
            startedTravelling = true;
            //Work out if a battle is going to happen and if it's likely 
            //then set the distance the player will travel before it happens
            // Выясняем произойдет ли сражение и если это возможно, устанавливаем расстояие пройденное игроком до того, как оно произойдет.
            int EncounterProbability = Random.Range(1, 100);
            if (EncounterProbability < EncounterChance && !GameState.PlayerReturningHome) // тут происходит проверка шанса боя. Интересный код))!!
            {
                EncounterDistance = (Vector3.Distance(StartLocation, TargetLocation) / 100) * Random.Range(10, 100);
            }
            else
            {
                EncounterDistance = 0.0f;
            }
        }
        /* // Input touch для тача
        else if (inputActive && Input.touchCount == 1)
        {
            StartLocation = transform.position.ToVector3_2D();
            timer = 0;
            TargetLocation = WorldExtensions.GetScreenPositionFor2D(Input.GetTouch(0).position);
            startedTravelling = true;
            var EncounterProbability = Random.Range(1, 100);
            if (EncounterProbability < EncounterChance && !GameState.playerReturningHome)
            {
                EncounterDistance = (Vector3.Distance(StartLocation, TargetLocation) / 100) * Random.Range(10, 100);
            }
            else
            {
                EncounterDistance = 0;
            }
        }
        */
        if (TargetLocation != Vector3.zero && TargetLocation != transform.position && TargetLocation != StartLocation)
        {
            float dist = Vector3.Distance(StartLocation, TargetLocation);
            transform.position = Vector3.Lerp(StartLocation, TargetLocation, timer / dist);//movementCureve.Evaluate(timer)// регулировка спомощью AnimationCurve
            timer += Time.fixedDeltaTime;
        }
        if(startedTravelling && Vector3.Distance(StartLocation, transform.position.ToVector3_2D()) > 0.5)
        {
            this.GetComponent<Collider2D>().enabled = true;
            startedTravelling = false;
        }
        //If there is an encounter distance, then a battle must occur. 
        //So when the player has travelled far enough, stop and enter the battle scene
        if (EncounterDistance > 0)
        {
            if (Vector3.Distance(StartLocation, transform.position) > EncounterDistance)
            {
                TargetLocation = Vector3.zero;
                NavigationManager.NavigateTo("Battle");
            }
        }
        if (!inputReady && inputActive)
        {
            TargetLocation = this.transform.position;
        }
        inputActive = inputReady;
    }
}

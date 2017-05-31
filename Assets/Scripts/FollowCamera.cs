using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    // Distance in the x axis the player can move before the camera follow.
    public float xMargin = 1.5f;
    // Distance in the y axis the player can move before the camera follow.
    public float yMargin = 1.5f;
    // How smoothly the camera catches up with its target movement in the x axis.
    public float xSmooth = 1.5f;
    // How smoothly the camera catches up with its target movement in the x axis.
    public float ySmooth = 1.5f;
    // The maximum x and y coordinates the camera can have.
    public Vector2 maxXAndY;
    // The minimum x and y coordinates the camera can have.
    public Vector2 minXAndY;
    // Reference to the player's transform.
    [HideInInspector]
    public Transform player;
    Bounds background;
    Vector3 camTopLeft;
    Vector3 camBottomRight;
    Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        background = GameObject.FindGameObjectWithTag("Background").GetComponent<Renderer>().bounds;
        camTopLeft = _camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        camBottomRight = _camera.ViewportToWorldPoint(new Vector3(1, 1, 0));
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.Log("Player object not found");
        }
    }
    // FixedUpdate used for physics and time sensitive code.
    private void FixedUpdate()
    {
        // By default the target x and y coordinates of the camera are it's current x and y coordinates.
        // Сохраняем кординаты камеры по оси x и y.
        float targetX = transform.position.x;
        float targetY = transform.position.y;
        // Automatically set the min and max values
        minXAndY.x = background.min.x - camTopLeft.x;
        maxXAndY.x = background.max.x - camBottomRight.x;
        // If the player has moved beyond the x margin...
        // если игрок выходит за границу x Margin.
        if (CheckXMargin())
        {
            // the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.fixedDeltaTime);
        }
        // if the player has moved beyond the y margin...
        // если игрок выходит за границу y Margin.
        if (CheckYMargin())
        {
            // the target x coordinate should be a Lerp between the camera's current y position and the player's current y position.
            targetY = Mathf.Lerp(transform.position.y, player.position.y, xSmooth * Time.fixedDeltaTime);
        }
        // The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        // Set the camera's position to the target position with the smae z component.
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
    bool CheckXMargin()
    {
        // Возвращает true если дистанция между камерой и игроком по оси x больще x margin.
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }
    bool CheckYMargin()
    {
        // Возвращает true если дистанция между камерой и игроком по оси y больще y margin.
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }
}

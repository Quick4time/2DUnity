using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraWorld : MonoBehaviour
{
    // Distance in the x axis the player can move before the camera follow.
    [SerializeField]
    float xMargin = 0.4f;
    // Distance in the y axis the player can move before the camera follow.
    [SerializeField]
    float yMargin = 0.4f;
    // How smoothly the camera catches up with its target movement in the x axis.
    [SerializeField]
    float xSmooth = 2f;
    // How smoothly the camera catches up with its target movement in the x axis.
    [SerializeField]
    float ySmooth = 2f;
    // The maximum x and y coordinates the camera can have.
    [SerializeField]
    Vector2 maxXAndY;
    // The minimum x and y coordinates the camera can have.
    [SerializeField]
    Vector2 minXAndY;
    // Reference to the player's transform.
    [SerializeField]
    Transform player;
    Bounds background;
    Vector2 camTopLeft;
    Vector2 camBottomRight;
    Camera _camera;

    private void Awake()
    {
        transform.position = new Vector3(0.0f,0.0f,-3.0f);
        _camera = GetComponent<Camera>();
        background = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>().bounds;
        camTopLeft = _camera.ViewportToWorldPoint(new Vector2(0, 0));
        camBottomRight = _camera.ViewportToWorldPoint(new Vector2(1, 1));
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.Log("Player object not found");
        }
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -3.0f);
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
        minXAndY.y = background.min.y - camTopLeft.y;
        maxXAndY.y = background.max.y - camBottomRight.y;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMobileControll : MonoBehaviour, IDragHandler, IBeginDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Rigidbody player;

    [SerializeField] private float acceleration;
    [SerializeField] private float speedMax;
    [SerializeField] private float speedSide;

    private float maxSpeedSide;

    private Vector3 moveVector;
    private int xDrag, yDrag;
    private bool fingerDown;

    private int hitTimes;
    private bool gameEnd;

    public float speed;

    private void Start()
    {
        maxSpeedSide = speedSide;
    }

    private void Update()
    {
        if (fingerDown && speed <= speedMax)
            Acceleration(1);

        if ((!fingerDown && speed > 0) || speed > speedMax)
            Acceleration(-1);

        if (speed < 0)
            speed = 0;
    }

    private void FixedUpdate()
    {
        if (gameEnd)
            return;

        MoveToVector();
    }

    private void Acceleration(float value)
    {
        if (gameEnd)
            return;

        if (value > 0)
            speed += (acceleration * Time.deltaTime);

        if (value < 0)
            speed -= (acceleration * 1.25f * Time.deltaTime);
    }

    private void MoveToVector()
    {
        if (!fingerDown)
            moveVector = Vector3.zero;

        moveVector.z = speed;
        player.MovePosition(player.transform.position + moveVector * Time.fixedDeltaTime);
    }

    IEnumerator PlayerStop()
    {
        yield return new WaitForSeconds(3);
        player.velocity = Vector3.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        fingerDown = true;
        speedSide = 0;
    }

    public void OnDrag(PointerEventData eventData)
    {
        moveVector = Vector3.zero;

        if (eventData.delta.x > 0)
            xDrag = 1;

        if (eventData.delta.x < 0)
            xDrag = -1;

        if (eventData.delta.y > 0)
            yDrag = 1;

        if (eventData.delta.y < 0)
            yDrag = -1;

        if (eventData.delta.x == 0)
            xDrag = 0;

        if (eventData.delta.y == 0)
            yDrag = 0;

        if(speedSide < maxSpeedSide)
            speedSide += 10 * Time.deltaTime;

        moveVector.x = xDrag * speedSide;
        moveVector.y = yDrag * speedSide;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        fingerDown = false;
        StartCoroutine(PlayerStop());
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void PlayerLoose()
    {
        gameEnd = true;
        speed = 0.1f;
        moveVector = Vector3.zero;
        moveVector.x = Random.Range(-3, 3);
        moveVector.y = Random.Range(-3, 3);
        moveVector.z = Random.Range(-3, 3);
    }
}

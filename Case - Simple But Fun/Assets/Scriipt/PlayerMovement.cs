using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Swipe Settings For PC")]
    public float roadSize = 10;
    public float swipeSpeed = 5;
    public float sensitive = 3;
    private float _initalX = 0;
    private float startX;
    GameManager gm;


    Animator playerAnim;
    PathFollower ptFollower;

    private void Start()
    {
        ptFollower = GetComponent<PathFollower>();
        playerAnim = GetComponentInChildren<Animator>();
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (gm.isPlay)
            PlayerSwipe();
    }

    public void StartGamePlayer()
    {
        ptFollower.speed = 10;
        playerAnim.SetBool("run", true);
    }
    public void StoptGamePlayer()
    {
        ptFollower.speed = 0;
        playerAnim.SetBool("run", false);
    }

    public void PlayerSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _initalX = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
            startX = transform.GetChild(0).localPosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            float screenPos = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
            screenPos = Mathf.Clamp(screenPos, 0, 1);

            float newX = startX + (roadSize / 2) * (screenPos - _initalX) * swipeSpeed;
            transform.GetChild(0).localPosition = Vector3.Lerp(transform.GetChild(0).localPosition, new Vector3(newX, transform.GetChild(0).localPosition.y, transform.GetChild(0).localPosition.z), sensitive * Time.deltaTime);

            var localPos = transform.GetChild(0).localPosition;
            localPos.x = Mathf.Clamp(localPos.x, -roadSize / 2, roadSize / 2);
            transform.GetChild(0).localPosition = localPos;
        }
    }
}
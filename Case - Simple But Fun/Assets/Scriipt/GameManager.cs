using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ParticleSystem starsParticle;
    GameObject finishLine;
    PlayerMovement plMovement;
    UiManager uimanagerClass;

    public bool isPlay;
    int score;
    void Start()
    {
        Initialize();
    }
    private void Initialize()
    {
        uimanagerClass = GetComponent<UiManager>();
        plMovement = FindObjectOfType<PlayerMovement>();
        finishLine = GameObject.FindGameObjectWithTag("Finish");
        uimanagerClass.progressBar.maxValue = Vector3.Distance(plMovement.transform.position, finishLine.transform.position);
    }
    void Update()
    {
        uimanagerClass.progressBar.value = uimanagerClass.progressBar.maxValue - Vector3.Distance(plMovement.transform.position, finishLine.transform.position);
    }

    public void StartGame()
    {
        isPlay = true;
        plMovement.StartGamePlayer();
    }

    public void ScoreUp()
    {
        score += 5;
        uimanagerClass.score.text = score.ToString();
    }
    public void ScoreDown()
    {
        score -= 5;
        uimanagerClass.score.text = score.ToString();
    }
    public void StopGame()
    {
        isPlay = false;
        plMovement.StoptGamePlayer();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    //[SerializeField] int startingBalance = 100, startingLife = 99;
    //[SerializeField] float levelTime = 10f;

    [SerializeField] GameObject loseOverlay = null;

    [Header("Win Condition")]
    [SerializeField] GameObject winOverlay = null;
    [SerializeField] AudioClip winClip = null;
    [SerializeField] float loadNextLevelTime = 5f;

    int balance, life, liveAttackers = 0;
    LevelLoader ll;
    bool spawn = true;
    

    private void Start()
    {
        balance = DifficultyPresets.GetStartingMoney();
        life = DifficultyPresets.GetStartingHealth();        

        ll = FindObjectOfType<LevelLoader>();
    }

    Coroutine winCoroutine;
    private void Update()
    {
        if (spawn == false && liveAttackers == 0)
        {
            if (winCoroutine == null) winCoroutine = StartCoroutine(handleWin());
        }
    }

    IEnumerator handleWin()
    {
        winOverlay.SetActive(true);
        AudioSource.PlayClipAtPoint(winClip, Camera.main.transform.position, PlayerPrefsController.GetMasterVolume());
        yield return new WaitForSeconds(loadNextLevelTime);

        ll.LoadNextScene();
    }

    void handleLose()
    {
        loseOverlay.SetActive(true);
        Time.timeScale = 0;
    }

    public void Deposit(int stars)
    {
        balance += stars;
    }

    public void Withdraw(int stars)
    {
        if (balance >= stars) balance -= stars;
    }

    public int GetBalance()
    {
        return balance;
    }

    public void LoseLife(int amt)
    {
        if (life == 0) return;

        life = Mathf.Clamp(life - amt, 0, life);
        if (life == 0)
        {
            handleLose();
        }
    }

    public int GetLife()
    {
        return life;
    }

    public void StopSpawns()
    {
        spawn = false;
        Debug.Log("Round Ending");
    }

    public bool isSpawning()
    {
        return spawn;
    }

    public void NewAttacker()
    {
        liveAttackers++;
    }

    public void AttackerDied()
    {
        liveAttackers--;
    }   
}

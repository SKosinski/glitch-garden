using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] int numberOfAttackers = 0;
    [SerializeField] AudioClip[] audioClips;

    bool levelEnd = false;

    // Start is called before the first frame update

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        FindAllAttackers();
    }

    private void Update()
    {
        if (numberOfAttackers == 0 || FindObjectOfType<GameTimer>().GetTimerFinished())
        {
            if (!levelEnd)
            {
                HandleWinCondition();
                levelEnd = true;
            }
        }
    }

    public void decreaseNumberOfAttackers()
    {
        numberOfAttackers--;
    }

    public void HandleLoseCondition()
    {
        GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void HandleWinCondition()
    {
        GetComponent<AudioSource>().PlayOneShot(audioClips[1]);
        winLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void FindAllAttackers()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner attackerSpawner in attackerSpawners)
        {
            numberOfAttackers += attackerSpawner.attackersToSpawn;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] int numberOfAttackers = 0;
    [SerializeField] AudioClip[] audioClips;

    // Start is called before the first frame update

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void decreaseNumberOfAttackers()
    {
        numberOfAttackers--;
        if (numberOfAttackers == 0 && FindObjectOfType<GameTimer>().GetTimerFinished())
        {
            HandleWinCondition();
        }
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

    public void increaseNumberOfAttackers()
    {
        numberOfAttackers++;
    }

}

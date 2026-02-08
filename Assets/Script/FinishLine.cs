using System.Collections;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public AudioClip winClip;          
    private AudioSource audioSource;    
    public GameObject PanelWin;
    private bool finished = false;

    void Start()
    {
        PanelWin.SetActive(false);
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !finished)
        {
            finished = true;

            Move move = collision.GetComponent<Move>();
            if (move != null)
                move.enabled = false;

            if (winClip != null)
                audioSource.PlayOneShot(winClip);

            BullectActions.UpdateScore(5);

            StartCoroutine(ShowWinPanel());
        }
    }

    IEnumerator ShowWinPanel()
    {
        yield return new WaitForSeconds(0.1f);
        PanelWin.SetActive(true);
        Time.timeScale = 0f;
    }
}

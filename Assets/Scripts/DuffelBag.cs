using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuffelBag : MonoBehaviour
{
    [SerializeField] GameObject posEffect;
    [SerializeField] GameObject negEffect;
    LevelHandler lh;
    GameController gc;

    [SerializeField] AudioClip[] goodClips;
    [SerializeField] [Range(0, 1)] float goodVolume = 0.5f;
    [SerializeField] AudioClip badClip;
    [SerializeField] [Range(0, 1)] float badVolume = 0.5f;

    private void Start()
    {
        lh = FindObjectOfType<LevelHandler>();
        gc = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if(otherObject.gameObject.GetComponent<Valuable>())
        {
            GameObject effect;
            AudioClip clip;
            int scoreToAdd = otherObject.gameObject.GetComponent<Valuable>().GetValue();
            gc.AddToScore(scoreToAdd);
            //Instantiate posEffect
            if (scoreToAdd > 0)
            {
                effect = Instantiate(posEffect, transform.position, transform.rotation);
                clip = goodClips[Random.Range(0, goodClips.Length)];
                AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, goodVolume);
            }
            //Instantiate negEffect
            else
            {
                effect = Instantiate(negEffect, transform.position, transform.rotation);
                clip = badClip;
                AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, badVolume);
            }
            Destroy(effect, 1);
            Destroy(otherObject.gameObject);
            lh.DecrementActiveObjects();
        }
    }
}

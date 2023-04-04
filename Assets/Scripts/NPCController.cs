using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    [SerializeField] Image background;
    [SerializeField] Sprite[] backgrounds;
    [SerializeField] AudioClip[] backgroundNoise;
    string previousEnvironment = "cabin";
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string environmentID)
    {
        if (previousEnvironment != environmentID)
        {
            source.Stop();
            switch (environmentID)
            {
                case "cabin":
                    background.sprite = backgrounds[0];
                    break;
                case "large_city":
                    background.sprite = backgrounds[1];
                    source.PlayOneShot(backgroundNoise[1]);
                    source.volume = 0.1f;
                    break;
                case "small_town":
                    background.sprite = backgrounds[2];
                    break;
                case "tavern":
                    background.sprite = backgrounds[3];
                    break;
                case "blacksmith":
                    background.sprite = backgrounds[4];
                    break;
                case "forest":
                    background.sprite = backgrounds[5];
                    source.PlayOneShot(backgroundNoise[0]);
                    source.volume = 0.25f;
                    break;
                case "lake":
                    background.sprite = backgrounds[6];
                    break;
                case "meadow":
                    background.sprite = backgrounds[7];
                    break;
                case "mountain":
                    background.sprite = backgrounds[8];
                    break;
                case "river":
                    background.sprite = backgrounds[9];
                    break;
                case "battlefield":
                    background.sprite = backgrounds[10];
                    break;
                case "dungeon_prison":
                    background.sprite = backgrounds[11];
                    break;   
            }

            previousEnvironment = environmentID;
        }
    }
}

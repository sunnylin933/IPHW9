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
            switch (environmentID)
            {
                case "forest":
                    background.sprite = backgrounds[5];
                    source.PlayOneShot(backgroundNoise[0]);
                    break;
                case "cabin":
                    background.sprite = backgrounds[0];
                    break;
                case "large_city":
                    background.sprite = backgrounds[1];
                    break;
                case "small_town":
                    background.sprite = backgrounds[2];
                    break;

            }

            previousEnvironment = environmentID;
        }
    }
}

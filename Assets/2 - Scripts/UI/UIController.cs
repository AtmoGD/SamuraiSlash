using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ((int)(gameController.Samurai.Score)).ToString();
    }
}

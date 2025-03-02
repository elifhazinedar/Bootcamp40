using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class FinishLine : MonoBehaviour
{
    [SerializeField] public Text scoreCounter;
    [SerializeField] public GameObject victoryScene;
    [SerializeField] public GameObject particles;
    [SerializeField] public Animator _animator;
    bool isFinished;
    public static int coinAmount;
    public ADsManager aDsManager;
    public CameraZoom cameraZoom;
   



    private void Start()
    {
         _animator = _animator.GetComponent<Animator>();
        aDsManager.GetComponent<ADsManager>();
        cameraZoom.GetComponent<CameraZoom>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cameraZoom.isZoomed = true;
            _animator.SetBool("isFinished",true);
            FindObjectOfType<AudioManager>().Play("victorySound");
            particles.SetActive(true);
            Invoke("LoadVictoryScene",5f);
           
           
        }
    }

    void LoadVictoryScene()
    {
        aDsManager.onClickFiveSec();
        victoryScene.SetActive(true);
        scoreCounter.text = coinAmount.ToString();
    }

    public void AdvAdvertisingGift()
    {
        TotalScore._totalScore += coinAmount * 2;
        coinAmount *= 3;
        scoreCounter.text = coinAmount.ToString();
    }
    public void CoinAmoutreset()
    {
        coinAmount = 0;
    }

}


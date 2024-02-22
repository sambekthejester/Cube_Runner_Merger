using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] Cams;
    [SerializeField] GameObject[] char1;
    [SerializeField] GameObject MagicOrb;
    int selection = 0;


    private void Update()
    {
        
    }
    
    public void Leftbutton()
    {
        if (selection==0)
        {
            
        }
        else
        {
            selection--;
            for (int i = 0; i < char1.Length; i++)
            {
                char1[i].transform.position =new Vector3(char1[i].transform.position.x+3, 
                    char1[i].transform.position.y, char1[i].transform.position.z);
            }
        }
    }
    public void Rightbutton()
    {
        if (selection == 5)
        {

        }
        else
        {
            selection++;
            for (int i = 0; i < char1.Length; i++)
            {
                char1[i].transform.position = new Vector3(char1[i].transform.position.x - 3,
                    char1[i].transform.position.y, char1[i].transform.position.z);
            }
        }
    }
    public void SelectionPlayer()
    {
        GameManager.Instance.Skin = char1[selection];
        
        GameManager.Instance.StartGame();
        ReadyToPlay();
    }

    public void ReadyToPlay()
    {
        StartCoroutine(ReadyToPlayAsync());
        SwitchCam();
    }


    public IEnumerator ReadyToPlayAsync()
    {
        yield return new WaitForSeconds(1.5f);
        MagicOrb.SetActive(false);
        Vector3 temp= GameManager.Instance.Player.transform.position;
        GameManager.Instance.Skin.transform.position = temp;
        GameManager.Instance.Skin.transform.SetParent(GameManager.Instance.Player.transform);
        GameManager.Instance.Player.GetComponent<Movement>().enabled=true;
        


    }

    public void SwitchCam()
    {
        StartCoroutine(SwitchCamAsync());
    }
    public IEnumerator SwitchCamAsync()
    {
        
        yield return new WaitForSeconds(.5f);
        Cams[0].Priority = 10;
        Cams[1].Priority = 20;
        MagicOrb.SetActive(true);
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Image HeartUI;
    public Sprite HeartSprite;
    public TextMeshProUGUI Cointext;
    public string SceneName;


    public void LoadLevel1()
    {
        SceneManager.LoadScene(SceneName);
    }
    

    public void IncrementHeartSprite()
    {
        
    }

    public void DecrementHeartSprite()
    {
        
    }

    public void UpdateCoinCounter()
    {
         
    }


    public void ResetAllUI()
    {
        
    }
    

}

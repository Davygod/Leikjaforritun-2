using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Takkinn � Byrjunarsenunni f�rir yfir � Leiksv��i�
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Leikstillingar-takkinn � Byrjunarsenunni f�rir yfir � Leikstillingum (Options)
    public void Option()
    {
        SceneManager.LoadScene(5);
    }

    // Hinar senurnar, enda- og leik-loki�-senan hafa einn takka sem fara � valgluggann og l�ka efsti takkinn � leikstillingarsenunni
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}

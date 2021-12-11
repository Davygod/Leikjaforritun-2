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

    // Takkinn í Byrjunarsenunni færir yfir á Leiksvæðið
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Leikstillingar-takkinn í Byrjunarsenunni færir yfir á Leikstillingum (Options)
    public void Option()
    {
        SceneManager.LoadScene(5);
    }

    // Hinar senurnar, enda- og leik-lokið-senan hafa einn takka sem fara í valgluggann og líka efsti takkinn í leikstillingarsenunni
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}

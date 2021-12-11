using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Klasi sem gerir grein fyrir fjölda óvina í fylki með því að telja þá upp þegar þeir eru tengdir í skriftunni og niður þegar þeir deyja
public class Enemies : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject player;
    

    // Update er kallaður einu sinni hvern ramma
    void Update()
    {
        // GameObject.FindGameObjectsWithTag("Enemy"); // Athugar ef að óvinir séu merktir með "Enemy" (sjá Inspector)
        // SceneManager.GetActiveScene().name; // Leitar að senu samkvæmt röðun í BuildSettings og heiti til þess að fara inn í hana í miðri keyrslu

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && SceneManager.GetActiveScene().name=="FirstLevel")
        {
            SceneManager.LoadScene(2); // Fer yfir í næsta borð ef allir óvinir á fyrra borðinu séu fallnir
        }

        else if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && SceneManager.GetActiveScene().name == "NextLevel")
        {
            SceneManager.LoadScene(4); // Fer yfir í enda-gluggann ef að allir óvinirnir í seinna borðinu séu fallnir
        }

        if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            SceneManager.LoadScene(3); // Fer yfir í leik-lokið-gluggann ef að hetjan hverfur
        }
    }
}

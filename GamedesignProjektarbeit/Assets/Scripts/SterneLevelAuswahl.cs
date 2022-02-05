using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SterneLevelAuswahl : MonoBehaviour
{
    public int levelAnzahl;
    public GameObject[] Sterne;

    private int indexOfStar;            // beschreibt die AktuellePosition im Array
    // Start is called before the first frame update
    void Start()
    {
        /*PlayerPrefs.SetInt("Level1Sterne",0);
        PlayerPrefs.SetInt("Level2Sterne", 0);
        PlayerPrefs.SetInt("Level3Sterne", 0);*/
        indexOfStar = 0;
        CheckStars();
    }



    /// <summary>
    /// Werte die Sterne der Gespielten Level aus
    /// </summary>
    private void CheckStars()
    {
        if (Sterne.Length % 3 == 0) //überprüfe ob die Anzahl der Sterne im Normalen Rahmen sind (immer in 3 er Blöcken)
        {
            for (int i = 0; i < levelAnzahl; i++)
            {
                string plPrefLevlStar = "Level" + (i + 1) + "Sterne"; // setze den Namen des PlayerPrefs Zusammen sofern NamensKonvetion eingehalten ist

                print(plPrefLevlStar);
                int activeSterne = PlayerPrefs.GetInt(plPrefLevlStar); // bekomme die Anzahl der Sterne für den Aktuellen durchlauf
                if (activeSterne == 3)
                {

                    SetStarsValue(3, true);                     //setze 3 Sterne auf true


                }
                else if (activeSterne == 2)
                {

                    SetStarsValue(2, true);                     //2 true 1 flase
                    SetStarsValue(1, false);

                    Sterne[indexOfStar].SetActive(false);
                }
                else if (activeSterne == 1)
                {
                    SetStarsValue(1, true);                     //1 true 2 false
                    SetStarsValue(2, false);
                }
                else
                {
                    SetStarsValue(3, false);                    // 3false
                }
            }
            
        }
    }


    /// <summary>
    /// setze die Amzahl der sterne auf den Wert Value
    /// </summary>
    /// <param name="sterne"></param>
    /// <param name="value"></param>
    private void SetStarsValue(int sterne, bool value)
    {
        for (int i = 0; i < sterne; i++)
        {
            
            Sterne[indexOfStar].SetActive(value);
            indexOfStar++;
            
        }
    }


}

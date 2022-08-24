using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Zbog buttona
using TMPro; //zbog teksta na buttonima

public class FieldScript : MonoBehaviour
{
    // OBAVEZNO STAVITI NA SVAKI BUTTON DEVET TIK TAK TOE POLJA
    [Header("Staviti isklju�ivo na button polja za X ili O")]
    public TextMeshProUGUI btnText;
    private Button btn;
    GameManager gm;

    private void Start()
    {
        btn = GetComponent<Button>();
        btnText = GetComponentInChildren<TextMeshProUGUI>();
        gm = FindObjectOfType<GameManager>();
    }

    // Metoda koja se poziva na klik buttona da se postavi X ili O
    public void SetSymbol()
    {
        btnText.text = gm.side; //napi�i X ili O ovisno o tome �to game manager ka�e tko je na potezu
        btn.interactable = false; // ne mo�e se opet kliknuti na gumb
        gm.moves++; // pove�avanje moves za jedan
        gm.EndGame(); // provjera je li netko pobjedio ili je nerje�eno
    }
}

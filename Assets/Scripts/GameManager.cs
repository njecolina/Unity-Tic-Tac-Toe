using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI[] fieldList; // Textovi sa buttona na kojima se prikazuje X ili O
    [SerializeField] GameObject gameOverPanel; // Panel koji se pali kada se odigra igra
    [SerializeField] TextMeshProUGUI playerOneName; // Ime prvog igraèa
    [SerializeField] TextMeshProUGUI playerTwoName; // Ime drugog igraèa
    [SerializeField] TMP_InputField playerOneNameInput; // unos imena prvog igraèa
    [SerializeField] TMP_InputField playerTwoNameInput; // unos imena prvog igraèa
    [SerializeField] TextMeshProUGUI scoreP1, scoreP2; // dva razlièita teksta za prikaz skora prvog i drugog igraèa
    [SerializeField] TextMeshProUGUI movesText;

    public string side; // može imati samo vrijednost X ili O
    public int moves = 1; // na kojem smo potezu

    private void Start()
    {
        gameOverPanel.SetActive(false); // ugasit gameover panel
        side = "X"; // prvi igraè je X
        moves = 1; // prvi potez

        // oèistiti tekstove i omoguæiti da se može klikati na gumbove
        for (int i = 0; i < fieldList.Length; i++)
        {
            fieldList[i].text = ""; // oèistili smo tekst
            fieldList[i].GetComponentInParent<Button>().interactable = true; // aktiviraj da se može interaktati
        }

        // prikaži score ako naši igraèi imaju score
        scoreP1.text = PlayerPrefs.GetInt("ScoreOne").ToString();
        scoreP2.text = PlayerPrefs.GetInt("ScoreTwo").ToString();
        // postavljanje imena playeru jedan i dva iz player prefsa
        playerOneName.text = PlayerPrefs.GetString("PlayerOne");
        playerTwoName.text = PlayerPrefs.GetString("Playertwo");

        // prikaz na game panelu koji je potez
        movesText.text = "Move " + moves + ".";
    }

    // Metoda koja mjenja tko je na potezu
    public void ChangeSide()
    {
        if (side == "X")
        {
            side = "O";
        }
        else
        {
            side = "X";
        }
        moves++;
        // prikaz na game panelu koji je potez
        movesText.text = "Move " + moves + ".";
    }

    // metoda sa kojom provjeramo imamo li pobjednika ili je možda nerješeno (tie)
    public void EndGame()
    {
        if (fieldList[0].text == side && fieldList[1].text == side && fieldList[2].text == side)
        {
            // pobjeda
            CheckWin();
        }
        else if (fieldList[3].text == side && fieldList[4].text == side && fieldList[5].text == side)
        {
            // pobjeda
            CheckWin();
        }
        else if (fieldList[6].text == side && fieldList[7].text == side && fieldList[8].text == side)
        {
            // pobjeda
            CheckWin();
        }
        else if (fieldList[0].text == side && fieldList[3].text == side && fieldList[6].text == side)
        {
            // pobjeda
            CheckWin();
        }
        else if (fieldList[1].text == side && fieldList[4].text == side && fieldList[7].text == side)
        {
            // pobjeda
            CheckWin();
        }
        else if (fieldList[2].text == side && fieldList[5].text == side && fieldList[8].text == side)
        {
            // pobjeda
            CheckWin();
        }
        else if (fieldList[0].text == side && fieldList[4].text == side && fieldList[8].text == side)
        {
            // pobjeda
            CheckWin();
        }
        else if (fieldList[2].text == side && fieldList[4].text == side && fieldList[6].text == side)
        {
            // pobjeda
            CheckWin();
        }
    }

    // provjera pobjede
    public void CheckWin()
    {
        gameObject.SetActive(true);
        if (moves % 2 == 0)
        {
            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = playerOneName.text + " WINS!";
            PlayerPrefs.SetInt("ScoreOne", PlayerPrefs.GetInt("ScoreOne") + 1);
        }
        else
        {
            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = playerTwoName.text + " WINS!";
            PlayerPrefs.SetInt("ScoreTwo", PlayerPrefs.GetInt("ScoreTwo") + 1);
        }
    }
}

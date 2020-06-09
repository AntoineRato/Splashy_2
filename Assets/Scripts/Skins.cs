using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Skins : MonoBehaviour
{
    public GameSounds gameSoundsScript;
    public GameObject skinsPanel;
    public GameObject skinsBallPanel;
    public GameObject skinsPlateformPanel;
    public GameObject instrumentsPanel;
    public GameObject pianoCheck;
    public GameObject harpeCheck;
    public GameObject marimbaCheck;

    private void Start()
    {
        ChangeCheckedInstrument(gameSoundsScript.getCurrentSelectedInstrument());
    }

    private void ChangeCheckedInstrument(int selection)
    {
        if (selection == 1)
        {
            pianoCheck.SetActive(true);
            harpeCheck.SetActive(false);
            marimbaCheck.SetActive(false);
        }
        else if (selection == 2)
        {
            pianoCheck.SetActive(false);
            harpeCheck.SetActive(true);
            marimbaCheck.SetActive(false);
        }
        else if (selection == 3)
        {
            pianoCheck.SetActive(false);
            harpeCheck.SetActive(false);
            marimbaCheck.SetActive(true);
        }
    }

    public void ChangeInstrument(int selection)
    {
        gameSoundsScript.setCurrentSelectedInstrument(selection);
        ChangeCheckedInstrument(selection);
    }

    public void Show_SkinsPanel()
    {
        skinsPanel.SetActive(!skinsPanel.activeSelf);
    }

    public void Show_SkinsBallPanel()
    {
        instrumentsPanel.SetActive(false);
        skinsPlateformPanel.SetActive(false);
        skinsBallPanel.SetActive(true);
    }

    public void Show_SkinsPlateformPanel()
    {
        instrumentsPanel.SetActive(false);
        skinsPlateformPanel.SetActive(true);
        skinsBallPanel.SetActive(false);
    }

    public void Show_InstrumentsPanel()
    {
        instrumentsPanel.SetActive(true);
        skinsPlateformPanel.SetActive(false);
        skinsBallPanel.SetActive(false);
    }
}

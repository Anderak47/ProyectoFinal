using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    GameData gameData = new GameData();
    GameRepository gameRepository;

    Text flechaText;
    Text muerteText;
    Text vidasText;
   
    void Start()
    {
        
        gameRepository = GetComponent<GameRepository>();
        //borrar data
        gameRepository.SaveData(gameData);
        flechaText = GameObject.Find("/Canvas/FlechaText").GetComponent<Text>();
        muerteText = GameObject.Find("/Canvas/MuertesText").GetComponent<Text>();
        vidasText = GameObject.Find("/Canvas/VidasText").GetComponent<Text>();
        gameData = gameRepository.GetSavedData();

        LoadScreenTexts();
    }
    void LoadScreenTexts()
    {
        flechaText.text = $"Flecha: {gameData.flechas}";
        muerteText.text = $"Muertes: {gameData.muertes}";
        vidasText.text = $"Vidas: {gameData.vidas}";
    }
    public List<string> GetSkills()
    {
        return gameData.Skills;
    }
    //flechas
    public void PerderFlechas() {
        if (gameData.flechas > 0)
        {
            gameData.flechas--;
            gameRepository.SaveData(gameData);
            LoadScreenTexts();
        }
    }
    public int GetFlechas()
    {
        return gameData.flechas;
    }
    //muertes
    public void MuertesEnemigo() {
        gameData.muertes++;
        gameRepository.SaveData(gameData);
        LoadScreenTexts();

    }
    //vidas jugador 5
    public void PerderVidas() {
        if (gameData.vidas>0)
        {
            gameData.vidas--;
            gameRepository.SaveData(gameData);
            LoadScreenTexts();
        }
    }
    public int GetVidas()
    {
        return gameData.vidas;
    }
}

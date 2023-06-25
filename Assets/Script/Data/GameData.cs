using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int flechas;
    public int muertes;
    public int vidas;
    public List<string> Skills;
    public GameData()
    {
        muertes = 0;
        flechas = 10;
        vidas = 5;
        Skills = new List<string>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFight : MonoBehaviour
{

    public LevelLoader levelLoader;
    // Start is called before the first frame update
    public void Exit()
    {
        levelLoader.LoadSelectedLevel(0);
    }
}

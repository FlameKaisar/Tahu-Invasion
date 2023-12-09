using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarterGames.Assets.LeaderboardManager;

public class Leaderboard : MonoBehaviour


{
    // Start is called before the first frame update
    void Start()
    {
        LeaderboardManager.CreateLeaderboard("Game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddEntry()
    {
        LeaderboardDisplay display = gameObject.AddComponent<LeaderboardDisplay>();
        LeaderboardManager.AddEntryToBoard("Game", new LeaderboardEntry("Budi", 100));
        LeaderboardManager.GetLeaderboard("Game");
        display.ClearDisplay();
        display.UpdateDisplay();
        Debug.Log("Add");
    }

    public void DeleteEntry()
    {
        LeaderboardDisplay display = gameObject.AddComponent<LeaderboardDisplay>();
        LeaderboardManager.DeleteEntryFromBoard("Game", new LeaderboardEntry("Budi", 100));
        LeaderboardManager.GetLeaderboard("Game");
        display.ClearDisplay();
        display.UpdateDisplay();
        Debug.Log("Delete");
    }

    public void ClearEntry()
    {
        LeaderboardManager.ClearLeaderboard("Game");
        LeaderboardManager.Load();
        Debug.Log("Clear");
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementView : MonoBehaviour
{
    [SerializeField] private GameObject achievementSlotPrefab;  // 업적 슬롯 프리팹
    private Dictionary<int, AchievementSlot> achievementSlots = new();

    public void CreateAchievementSlots(AchievementSO[] achievements)
    {
        foreach(AchievementSO achievement in achievements)
        {
            GameObject achievementSlot = Instantiate(achievementSlotPrefab, transform);
            AchievementSlot slot = achievementSlot.GetComponent < AchievementSlot > ();
            slot.Init(achievement);
            achievementSlots.Add(achievement.threshold, slot);
            
        }
        // achievement 데이터에 따라 슬롯을 생성함
    }

    public void UnlockAchievement(int threshold)
    {
        achievementSlots[threshold].MarkAsChecked();
        // UI 반영 로직
    }
}
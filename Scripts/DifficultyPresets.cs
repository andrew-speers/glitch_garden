using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyPresets : MonoBehaviour
{
    /*
     * Modifying lives
     * Star count
     * Game timer
     * Enemy damage
     * Enemy health
     */

    [SerializeField] readonly static int[] STARTING_HEALTH_VALUES         = { 200, 100, 50 };
    [SerializeField] readonly static int[] STARTING_STAR_VALUES           = { 1000, 500, 250 };
    [SerializeField] readonly static float[] TIMER_MODIFIER_VALUES        = { 0.5f, 1f, 2f };
    [SerializeField] readonly static float[] ENEMY_DAMAGE_MODIFIER_VALUES = { 0.5f, 1f, 2f };
    [SerializeField] readonly static float[] ENEMY_HEALTH_MODIFIER_VALUES = { 0.5f, 1f, 2f };

    static int diff_index = (int)PlayerPrefsController.GetDifficulty();

    public static int GetStartingHealth()
    {
        return STARTING_HEALTH_VALUES[diff_index];
    }

    public static int GetStartingMoney()
    {
        return STARTING_STAR_VALUES[diff_index];
    }

    public static float GetTimerMod()
    {
        return TIMER_MODIFIER_VALUES[diff_index];
    }

    public static float GetEnemyDamageMod()
    {
        return ENEMY_DAMAGE_MODIFIER_VALUES[diff_index];
    }

    public static float GetEnemyHealthMod()
    {
        return ENEMY_HEALTH_MODIFIER_VALUES[diff_index];
    }
}

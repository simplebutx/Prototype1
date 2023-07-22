using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateSystem:MonoBehaviour
{
    public enum State
    {
        NORMAL, ISCURSED, BURNING, FROZEN
    }
    public float[] cursePercentage = { 0.3f, 0.7f, 1f };
    public void CheckState(State t,float damage,Monster monster)
    {
        switch (t) 
        {
            case State.NORMAL:
                break;
            case State.ISCURSED:
                GameObject[] tempMonsters = GameObject.FindGameObjectsWithTag("Monster");
                foreach (GameObject mon in tempMonsters)
                {
                    if (mon.GetComponent<Monster>().myState.Equals(State.ISCURSED))
                    {
                        int turnDiff = DataController.instance.gameData.turn - monster.myCurseTurn;
                        try
                        {

                            if (mon.gameObject != monster.gameObject && turnDiff > 0)
                            {
                                mon.GetComponent<IMonsterCollision>().UpdateHp(damage * cursePercentage[0]);
                            }
                        }
                        catch (StackOverflowException e)
                        {
                            Debug.Log("se: " + e);
                        }
                        catch (Exception e)
                        {
                            Debug.Log("e: " + e);
                            Debug.Log(tempMonsters.Length);
                        }
                    }
                }
                break;
            case State.BURNING:
                tempMonsters = GameObject.FindGameObjectsWithTag("Monster");
                if (monster.myBurningTurn > 0)
                {
                    monster.myBurningTurn -= 1;
                    monster.GetComponent<IMonsterCollision>().UpdateHp(damage);
                }

                break;
            case State.FROZEN:
                break;
            default:
                break;
                   
        }
    }
}


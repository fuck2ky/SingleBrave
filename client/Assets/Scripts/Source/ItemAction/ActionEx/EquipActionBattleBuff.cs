﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//  EquipActionBattleBuff.cs
//  Author: Lu Zexi
//  2014-01-21



/// <summary>
/// 战斗装备action BUFF
/// </summary>
public class EquipActionBattleBuff : CAction
{
    private BATTLE_BUF m_eBUFF; //BUFF
    private int m_iRound;   //回合
    private float m_fArg;   //参数

    public EquipActionBattleBuff(int id, int actionType, int runType)
        : base(id, actionType, runType)
    { 
        //
    }

    /// <summary>
    /// 执行
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public override ACTION_ERROR_CODE Excute(ActionInput input)
    {
        BattleHeroEquipActionInput aInput = (BattleHeroEquipActionInput)input;

        BattleHero hero = aInput.GetBattleHero();
        hero.BUFAdd(this.m_eBUFF, this.m_iRound, this.m_fArg);

        return ACTION_ERROR_CODE.NONE;
    }

    /// <summary>
    /// 读取数据
    /// </summary>
    /// <param name="lst"></param>
    /// <param name="index"></param>
    public override void Read(List<string> lst, ref int index)
    {
        this.m_eBUFF = (BATTLE_BUF)int.Parse(lst[index++]);
        this.m_iRound = int.Parse(lst[index++]);
        this.m_fArg = float.Parse(lst[index++]);
    }

}

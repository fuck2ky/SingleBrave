﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base;
using Game.Network;
using Game.Resource;

//  AccountAutoRegistHandle.cs
//  Author: Lu Zexi
//  2013-11-14




/// <summary>
/// 自动注册请求应答句柄
/// </summary>
public class AccountAutoRegistHandle
{
    /// <summary>
    /// 获取Action
    /// </summary>
    /// <returns></returns>
    public static string GetAction()
    {
        return PACKET_DEFINE.AUTO_REGIST_REQ;
    }

    /// <summary>
    /// 执行句柄
    /// </summary>
    /// <param name="packet"></param>
    /// <returns></returns>
    public static void Excute(HTTPPacketAck packet)
    {
        AccountAutoRegistPktAck ack = (AccountAutoRegistPktAck)packet;
        GAME_LOG.LOG("code :" + ack.header.code);
        GAME_LOG.LOG("desc :" + ack.header.desc);
        GAME_LOG.LOG("data userName : " + ack.m_strUsrName);
        GAME_LOG.LOG("data password : " + ack.m_strPassword);

        GUI_FUNCTION.LOADING_HIDEN();

        if (ack.header.code != 0)
        {
            GUI_FUNCTION.MESSAGEL(null, ack.header.desc);
            return;
        }

        GAME_DEFINE.s_strToken = ack.m_strToken;

        GAME_SETTING.s_strUserName = ack.m_strUsrName;
        GAME_SETTING.s_strPassWord = ack.m_strPassword;
        GAME_SETTING.s_bAccountBound = false;
        GAME_SETTING.s_iUID = ack.m_iUid;
        GAME_SETTING.SaveSetting();

        SendAgent.SendVersionReq();

        return;
    }
}

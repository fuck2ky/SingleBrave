using Game.Base;
using UnityEngine;

//  PlatformManager.cs
//  Author: Lu Zexi
//  2014-01-22



/// <summary>
/// 平台管理
/// </summary>
public class PlatformManager : Singleton<PlatformManager>
{
    private PlatformBase platform;
    public PlatformBase Platform
    {
        get { return platform; }
    }

    //public static int PLATFORM_TYPE = 0;

    public PlatformManager()
    {

#if IOS_SINGLE
        platform = new PlatformIOSSingle();
#endif
#if IOS
        platform = new PlatformForIOS();
#endif
#if IOSPP
        platform = new PlatformPPIOS();
#endif
#if ANDROID
        platform = new PlatformForIOS();
#endif

    }

    /// <summary>
    /// 获取设备号
    /// </summary>
    /// <returns></returns>
    public string GetDeviceID()
    {
        if (platform == null) return "";

        return platform.GetDeviceID();
    }

    /// <summary>
    /// 获取渠道号
    /// </summary>
    /// <returns></returns>
    public string GetChannelName()
    {
        if (platform == null) return "";

        return platform.GetChannelName();
    }

    /// <summary>
    /// 暂停事件
    /// </summary>
    /// <param name="pause"></param>
    public void OnApplicationPause(bool pause)
    {
        if (platform == null) return;
        platform.OnApplicationPause(pause);
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        if (platform == null) return;
        platform.Init();
    }

    /// <summary>
    /// 逻辑更新
    /// </summary>
    /// <returns></returns>
    public bool Update()
    {
        if (platform == null) return false;
        return platform.Update();
    }

    /// <summary>
    /// 打开公告
    /// </summary>
    /// <param name="path"></param>
    public void OpenNotice(string path, int left, int top, int right, int bottom)
    { 
        if (platform == null) return;
        platform.OpenNotice(path, left, top, right, bottom);
    }

    /// <summary>
    /// 关闭公告
    /// </summary>
    public void CloseNotice()
    {
        if (platform == null) return;
        platform.CloseNotice();
    }

    /// <summary>
    /// 更新版本
    /// </summary>
    /// <param name="path"></param>
    public void UpdateVersion(string path)
    {
        if (platform == null) return;
        platform.UpdateVersion(path);
    }

    /// <summary>
    /// 登录
    /// </summary>
    public void Login()
    {
        if (platform == null)
            return;
        platform.Login();
    }

    /// <summary>
    /// 展示登录
    /// </summary>
    public void ShowPlatformLogin()
    {
        if (platform == null) return;
        platform.ShowLogin();
    }

    /// <summary>
    /// 展示登出
    /// </summary>
    public void ShowPlatformLoginOut()
    {
        if (platform == null) return;
        platform.ShowLogout();
    }
   

    /// <summary>
    /// 显示平台社区
    /// </summary>
    public void ShowPlatformCommunity()
    {
        if (platform == null) return;

        platform.ShowCommunity();
    }
	
	    /// <summary>
    /// 隐藏平台社区
    /// </summary>
    public void HidenPlatformCommunity()
    {
        if (platform == null) return;

        platform.HidenCommunity();
    }


    /// <summary>
    /// 显示游戏论坛
    /// </summary>
    public void ShowPlatformForum()
    {

        if (platform == null) return;

        platform.ShowForum();

    }


    /// <summary>
    /// 显示平台反馈
    /// </summary>
    public void ShowPlatformFeedback()
    {
        if (platform == null) return;
        platform.ShowFeedBack();
    }

    /// <summary>
    /// 充值界面
    /// </summary>
    public void ShowPayment(params object[] arg)
    {
        if (platform == null) return;
        platform.ShowPayment(arg);
    }

    /// <summary>
    /// 退出平台
    /// </summary>
    public void AppExit()
    {
        if (platform == null) 
            return;

        platform.AppExit();
    }

    /// <summary>
    /// 暂停
    /// </summary>
    public void AppPause()
    {
        if (platform == null) return;
        platform.AppPause();
    }


    /// <summary>
    /// 平台登录的回调
    /// </summary>
    public void PlatformLoginCallBack(string arg)//(uid,sessionid,name)
    {
        if (platform == null) return;
        platform.OnLoginCallBack(arg);
    }

    /// <summary>
    /// 玩家取消了登录回调接口
    /// </summary>
    /// <param name="arg"></param>
    public void PlatformLoginCancelCallBack(string arg)
    {
        if (platform == null) return;
        platform.OnLoginCancelCallBack(arg);
    }

    /// <summary>
    /// 登出成功回调
    /// </summary>
    public void PlatformLogoutSuccess()
    {
        if (platform == null) return;
        platform.OnLogoutSuccessCallBack();
    }

    /// <summary>
    /// 登出失败回调
    /// </summary>
    public void PlatformLoginOutFail()
    {
        if (platform == null) return;
        platform.OnLogoutFailCallBack();

    }

    /// <summary>
    /// 付款成功回调
    /// </summary>
    /// <param name="arg"></param>
    public void OnPaymentSuccessCallBack(string arg)
    {
        if (platform == null) return;
        platform.OnPaymentSuccessCallBack(arg);
    }

    /// <summary>
    /// 付款失败
    /// </summary>
    /// <param name="arg"></param>
    public void OnPaymentFailCallBack(string arg)
    {
        if (platform == null) return;
        platform.OnPaymentFailCallBack(arg);
    }

    /// <summary>
    /// 切换帐号回调
    /// </summary>
    /// <param name="arg"></param>
    public void PlatformSwitchAccountCallBack(string arg)
    {
        if (platform == null) return;
        platform.SwitchAccountCallBack(arg);
    }
}

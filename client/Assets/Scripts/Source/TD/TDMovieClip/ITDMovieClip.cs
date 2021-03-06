using System;
using UnityEngine;
using Game.Base;

/// <summary>
/// 动画元素
/// </summary>
public interface ITDMovieClip
{
	void Play(string name, TDAnimationMode mode, float speed);  //播放动画
	bool Update();                                              //逻辑更新
	void Stop();                                                //停止动画
    void SetLocalPos(Vector3 position);                              //设置坐标
	void SetParent(Transform parent);                           //设置父级
	bool IsPlay();                                              //是否正在播放
    bool IsPlay(string aniName);                                //是否正在播放某动作
    float GetAlpha();                                           //获取透明度
    void SetAlpha(float alpha);                                 //设置透明度
    void SetDepth(int depth);                                   //设置渲染深度
    void Destroy();                                             //销毁
}



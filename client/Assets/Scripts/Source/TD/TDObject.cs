using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Base;

//  TDObject.cs
//  Author: Lu Zexi
//  2012-11-15


/// <summary>
/// 2D渲染物体抽象类
/// </summary>
public abstract class TDObject : ITDObject
{
	protected List<ITDMovieClip> m_lstTDMoveClip;  //影片剪辑列表
	protected Transform m_cTransform;              //当前物体
	protected Transform m_cParent;                 //父级物体
	protected UIAtlas m_cAtlas;                    //图片资源集合
    private GameObject m_cTDObj;
    public GameObject TDObj
    {
        get { return m_cTDObj; }
        set { m_cTDObj = value; }
    }
	
	//must have a uiatlas
	public  TDObject (Transform parent,UIAtlas atlas)
	{
		//create TD GameObject
        m_cTDObj = new GameObject("TD");
        m_cTransform = m_cTDObj.transform;
		//set parent
		m_cTransform.parent = parent;
		//set local transform
		m_cTransform.localScale = Vector3.one;
		m_cTransform.localPosition = Vector3.zero;
		m_cTransform.rotation = Quaternion.identity;
		
		m_cParent = parent;
		m_cAtlas = atlas;
		m_lstTDMoveClip = new List<ITDMovieClip>();
	}

	/// <summary>
	/// Initialize this instance.
	/// must use CreateAnimationGameObjAndUIsprite to create MovieClip 
	/// </summary>
	/// 
	protected abstract void Initialize();


    /// <summary>
    /// 销毁
    /// </summary>
    public void Destory()
    {
        foreach (ITDMovieClip item in this.m_lstTDMoveClip)
        {
            item.Destroy();
        }
        if (m_cTransform != null) GameObject.Destroy(this.m_cTransform.gameObject);
        this.m_lstTDMoveClip.Clear();
    }

	/// <summary>
	/// 设置坐标
	/// </summary>
	/// <param name="position"></param>
    public virtual void SetLocalPos(Vector3 position)
	{
		m_cTransform.transform.localPosition = position;
	}

    /// <summary>
    /// 设置2维相对坐标
    /// </summary>
    /// <param name="pos"></param>
    public virtual void SetLocalPos(Vector2 pos)
    {
        Vector3 tmpPos = new Vector3(pos.x, pos.y, this.m_cTransform.transform.localPosition.z);
        this.m_cTransform.transform.localPosition = tmpPos;
    }

    /// <summary>
    /// 获取相对位置
    /// </summary>
    /// <returns></returns>
    public Vector3 GetLocalPos()
    {
        return this.m_cTransform.transform.localPosition;
    }

    /// <summary>
    /// 获取位置
    /// </summary>
    /// <returns></returns>
    public Vector3 GetPos()
    {
        return this.m_cTransform.transform.position;
    }

    /// <summary>
    /// 设置世界坐标
    /// </summary>
    /// <param name="pos"></param>
    public virtual void SetPos(Vector3 pos)
    {
        this.m_cTransform.transform.position = pos;
    }

    /// <summary>
    /// 设置2维坐标
    /// </summary>
    /// <param name="pos"></param>
    public virtual void SetPos(Vector2 pos)
    {
        Vector3 tmpPos = new Vector3(pos.x, pos.y, this.m_cTransform.transform.position.z);
        this.m_cTransform.transform.position = tmpPos;
    }
	
    /// <summary>
    /// 设置大小比率
    /// </summary>
    /// <param name="scale"></param>
	public virtual void SetLocalScale(Vector3 scale)
	{
		m_cTransform.transform.localScale = scale;
	}
	
    /// <summary>
    /// 设置父级
    /// </summary>
    /// <param name="parent"></param>
	public virtual void SetParent (UnityEngine.Transform parent)
	{
		if(this.m_cTransform != null)
		{
			this.m_cTransform.parent = parent;	
		}
	}
	
	
	/// <summary>
	///  播放动画
	/// </summary>
	/// <param name='name'>
	///  播放动画名
	/// </param>
	/// <param name='mode'>
	///  播放模式
	/// </param>
	/// <param name='fps'>
	///  播放速度
	/// </param>
	public virtual void PlayAnimation (string name, TDAnimationMode mode, float speed)
	{
		foreach(ITDMovieClip clip in m_lstTDMoveClip)
		{
            clip.Play(name, mode, speed);
		}
	}
	
	/// <summary>
	/// 增加影片剪辑
	/// </summary>
	/// <param name="movieclip"></param>
	protected void AddTDMovieClip(ITDMovieClip movieclip)
	{
        if (this.m_lstTDMoveClip == null)
            return;
        m_lstTDMoveClip.Add(movieclip);
	}
	
    /// <summary>
    /// 删除影片剪辑
    /// </summary>
    /// <param name="movieclip"></param>
	protected void RemoveTDMovieClip(ITDMovieClip movieclip)
	{
        if (this.m_lstTDMoveClip == null)
            return;
        if (this.m_lstTDMoveClip.Remove(movieclip))
        {
            movieclip.Destroy();
        }
	}

    /// <summary>
    /// 删除指定数目影片
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public virtual int RemoveMovieClipNum(int num)
    {
        int resNum = 0;
        List<ITDMovieClip> lstMovies = new List<ITDMovieClip>();
        for (int i = 0 ; i < num && i < this.m_lstTDMoveClip.Count; i++)
        {
            lstMovies.Add(this.m_lstTDMoveClip[i]);
        }
        resNum = lstMovies.Count;
        foreach (ITDMovieClip item in lstMovies)
        {
            RemoveTDMovieClip(item);
        }
        return resNum;
    }

    /// <summary>
    /// 删除指定数目影片--从后删除
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public virtual int RemoveMovieClipNumEx(int num)
    {
        int resNum = 0;
        List<ITDMovieClip> lstMovies = new List<ITDMovieClip>();
        for (int i = 0, j = this.m_lstTDMoveClip.Count - 1; i < num && i < this.m_lstTDMoveClip.Count; i++, j--)
        {
            lstMovies.Add(this.m_lstTDMoveClip[j]);
        }
        resNum = lstMovies.Count;
        foreach (ITDMovieClip item in lstMovies)
        {
            RemoveTDMovieClip(item);
        }
        return resNum;
    }

    /// <summary>
    /// 增加影片数目
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public virtual int AddMovieClipNum(int num)
    {
        for (int i = 0; i < num ; i++)
        {
            ITDMovieClip mc = new TDMovieClip(this.m_cAtlas);
            mc.SetParent(this.m_cTransform);
            AddTDMovieClip(mc);
        }
        return num;
    }


    /// <summary>
    /// 获取影片剪辑数目
    /// </summary>
    /// <returns></returns>
    public int GetMovieClipNum()
    {
        return this.m_lstTDMoveClip.Count;
    }

    /// <summary>
    /// 获取影片剪辑最大数目
    /// </summary>
    /// <returns></returns>
    public abstract int GetMovieClipMaxNum();
	
    /// <summary>
    /// 逻辑更新
    /// </summary>
	public void Update()
    {
        foreach (ITDMovieClip item in this.m_lstTDMoveClip)
		{
			item.Update();
		}
	}
	
	
	/// <summary>
	/// all movie clip is end return false
	/// else return true.
	/// </summary>
	/// <returns>
	/// The play.
	/// </returns>
	public bool IsPlay()
	{
		foreach(ITDMovieClip clip in m_lstTDMoveClip)
		{
			if(clip.IsPlay())
			{
				return true;
			}
		}
		return false;
	}

    /// <summary>
    /// 是否正在播放指定动作
    /// </summary>
    /// <param name="aniName"></param>
    /// <returns></returns>
    public bool IsPlay(string aniName)
    {
        foreach (ITDMovieClip clip in m_lstTDMoveClip)
        {
            if (clip.IsPlay(aniName))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 设置透明度
    /// </summary>
    /// <returns></returns>
    public void SetAlpha( float alpha )
    {
        foreach (ITDMovieClip item in this.m_lstTDMoveClip)
        {
            item.SetAlpha(alpha);
        }
    }

}



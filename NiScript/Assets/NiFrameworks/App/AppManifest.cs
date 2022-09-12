using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManifest
{
    public string appid;
    /// <summary>
    /// [必填]应用包名，确认与原生应用的包名不一致，推荐采用 com.company.module 的格式，如：com.example.demo
    /// </summary>
    public string package;
    /// <summary>
    /// [必填]应用名称，6 个汉字以内，与应用商店保存的名称一致，用于在界面图标、弹窗等处显示应用名称
    /// </summary>
    public string name;
    /// <summary>
    /// [必填]应用图标，提供 192x192 大小的即可
    /// </summary>
    public string icon;

    /// <summary>
    /// 应用版本名称，如："1.0"
    /// </summary>
    public string versionName;

    /// <summary>
    /// [必填]应用版本号，从1自增，推荐每次重新上传包时versionCode+1
    /// </summary>
    public int versionCode;

    /// <summary>
    /// 支持的最小平台版本号，兼容性检查，避免上线后在低版本平台运行并导致不兼容；如果不填按照内测版本处理
    /// Home 平台Host运行时版本
    /// </summary>
    public int minPlatformVersion;

    public static AppManifest Load(string manifestfile)
    {

        //JsonUtility.FromJson<AppManifest>();
        return null;
    }


    public override string ToString()
    {
        return string.Format("id:{0} name:{1} package:{2}:{3}", appid,name, package,versionName);
    }
}

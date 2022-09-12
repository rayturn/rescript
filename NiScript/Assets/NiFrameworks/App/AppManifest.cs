using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManifest
{
    public string appid;
    /// <summary>
    /// [����]Ӧ�ð�����ȷ����ԭ��Ӧ�õİ�����һ�£��Ƽ����� com.company.module �ĸ�ʽ���磺com.example.demo
    /// </summary>
    public string package;
    /// <summary>
    /// [����]Ӧ�����ƣ�6 ���������ڣ���Ӧ���̵걣�������һ�£������ڽ���ͼ�ꡢ�����ȴ���ʾӦ������
    /// </summary>
    public string name;
    /// <summary>
    /// [����]Ӧ��ͼ�꣬�ṩ 192x192 ��С�ļ���
    /// </summary>
    public string icon;

    /// <summary>
    /// Ӧ�ð汾���ƣ��磺"1.0"
    /// </summary>
    public string versionName;

    /// <summary>
    /// [����]Ӧ�ð汾�ţ���1�������Ƽ�ÿ�������ϴ���ʱversionCode+1
    /// </summary>
    public int versionCode;

    /// <summary>
    /// ֧�ֵ���Сƽ̨�汾�ţ������Լ�飬�������ߺ��ڵͰ汾ƽ̨���в����²����ݣ����������ڲ�汾����
    /// Home ƽ̨Host����ʱ�汾
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

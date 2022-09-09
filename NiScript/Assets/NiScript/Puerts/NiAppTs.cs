using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiAppTs : MonoBehaviour
{
    Puerts.JsEnv jsEnv;
    public TextAsset tsScript;

    void Awake()
    {
        jsEnv = new Puerts.JsEnv();
        jsEnv.Eval(tsScript.text);

    }
        // Start is called before the first frame update
    void Start()
    {
        if(jsEnv!=null)
            jsEnv.Eval("start();");
    }

    // Update is called once per frame
    void Update()
    {
        if (jsEnv != null)
            jsEnv.Eval("update();");
    }
}

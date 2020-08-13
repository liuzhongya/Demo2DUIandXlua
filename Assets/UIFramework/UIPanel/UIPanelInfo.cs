using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class UIPanelInfo:ISerializationCallbackReceiver {

    [NonSerialized]
    public UIPanelType panelType;
    public String panelTypeString;
    //{
    //    //get
    //    //{
    //    //    return panelType.ToString();

    //    //}
    //    //set
    //    //{
    //    //    UIPanelType type = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), value);
    //    //    panelType = type;
    //    //}
    //}
    
    public string path;

    public void OnBeforeSerialize()  //反序列化qian打开
    {
         
    }

    public void OnAfterDeserialize() //反序列化后打开
    {
        UIPanelType type = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelTypeString);
       panelType = type;
    }
}

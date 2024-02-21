using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexIntCmdBroadcastMono : MonoBehaviour
{

    static IndexIntCmdDelegate.Interface m_onCommandInterfaceReceived;
    static IndexIntCmdDelegate.Int m_onCommandIntReceived;
    public void Broadcast(I_IndexIntCmdGet command)
    {
        if (command == null)
            return;

        if(m_onCommandIntReceived!=null)
        m_onCommandIntReceived.Invoke(command.GetIndexInt());

        if (m_onCommandInterfaceReceived != null)
        m_onCommandInterfaceReceived.Invoke(command);
    }


    public static void AddListener(IndexIntCmdDelegate.Interface listener) { m_onCommandInterfaceReceived += listener; }
    public static void AddListener(IndexIntCmdDelegate.Int listener) { m_onCommandIntReceived += listener; }
    public static void RemoveListener(IndexIntCmdDelegate.Interface listener) { m_onCommandInterfaceReceived -= listener; }
    public static void RemoveListener(IndexIntCmdDelegate.Int listener) { m_onCommandIntReceived -= listener; }


    public IndexIntCmdUnityEvent.Interface m_onIntCmdReceivedInterface;
    public IndexIntCmdUnityEvent.Int m_onIntCmdReceivedInt;

    private void Awake()
    {

        m_onCommandInterfaceReceived -= BroadcastReceived;
        m_onCommandIntReceived -= BroadcastReceived;
        m_onCommandInterfaceReceived += BroadcastReceived;
        m_onCommandIntReceived += BroadcastReceived;

    }
    private void OnEnable()
    {

        m_onCommandInterfaceReceived -= BroadcastReceived;
        m_onCommandIntReceived -= BroadcastReceived;
        m_onCommandInterfaceReceived += BroadcastReceived;
        m_onCommandIntReceived += BroadcastReceived;

    }
    private void OnDisable()
    {

        m_onCommandInterfaceReceived -= BroadcastReceived;
        m_onCommandIntReceived -= BroadcastReceived;
    }

    private void BroadcastReceived(I_IndexIntCmdGet intCommandInterface)
    {
        m_onIntCmdReceivedInterface.Invoke(intCommandInterface);
    }
    private void BroadcastReceived(int intCommand)
    {
        m_onIntCmdReceivedInt.Invoke(intCommand);
    }
   
}



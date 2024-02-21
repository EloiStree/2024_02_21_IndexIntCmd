﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class IndexIntCmdUnityThreadRelayMono : MonoBehaviour{

    public UDPReceiverIndexIntCmdMono m_source;

    public Queue<I_IndexIntCmdGet> m_inQueue = new Queue<I_IndexIntCmdGet>();
    public UnityEvent<I_IndexIntCmdGet> m_onReceived = new UnityEvent<I_IndexIntCmdGet>();
    private void Awake()
    {
        m_source.m_onSharpIndexInterfaceIntCmd += PushInQueue;
    }
    public void PushInQueue(I_IndexIntCmdGet intCmd)
    {
        IndexIntCmdStruct value = new IndexIntCmdStruct();
        value.Set(intCmd);
        m_inQueue.Enqueue(value);
    }
    public void Update()
    {
        while (m_inQueue.Count>0) {
            m_onReceived.Invoke(m_inQueue.Dequeue());
        }
    }
    public void LogReceivedIndexIntergerCommand(I_IndexIntCmdGet command)
    {

        Debug.Log("Received Index:" + command.GetIndexInt() + " Integers:" + command.GetCommandInt());
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexIntCmdRelayMono : MonoBehaviour
{

    public IndexIntCmdStruct m_lastReceived;

    public IndexIntCmdUnityEvent.Interface m_onRelayed;

    public void PushIn(I_IndexIntCmdGet command) {

        m_lastReceived.Set(command);
        m_onRelayed.Invoke(command);
    }
}


public class IndexIntCmdMono : MonoBehaviour
{

    public IndexIntCmdRef m_lastReceived;
    public void PushIn(I_IndexIntCmdGet command)
    {
        m_lastReceived.Set(command);
    }
}


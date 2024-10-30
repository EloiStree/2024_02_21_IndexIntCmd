using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi.IID
{
    public class IndexIntCmdMonoRefRelayMono : MonoBehaviour
    {

        public IndexIntCmdUnityEvent.InterfaceGet m_onRelay;
        public IndexIntCmdMono m_toRelay;


        [ContextMenu("Relay")]
        public void Relay()
        {
            m_onRelay.Invoke(m_toRelay);
        }
    }
}
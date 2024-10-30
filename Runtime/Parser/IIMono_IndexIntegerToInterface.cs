using UnityEngine;
using UnityEngine.Events;


namespace Eloi.IID
{
    public class IIMono_IndexIntegerToInterface : MonoBehaviour
    {
        public UnityEvent<I_IndexIntCmdGet> m_onIndexValueReceived;
        public void PushIn(int index, int value)
        {
            IndexIntCmdStruct valueCmd = new IndexIntCmdStruct();
            valueCmd.Set(index, value);
            m_onIndexValueReceived.Invoke(valueCmd);
        }
    }

}
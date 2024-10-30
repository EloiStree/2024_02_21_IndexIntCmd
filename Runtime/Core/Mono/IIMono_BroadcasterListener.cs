using UnityEngine;

namespace Eloi.IID
{
    /// <summary>
    /// I am class that can listen to the static broadcast of I_IndexIntCmdGet and trigger events when it is received.
    /// </summary>
    public class IIMono_BroadcasterListener : MonoBehaviour
    {
        public IndexIntCmdUnityEvent.InterfaceGet m_onIntCmdReceivedInterface;
        public IndexIntCmdUnityEvent.Integer m_onIntCmdReceivedInt;
        public IndexIntCmdUnityEvent.IndexInteger m_onIndexCommandInt;

        [Header("Debug")]
        public int m_lastIndex = 0;
        public int m_lastValue = 0;

        private void Awake()
        {
            SubscribeToTheBroadcast();

        }
        private void OnEnable()
        {
            SubscribeToTheBroadcast();
        }

        private void SubscribeToTheBroadcast()
        {
            IIMono_Broadcaster.RemoveListener(BroadcastReceived);
            IIMono_Broadcaster.AddListener(BroadcastReceived);
        }


        private void OnDisable()
        {
            UnsubscribeToTheBroadcast();
        }

        private void UnsubscribeToTheBroadcast()
        {
            IIMono_Broadcaster.RemoveListener(BroadcastReceived);
        }

        private void BroadcastReceived(I_IndexIntCmdGet intCommandInterface)
        {
            m_onIntCmdReceivedInterface.Invoke(intCommandInterface);
            if (intCommandInterface != null)
            {
                m_lastIndex = intCommandInterface.GetIndexInt();
                m_lastValue = intCommandInterface.GetCommandInt();
                m_onIntCmdReceivedInt.Invoke(intCommandInterface.GetCommandInt());
                m_onIndexCommandInt.Invoke(intCommandInterface.GetIndexInt(), intCommandInterface.GetCommandInt());
            }
        }
    }
}



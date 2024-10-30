using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Eloi.IID
{

    /// <summary>
    /// I am a classe that convert and diffuse bytes from 4 8 16 size to integer value to be used in game
    /// </summary>
    public class IIMono_ByteToIndexInteger : MonoBehaviour
    {

        public UnityEvent<int, int> m_onIndexValueReceived;

        [Header("Received integer without index ")]
        [Tooltip("Allow to use 4 bytes integer in game as a player")]
        public bool m_allow4BytesInput = true;
        public int m_indexOf4BytesIntegerInput = int.MinValue;

        [Header("Received dated integer with index ")]
        [Tooltip("Will usee IID but ignore the Date that is 8 bytes long")]
        public bool m_allow16BytesIidInput = true;

        [Header("Debug")]
        public int m_lastIndex;
        public int m_lastValue;

        public void PushIn(byte[] bytes) { 
    
            if(bytes==null)
            {
                return;
            }   

            if(bytes.Length<4)
            {
                return;
            }

            int index, value;
            if (m_allow4BytesInput && bytes.Length == 4)
            {
                index = m_indexOf4BytesIntegerInput;
                value = System.BitConverter.ToInt32(bytes, 0);
                m_lastIndex = index;
                m_lastValue = value;
                m_onIndexValueReceived.Invoke(index,value);
            }
            else if (m_allow16BytesIidInput && bytes.Length == 16)
            {
                index = System.BitConverter.ToInt32(bytes, 0);
                value = System.BitConverter.ToInt32(bytes, 4);
                m_lastIndex = index;
                m_lastValue = value;
                m_onIndexValueReceived.Invoke(index, value);
            }
            else if (bytes.Length == 8)
            {
                index = System.BitConverter.ToInt32(bytes, 0);
                value = System.BitConverter.ToInt32(bytes, 4);
                m_lastIndex = index;
                m_lastValue = value;
                m_onIndexValueReceived.Invoke(index, value);
            }

        }
    }

}
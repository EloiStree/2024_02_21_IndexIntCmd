using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IID
{
    /// <summary>
    ///  A class that can broadcast an I_IndexIntCmdGet to all the listeners in the game that are listening to the event.
    /// </summary>
    public class IIMono_Broadcaster : MonoBehaviour
    {
        static IndexIntCmdDelegate.InterfaceGet m_onCommandInterfaceReceived;
        public void Broadcast(I_IndexIntCmdGet command)
        {
            if (command == null)
                return;
            if (m_onCommandInterfaceReceived != null)
                m_onCommandInterfaceReceived.Invoke(command);
        }
        public static void AddListener(IndexIntCmdDelegate.InterfaceGet listener) { m_onCommandInterfaceReceived += listener; }
        public static void RemoveListener(IndexIntCmdDelegate.InterfaceGet listener) { m_onCommandInterfaceReceived -= listener; }

        [ContextMenu("Send random input for testing")]
        public void BraodcastRandomValueForTesting()
        {
            IndexIntCmdStruct s = new IndexIntCmdStruct();
            s.SetIndexInt(UnityEngine.Random.Range(int.MinValue,int.MaxValue));
            s.SetCommandInt(UnityEngine.Random.Range(int.MinValue, int.MaxValue));
            Broadcast(s);
        }
    }
}



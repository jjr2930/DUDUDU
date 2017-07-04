
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;

namespace JLib
{
    public static class NetworkObjectManagerBase 
    {
        const long GLOBAL_ID = long.MinValue;
        static Dictionary<long, Dictionary<Enum, UnityAction<object>>> listeners
        = new Dictionary<long, Dictionary<Enum, UnityAction<object>>>();

        static NetworkObjectManagerBase()
        {
            GlobalEventQueue.RegisterListener( DefaultEvent.NetworkEvent, ListenNetworkMessage );
        }

        public static void RegistListener(long id, Enum eventName, UnityAction<object> listener)
        {
            if ( !listeners.ContainsKey( id ) )
            {
                listeners.Add( id, new Dictionary<Enum, UnityAction<object>>() );
            }

            listeners[id][eventName] += listener;
        }

        public static void RemoveListener(long id , Enum eventName, UnityAction<object> listener)
        {
            if(!listeners.ContainsKey(id))
            {
                UnityEngine.Debug.LogFormat( "NetworkObjectManger.RemoveListener => not contained in listeners id : {1}, eventName : {2}, listener : {3}",
                    id, eventName, listener );
                return;
            }

            if ( !listeners[id].ContainsKey( eventName ) )
            {
                UnityEngine.Debug.LogFormat( "NetworkObjectManger.RemoveListener => not contained in listeners id : {1}, eventName : {2}, listener : {3}",
                 id, eventName, listener );
                return;
            }

            listeners[id][eventName] -= listener;
        }


        /// <summary>
        /// 네트워크 메시지를 듣는 리스너
        /// </summary>
        /// <param name="param"></param>
        public static void ListenNetworkMessage( object param )
        {
            NetworkCommandBase  p           = param as NetworkCommandBase;
            UnityAction<object> method      = null;
            long                id          = p.networkID;

            Dictionary<Enum, UnityAction<object>> foundedObject = null;

            if ( listeners.TryGetValue( id, out foundedObject ) )
            {
                if ( foundedObject.TryGetValue( p.eventName, out method ) )
                {
                    method.Invoke( p.value );
                }
            }
        }
    }
}
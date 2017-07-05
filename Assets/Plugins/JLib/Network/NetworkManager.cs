using UnityEngine.Events;
using System.Collections;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace JLib
{
    /// <summary>
    /// 쓰레드를 만든다.
    /// </summary>
    public static class NetworkManager
    {
        static Socket socket = null;
        static NetworkManager()
        {
            //소켓 생성
            socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
        }

        public static void ConnectToServer()
        {

        }

        public static void ReqNoResponse( ref System.ValueType value )
        {
            //전송 부분
            byte[] plainBytes = CryptoGraphyHelper.GetByteFromStruct( value );
            byte[] cipherBytes = CryptoGraphyHelper.GetCipherByte( plainBytes );

            socket.Send( cipherBytes );
        }

        public static void ReqUntilResponse<T>( ref T value, UnityAction<object> successCallback, UnityAction<object> failCallback) where T : struct 
        {
            //전송
            byte[] plainBytes = CryptoGraphyHelper.GetByteFromStruct( value );
            byte[] cipherBytes = CryptoGraphyHelper.GetCipherByte( plainBytes );

            SocketAsyncEventArgs asyncObject = new SocketAsyncEventArgs();
            asyncObject.Completed += AsyncObject_Completed;
            //socket.SendAsync( cipherBytes );
        }

        private static void AsyncObject_Completed( object sender, SocketAsyncEventArgs e )
        {
            throw new System.NotImplementedException();
        }
    }
}
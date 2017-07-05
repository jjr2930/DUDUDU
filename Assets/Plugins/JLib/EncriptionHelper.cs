using UnityEngine;
using System.Security.Cryptography;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;
using System;

namespace JLib
{
    /// <summary>
    /// 암호화를 위한 여러가지 유틸리티를 함수를 제공하는 클래스
    /// </summary>
    public static class CryptoGraphyHelper
    {
        static ICryptoTransform encryptorInstance = null;
        static ICryptoTransform decryptorInstance = null;

        /// <summary>
        /// 이 키값들의 은닉성을 고려해야함.. 어떻게 관리할지...
        /// </summary>
        const string _IV_ = "slkdfjklsdfjsdjfds";
        const string _KEY_ = "slfjsdfkjsdkflsdf";

        static CryptoGraphyHelper()
        {
            Aes     AESInstance     = Aes.Create();
            SHA256  SHA256Instance  = SHA256.Create();

            AESInstance.KeySize = 256;
            AESInstance.IV = SHA256Instance.ComputeHash( Encoding.UTF8.GetBytes( _IV_ ) );
            AESInstance.Key = SHA256Instance.ComputeHash( Encoding.UTF8.GetBytes( _KEY_ ) );
            AESInstance.Padding = PaddingMode.PKCS7;
            AESInstance.Mode = CipherMode.ECB;

            encryptorInstance = AESInstance.CreateEncryptor();
            decryptorInstance = AESInstance.CreateDecryptor();
        }

        public static byte[] GetByteFromStruct<T>( T targetStruct )
        {
            int size = Marshal.SizeOf(targetStruct);
            byte[] bytes = new byte[size];

            IntPtr ptr=  Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr( targetStruct, ptr, true );
            Marshal.Copy( ptr, bytes, 0, size );
            Marshal.FreeHGlobal( ptr );
            return bytes;
        }

        public static T GetStructFromByte<T>( byte[] bytes ) where T : new()
        {
            T str = new T();

            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy( bytes, 0, ptr, size );

            str = ( T )Marshal.PtrToStructure( ptr, str.GetType() );
            Marshal.FreeHGlobal( ptr );

            return str;
        }

        public static byte[] GetCipherByte( byte[] plainByte )
        {
            //encode utf8
            byte[] cipherByte = encryptorInstance.TransformFinalBlock( plainByte, 0, plainByte.Length );
            return cipherByte;
        }

        public static byte[] GetPlainByte( byte[] cipherText )
        {
            byte[] plainByte = decryptorInstance.TransformFinalBlock(cipherText,0, cipherText.Length);
            return plainByte;
        }

    }
}
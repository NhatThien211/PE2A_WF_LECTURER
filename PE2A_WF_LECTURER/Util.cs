using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;
using SharpCompress.Archives;
using SharpCompress.Archives.Zip;
using System.IO;
using System.Security.Cryptography;

namespace PE2A_WF_Lecturer
{
    public class Util
    {
        public static void SendBroadCast(string message, int receiverListeningPort)
        {
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Broadcast, receiverListeningPort);
            Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            byte[] bytes = Encoding.ASCII.GetBytes(message);
            clientSock.SetSocketOption(SocketOptionLevel.Socket,
            SocketOptionName.Broadcast, 1);
            clientSock.SendTo(bytes, ipEnd);
            clientSock.Close();
        }

        private static Socket listeningSocket;
        public static string GetMessageFromTCPConnection(int listeningPort, int maximumRequest)
        {
            listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            byte[] buffer = new byte[1024];
            IPEndPoint senders = new IPEndPoint(IPAddress.Any, listeningPort);
            listeningSocket.Bind(senders);
            listeningSocket.Listen(maximumRequest);
            Socket conn = listeningSocket.Accept();
            int size = conn.Receive(buffer);
            ASCIIEncoding eEncpding = new ASCIIEncoding();
            string receivedMessage = eEncpding.GetString(buffer);
            listeningSocket.Close();
            return receivedMessage.Substring(0, size);
        }

        private static Socket listeningSockets;
        public static string GetMessageFromTCPConnections(int listeningPort, int maximumRequest)
        {
            listeningSockets = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            byte[] buffer = new byte[1024];
            IPEndPoint senders = new IPEndPoint(IPAddress.Any, listeningPort);
            listeningSockets.Bind(senders);
            listeningSockets.Listen(maximumRequest);
            Socket conn = listeningSockets.Accept();
            int size = conn.Receive(buffer);
            ASCIIEncoding eEncpding = new ASCIIEncoding();
            string receivedMessage = eEncpding.GetString(buffer);
            listeningSockets.Close();
            return receivedMessage.Substring(0, size);
        }

        public static IPAddress GetLocalIPAddress()
        {
            string hostName = Dns.GetHostName();
            string ip = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return IPAddress.Parse(ip);
        }
        public static string receiveMessage(byte[] bytes)
        {
            string message = System.Text.Encoding.Unicode.GetString(bytes);

            string messageToPrint = null;
            foreach (var nullChar in message)
            {
                if (nullChar != '\0')
                {
                    messageToPrint += nullChar;
                }
            }
            return messageToPrint;
        }
        public static void sendMessage(byte[] bytes, TcpClient client)
        {
            // Client must be connected to   
            client.GetStream() // Get the stream and write the bytes to it  
                  .Write(bytes, 0,
                  bytes.Length); // Send the stream  
            
        }
        public static void UnarchiveFile(string filePath, string destDirectory)
        {
            string filenameExtension = Path.GetExtension(filePath);

            if (Directory.Exists(destDirectory))
            {
                if (filenameExtension.Equals(Constant.ZIP_EXTENSION, StringComparison.OrdinalIgnoreCase))
                {
                    using (var zipArchive = ZipArchive.Open(filePath))
                    {
                        foreach (var entry in zipArchive.Entries)
                        {
                            entry.WriteToDirectory(destDirectory, new ExtractionOptions()
                            {
                                Overwrite = true,
                                ExtractFullPath = true,
                            });
                        }
                    }
                }
                else if (filenameExtension.Equals(Constant.RAR_EXTENSION, StringComparison.OrdinalIgnoreCase))
                {
                    using (var rarArchive = RarArchive.Open(filePath))
                    {
                        foreach (var entry in rarArchive.Entries)
                        {
                            entry.WriteToDirectory(destDirectory, new ExtractionOptions()
                            {
                                Overwrite = true,
                                ExtractFullPath = true,
                            });
                        }
                    }
                }
            }
        }

        private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] keyBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(keyBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
        public static string Encode(string plainText, string key)
        {
            if (plainText == null)
            {
                return null;
            }

            if (key == null)
            {
                key = String.Empty;
            }

            // Get the bytes of the string
            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(plainText);
            var keyBytes = Encoding.UTF8.GetBytes(key);

            // Hash the key with SHA256
            keyBytes = SHA256.Create().ComputeHash(keyBytes);

            var bytesEncrypted = Encrypt(bytesToBeEncrypted, keyBytes);

            return Convert.ToBase64String(bytesEncrypted);
        }

        public static string GetProjectDirectory()
        {
            /*
            * 
            * This block is for local test (IDE test)
            * 
            */

            var appDomainDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            var projectNameDir = Path.GetFullPath(Path.Combine(appDomainDir, @"..\.."));

            /*
             * 
             * This block is for release app
             * 
             */

            //var projectNameDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            return projectNameDir;
        }
    }
}

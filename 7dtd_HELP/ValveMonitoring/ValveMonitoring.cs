using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _7dtd_HELP.ValveMonitoring
{
    internal static class ValveMonitoring
    {
        public static string ByteArrayToString(byte[] ba)
        {
            var hex = BitConverter.ToString(ba);

            return hex.Replace("-", "");
        }

        public static byte[] SubArray(byte[] data, int index, int length)
        {
            var result = new byte[length];
            Array.Copy(data, index, result, 0, length);

            return result;
        }

        internal static A2SInfo GetA2S_INFO(string ip, string port, out string logtext)
        {
            var ep = new IPEndPoint(IPAddress.Parse(ip), int.Parse(port));
            try
            {
                var client = new UdpClient
                {
                    Client =
                    {
                        SendTimeout = 500,
                        ReceiveTimeout = 500
                    }
                };
                client.Connect(ep);

                var rBytes = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x54, 0x53, 0x6F, 0x75, 0x72, 0x63, 0x65, 0x20, 0x45, 0x6E, 0x67, 0x69, 0x6E, 0x65, 0x20, 0x51, 0x75, 0x65, 0x72, 0x79, 0x00 };
                client.Send(rBytes, rBytes.Length);

                // then receive data
                var receivedData = client.Receive(ref ep);

                //System.Text.Encoding.UTF8.GetString(receivedData)
                client.Close();
                var info = new A2SInfo(receivedData);

                logtext = $"{ByteArrayToString(receivedData)}{Environment.NewLine}";
                return info;
            }
            catch (Exception ex)
            {
                logtext = $"ERROR:{Environment.NewLine}{ex.Message}";
            }
            return null;
        }


        internal static int IndexOf(byte[] data, byte b, int start = 0)
        {
            var i = -1;
            for (var j = start; j < data.Length; j++)
                if (data[j] == b)
                {
                    i = j;
                    break;
                }
            return i;
        }

        internal static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }

        internal static string GetServerStats(string ip, string port, out string logtext)
        {
            byte[] receivedData2;

            try
            {
                var ep = new IPEndPoint(IPAddress.Parse(ip), int.Parse(port));
                var client = new UdpClient
                {
                    Client =
                    {
                        SendTimeout = 500,
                        ReceiveTimeout = 500
                    }
                };
                client.Connect(ep);
                var a2SRules = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x56, 0xFF, 0xFF, 0xFF, 0xFF };
                client.Send(a2SRules, a2SRules.Length);

                receivedData2 = client.Receive(ref ep);
                client.Close();

                logtext = $"{ByteArrayToString(receivedData2)}{Environment.NewLine}";

                //Console.Beep(250, 250);
            }
            catch (Exception ex)
            {
                logtext = $"ERROR:{Environment.NewLine}{ex.Message}";
                receivedData2 = null;
            }

            if (receivedData2 == null)
            {
                return "ERROR";
            }

            try
            {
                var ep = new IPEndPoint(IPAddress.Parse(ip), int.Parse(port));
                var client = new UdpClient
                {
                    Client =
                    {
                        SendTimeout = 500,
                        ReceiveTimeout = 500
                    }
                };
                client.Connect(ep);
                receivedData2[4] = 0x56;
                client.Send(receivedData2, receivedData2.Length);

                var bs = client.Receive(ref ep);
                client.Close();
                var bStr = ByteArrayToString(bs);
                logtext += $"{bStr}{Environment.NewLine}";

                //Console.Beep(250, 250);

                var result = "";
                byte newStat = 0;

                for (var i = 0; i < bStr.Length; i += 2)
                {
                    var b = $"{bStr[i]}{bStr[i + 1]}";
                    if (b == "00")
                    {
                        result += newStat % 2 == 0 ? $"{Environment.NewLine}" : ":";
                        newStat++;
                        continue;
                    }

                    var bh = HexStringToByteArray(b);
                    result += Encoding.UTF8.GetString(bh);
                }

                return result;
            }
            catch (Exception ex)
            {
                logtext += $"ERROR:{Environment.NewLine}{ex.Message}";
                return "ERROR";
            }
        }
    }
}
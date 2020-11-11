using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _7dtd_HELP.ValveMonitoring
{
    public class A2SInfo
    {
        readonly byte _header;
        readonly byte _protocol;
        readonly string _name;
        readonly string _map;
        readonly string _folder;
        readonly string _game;
        readonly short _id;
        public byte Players { get; set; }
        public byte MaxPlayers { get; set; }
        readonly byte _bots;
        readonly byte _serverType;
        readonly byte _environment;
        readonly byte _visibility;
        readonly byte _vac;

        public A2SInfo(byte[] bs)
        {
            var i = ValveMonitoring.IndexOf(bs, 0x49);
            _header = bs[i];
            _protocol = bs[i + 1];
            _name = Encoding.UTF8.GetString(ValveMonitoring.SubArray(bs, i + 2, ValveMonitoring.IndexOf(bs, 0x00, i + 2) - (i + 2)));
            i = ValveMonitoring.IndexOf(bs, 0x00, i + 2);
            _map = Encoding.UTF8.GetString(ValveMonitoring.SubArray(bs, i + 1, ValveMonitoring.IndexOf(bs, 0x00, i + 1) - (i + 1)));
            i = ValveMonitoring.IndexOf(bs, 0x00, i + 1);
            _folder = Encoding.UTF8.GetString(ValveMonitoring.SubArray(bs, i + 1, ValveMonitoring.IndexOf(bs, 0x00, i + 1) - (i + 1)));
            i = ValveMonitoring.IndexOf(bs, 0x00, i + 1);
            _game = Encoding.UTF8.GetString(ValveMonitoring.SubArray(bs, i + 1, ValveMonitoring.IndexOf(bs, 0x00, i + 1) - (i + 1)));
            i = ValveMonitoring.IndexOf(bs, 0x00, i + 1);
            _id = BitConverter.ToInt16(new byte[2] { bs[i + 1], bs[i + 2] }, 0);
            Players = bs[i + 3];
            MaxPlayers = bs[i + 4];
            _bots = bs[i + 5];
            _serverType = bs[i + 6];
            _environment = bs[i + 7];
            _visibility = bs[i + 8];
            _vac = bs[i + 9];
        }

        public string GetText()
        {

            var str = $"Header: {Convert.ToInt32(_header)}{Environment.NewLine}" +
                         $"Protocol: {Convert.ToInt32(_protocol)}{Environment.NewLine}" +
                         $"Name: {_name}{Environment.NewLine}" +
                         $"Map: {_map}{Environment.NewLine}" +
                         $"Folder: {_folder}{Environment.NewLine}" +
                         $"Game: {_game}{Environment.NewLine}" +
                         $"ID: {_id}{Environment.NewLine}" +
                         $"Players: {Players}{Environment.NewLine}" +
                         $"Max Players: {8}{Environment.NewLine}" +
                         $"Bots: {_bots}{Environment.NewLine}" +
                         $"Server Type: {_serverType}{Environment.NewLine}" +
                         $"Environment: {_environment}{Environment.NewLine}" +
                         $"Visibility: {_visibility}{Environment.NewLine}" +
                         $"VAC: {_vac}";

            return str;
        }
    }
}

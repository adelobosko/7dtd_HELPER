using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Media;
//using WMPLib;
using System.Runtime.InteropServices;
using static _7dtd_HELP.Win32;

namespace _7dtd_HELP
{

    public partial class Form1 : Form
    {
        GlobalKeyboardHook gHook;

        public Form1()
        {
            InitializeComponent();
            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new System.Windows.Forms.KeyEventHandler(gHook_KeyDown);
            /*foreach (System.Windows.Forms.Keys key in Enum.GetValues(typeof(System.Windows.Forms.Keys)))
                gHook.HookedKeys.Add(key);*/
            gHook.HookedKeys.Add(System.Windows.Forms.Keys.NumPad0);
            gHook.HookedKeys.Add(System.Windows.Forms.Keys.NumPad1);
            gHook.HookedKeys.Add(System.Windows.Forms.Keys.NumPad2);
            gHook.HookedKeys.Add(System.Windows.Forms.Keys.NumPad3);
            MouseHook.Start();
            MouseHook.MouseAction += new EventHandler(Event);
        }

        private void Event(object sender, EventArgs e)
        {
        }

        byte leftMouseFlag = 0;
        byte rightMouseFlag = 0;
        private byte delay = 1;
        private byte currentState = 0;



        public void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                {
                    leftMouseFlag++;
                    e.Handled = true;
                    break;
                }
                case Keys.NumPad2:
                {
                    rightMouseFlag++;
                    e.Handled = true;
                    break;
                }
                case Keys.NumPad3:
                {
                    gimmeTimer.Enabled = !gimmeTimer.Enabled;
                    gimmeTimer.Interval = Convert.ToInt32(gimmeMaskedTextBox.Text) * 60000;
                    if (gimmeTimer.Enabled)
                    {
                        SystemSounds.Exclamation.Play();
                    }
                    else
                    {
                        SystemSounds.Hand.Play();
                    }
                    e.Handled = true;
                    break;
                }
                case Keys.NumPad0:
                {
                    Clipboard.SetText("/gimme");
                    var tKey = new List<INPUT>()
                    {
                        InputHelper.GetKeyboardInput(ScanCodeShort.KEY_T, VirtualKeyShort.KEY_T, KEYEVENTF.KEYDOWN),
                        InputHelper.GetKeyboardInput(ScanCodeShort.KEY_T, VirtualKeyShort.KEY_T, KEYEVENTF.KEYUP),
                    }.ToArray();
                    var paste = new List<INPUT>()
                    {

                        InputHelper.GetKeyboardInput(ScanCodeShort.CONTROL, VirtualKeyShort.CONTROL, KEYEVENTF.KEYDOWN),
                        InputHelper.GetKeyboardInput(ScanCodeShort.KEY_V, VirtualKeyShort.KEY_V, KEYEVENTF.KEYDOWN),
                        InputHelper.GetKeyboardInput(ScanCodeShort.KEY_V, VirtualKeyShort.KEY_V, KEYEVENTF.KEYUP),
                        InputHelper.GetKeyboardInput(ScanCodeShort.CONTROL, VirtualKeyShort.CONTROL, KEYEVENTF.KEYUP),

                        InputHelper.GetKeyboardInput(ScanCodeShort.RETURN, VirtualKeyShort.RETURN, KEYEVENTF.KEYDOWN),
                        InputHelper.GetKeyboardInput(ScanCodeShort.RETURN, VirtualKeyShort.RETURN, KEYEVENTF.KEYUP)
                    }.ToArray();

                    InputHelper.Send(tKey);
                    Thread.Sleep(100);
                    InputHelper.Send(paste);
                    e.Handled = true;
                    break;
                }
            }


        }

        public WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();

        private void Form1_Load(object sender, EventArgs e)
        {
            SystemSounds.Beep.Play();
            gHook.hook();
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            gHook.unhook();
        }



        private void gimmeTimer_Tick(object sender, EventArgs e)
        {
            SystemSounds.Exclamation.Play();
            Thread.Sleep(50);
            SystemSounds.Exclamation.Play();
        }

        static INPUT[] leftMouseButton = new List<INPUT>()
        {
            InputHelper.GetMouseInput(MOUSEEVENTF.LEFTDOWN),
            InputHelper.GetMouseInput(MOUSEEVENTF.LEFTUP)
        }.ToArray();

        static INPUT[] rightMouseButton = new List<INPUT>()
        {
            InputHelper.GetMouseInput(MOUSEEVENTF.RIGHTDOWN),
            InputHelper.GetMouseInput(MOUSEEVENTF.RIGHTUP)
        }.ToArray();

        private void timerInfinity_Tick(object sender, EventArgs e)
        {

            try
            {
                var loop = Convert.ToInt32(loopMaskedTextBox.Text);

                var rth = Convert.ToInt32(rthMaskedTextBox.Text);
                var rtm = Convert.ToInt32(rtmMaskedTextBox.Text);
                var rts = Convert.ToInt32(rtsMaskedTextBox.Text);

                var vth = Convert.ToInt32(vthMaskedTextBox.Text);
                var vtm = Convert.ToInt32(vtmMaskedTextBox.Text);
                var vts = Convert.ToInt32(vtsMaskedTextBox.Text);


                var secs = Convert.ToInt32(secsTextBox.Text);


                var multipler_VpR = 60 * 24 / loop;
                var difference = (multipler_VpR * GetSeconds(rth, rtm, rts)) % (3600 * 24) - GetSeconds(vth, vtm, vts);

                var dtNow = DateTime.Now;

                var dtVirtualNow = Math.Abs(((multipler_VpR * GetSeconds(dtNow.Hour, dtNow.Minute, dtNow.Second)) % (60 * 60 * 24)) + secs) % (60 * 60 * 24);
                var vhn = dtVirtualNow / 60 / 60;
                var vmn = (dtVirtualNow - vhn * 60 * 60) / 60;
                var vms = (dtVirtualNow - vhn * 60 * 60 - vmn * 60);
                traderButton.Text = vhn + ":" + vmn + ":" + vms;
                if (vhn == 6)
                {
                    var file = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly()?.Location) + "\\poop.wav";
                    this.Text = WMP.versionInfo;
                    WMP.URL = file;
                    WMP.controls.play();
                }
            }
            catch
            {
            }
            


            currentState++;
            if (currentState < delay) return;

            if (leftMouseFlag % 2 != 0)
            {
                InputHelper.Send(leftMouseButton);
            }
            else if (rightMouseFlag % 2 != 0)
            {
                InputHelper.Send(rightMouseButton);
                Thread.Sleep(200);
            }

            currentState = 0;
        }


        private static int GetSeconds(int hour, int minute, int second)
        {
            return hour * 3600 + minute * 60 + second;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

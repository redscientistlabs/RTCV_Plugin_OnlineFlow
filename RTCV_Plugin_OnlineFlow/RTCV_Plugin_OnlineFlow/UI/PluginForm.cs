namespace ONLINEFLOW.UI
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using NLog;
    using RTCV.CorruptCore;

    using RTCV.Common;
    using RTCV.UI;
    using static RTCV.CorruptCore.RtcCore;
    using RTCV.Vanguard;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Runtime.InteropServices;
    using System.Drawing.Imaging;
    using RTCV.NetCore;
    using System.Diagnostics;
    using System.Net;
    using System.Collections.Specialized;

    using System.IO.Compression;
    using System.Windows.Documents.Serialization;
    using RTCV.UI.Modular;
    using RTCV.NetCore.NetCoreExtensions;
    using IrcDotNet;
    using RTCV.UI.Components.Controls;

    public partial class PluginForm : ComponentForm, IColorize
    {
        public ONLINEFLOW plugin;
        public static PluginForm pf = null;

        public volatile bool HideOnClose = true;

        Logger logger = NLog.LogManager.GetCurrentClassLogger();

        WebClient wc = new WebClient();

        //This dictionary will inflate forever but it would take quite a while to be noticeable.
        Dictionary<string, bool> encounteredIds = new Dictionary<string, bool>();


        List<Button> registeredButtons = new List<Button>();

        public PluginForm(ONLINEFLOW _plugin)
        {
            plugin = _plugin;
            pf = this;

            this.InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.PluginForm_FormClosing);
            this.Text = "Online Flow";// CORRUPTCLOUD_LIVE.CamelCase(nameof(CORRUPTCLOUD_LIVE).Replace("_", " ")); //automatic window title

        }


        private void PluginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HideOnClose)
            {
                e.Cancel = true;
                this.Hide();
            }
        }


        private void PluginForm_Load(object sender, EventArgs e)
        {

            ReloadFromParams();
            RefreshButtons();

            pnTimeFlow.Location = Location;
            pnOptions.Location = Location;

        }

        private void btnAddShortcut_MouseDown(object sender, MouseEventArgs e)
        {
            var Hotkeys = UICore.HotkeyBindings;


            Point locate = e.GetMouseLocation(sender);

            ContextMenuStrip openCustomLayoutMenu = new ContextMenuStrip();

            foreach (var binding in Hotkeys)
            {
                openCustomLayoutMenu.Items.Add($"{binding.TabGroup} -> {binding.DisplayName}", null, new EventHandler((ob, ev) =>
                {
                    AddHotkeyToButtons(binding);
                    RefreshButtons();
                    SaveToParams();
                }));
            }

            openCustomLayoutMenu.Show(this, locate);

        }

        private void AddHotkeyToButtons(RTCV.UI.Input.Binding binding)
        {
            //var exist = registeredButtons.FirstOrDefault(iterator => iterator.Text == binding.DisplayName);
            //if (exist != null)
            //    registeredButtons.Remove(exist);

            //Button b = new Button();// (Button)ObjectCopier.Clone(btnTest
            //b.BackColor = btnTest.BackColor;
            //b.ForeColor = btnTest.ForeColor;
            //b.FlatAppearance.BorderSize = btnTest.FlatAppearance.BorderSize;
            //b.FlatStyle = btnTest.FlatStyle;
            //b.Size = btnTest.Size;
            //b.Tag = binding.DisplayName;
            //b.Text = $"{ binding.TabGroup} -> { binding.DisplayName}";

            //b.Click += (o, e) =>
            //{
            //    LocalNetCoreRouter.Route(RTCV.NetCore.Endpoints.UI, RTCV.NetCore.Commands.Remote.TriggerHotkey, binding.DisplayName);
            //};

            //registeredButtons.Add(b);
        }

        private void btnRemoveShortcut_MouseDown(object sender, MouseEventArgs e)
        {
            var Hotkeys = UICore.HotkeyBindings;


            Point locate = e.GetMouseLocation(sender);

            ContextMenuStrip openCustomLayoutMenu = new ContextMenuStrip();

            foreach (var button in registeredButtons)
            {
                openCustomLayoutMenu.Items.Add($"{button.Text}", null, new EventHandler((ob, ev) =>
                {
                    registeredButtons.Remove(button);
                    if (Controls.Contains(button))
                        Controls.Remove(button);

                    RefreshButtons();
                    SaveToParams();
                }));
            }

            openCustomLayoutMenu.Show(this, locate);

        }

        public void RefreshButtons()
        {
            //for (int i = 0; i < registeredButtons.Count; i++)
            //{
            //    var button = registeredButtons[i];

            //    int xpos = btnTest.Location.X;
            //    int ypos = ((btnTest.Location.Y + btnTest.Size.Height) * (i + 1)) - btnTest.Size.Height;

            //    if (!Controls.Contains(button))
            //        Controls.Add(button);

            //    button.Location = new Point(xpos, ypos);
            //    button.Visible = true;

            //}
        }

        public void ReloadFromParams()
        {
            //if (Params.IsParamSet("PLUGIN_SHORTCUTBAR"))
            //{
            //    var param = Params.ReadParam("PLUGIN_SHORTCUTBAR");

            //    var values = param.Split('|');
            //    var binds = GetBindingsFromStrings(values);
            //    foreach (var bind in binds)
            //        AddHotkeyToButtons(bind);

            //    SaveToParams();
            //}
        }

        public void SaveToParams()
        {
            //string value = String.Join("|", registeredButtons.Select(it => it.Tag.ToString()));
            //Params.SetParam("PLUGIN_SHORTCUTBAR", value);

        }

        public List<RTCV.UI.Input.Binding> GetBindingsFromStrings(string[] values)
        {
            var Hotkeys = UICore.HotkeyBindings;
            List<RTCV.UI.Input.Binding> binds = new List<RTCV.UI.Input.Binding>();

            foreach(var value in values)
            {
                var bind = UICore.HotkeyBindings.FirstOrDefault(iterator => iterator.DisplayName == value);
                if (bind != null)
                    binds.Add(bind);
            }

            return binds;
        }

        public static System.Threading.Thread TwitchChatThread;
        public static bool connected = false;
        private void btnConnectToTwitch_Click(object sender, EventArgs e)
        {
            connected = true;
            string channel = tbTwtchChannel.Text;
            Run(channel);

            pnOnlineFlow.Visible = false;
            pnTimeFlow.Visible = true;
        }

        public static void Run(string channel)
        {
            new object();
            TwitchChatThread = new System.Threading.Thread(() =>
            {
                string user = "justinfan" + RTCV.CorruptCore.RtcCore.RND.Next(10000, int.MaxValue);
                string password = "";
                TwitchChat.Main(user, password, channel);
            });
            TwitchChatThread.Start();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            pnOnlineFlow.Visible = false;
            pnTimeFlow.Visible = false;
            pnOptions.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnOnlineFlow.Visible = false;
            pnTimeFlow.Visible = true;
            pnOptions.Visible = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            pnOnlineFlow.Visible = true;
            pnTimeFlow.Visible = false;
            pnOptions.Visible = false;

            connected = false;
            System.Threading.Thread.Sleep(500);
            TwitchChat.Disconnect();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"
The twitch commands are divised in 3 security groups.

­> [L1 Blast Only] Has only access to the BLAST Command

Command: BLAST -­> Queries a Manual Blast

­> [L2 Engine Control] Has only access to RTC Engine Commands

Command: INTENSITY -­> Changes the Intensity
(Ex: INTENSITY 1000)

Command: DELAY -­> Changes the Error Delay
(Ex: DELAY 500)

Command: MAXUNITS -­> Changes the Maximum Infinite Units
(Ex: MAXUNITS 400)

Command: ENGINE -­> Changes the engine
(Ex: ENGINE HELLGENIE)

Command: LIMITER -­> Changes the Limiter List
(Ex: LIMITER One)

Command: VALUE -­> Changes the Value List
(Ex: VALUE Two)

Command: SELECT -­> Selects a memory domain
(Ex: SELECT PRG ROM)

Command: DESELECT -­> Deselects a memory domain
(Ex: DESELECT CARTROM)

­> [L3 Total Control] Has access to everything

Command: SAVESTATE -> Makes a new savestate
Command: LOADSTATE -> Loads the selected savestate
Command: GHBLAST -­> Blasts to Glitch
Command: SENDSTOCKPILE -­> Sends last selected item to stockpile

Command: RESET -­> Resets the current game
Command: RELOAD -­> Reloads the last selected stash/stockpile item
Command: RAW -­> Sends the current emulator state to stash history
Command: REBLAST -­> Reapplies the last corruption again
");
        }
    }

    public static class TwitchChat
    {

        public static volatile string PostRequest = null;

        public static void PostUrl(string url)
        {
            PostRequest = url;
        }


        public static void Main(string username, string password, string channel)
        {

            //Console.WriteLine("Usage: twitchirc <username> <oauth>");
            //Console.WriteLine("Use http://twitchapps.com/tmi/ to generate an <oauth> token!");


            var server = "irc.twitch.tv";
            //Console.WriteLine("Starting to connect to twitch as {0}.", username);

            using (var client = new IrcDotNet.TwitchIrcClient())
            {
                client.FloodPreventer = new IrcStandardFloodPreventer(4, 2000);
                client.Disconnected += IrcClient_Disconnected;
                client.Registered += IrcClient_Registered;
                // Wait until connection has succeeded or timed out.
                using (var registeredEvent = new System.Threading.ManualResetEventSlim(false))
                {
                    using (var connectedEvent = new System.Threading.ManualResetEventSlim(false))
                    {
                        client.Connected += (sender2, e2) => connectedEvent.Set();
                        client.Registered += (sender2, e2) => registeredEvent.Set();
                        client.Connect(server, false,
                            new IrcUserRegistrationInfo()
                            {
                                NickName = username,
                                Password = password,
                                RealName = username,
                                UserName = username
                            }); ;
                        if (!connectedEvent.Wait(10000))
                        {
                            //Console.WriteLine("Connection to '{0}' timed out.", server);
                            return;
                        }
                    }
                    //Console.Out.WriteLine("Now connected to '{0}'.", server);
                    if (!registeredEvent.Wait(10000))
                    {
                        //Console.WriteLine("Could not register to '{0}'.", server);
                        return;
                    }
                }

                //Console.Out.WriteLine("Now registered to '{0}' as '{1}'.", server, username);

                System.Threading.Thread.Sleep(800);
                client.Channels.Join($"#{channel}");
                System.Threading.Thread.Sleep(300);

                Console($"Connected to Twitch Channel {channel}");

                HandleEventLoop(client);


            }
        }

        private static void HandleEventLoop(IrcDotNet.IrcClient client)
        {
            bool isExit = false;
            while (!isExit)
            {
                System.Threading.Thread.Sleep(300);


                //client.

                //if (PostRequest != null)
                //{
                //    string req = PostRequest;
                //    PostRequest = null;
                //    //client.SendRawMessage(req);
                //    client.LocalUser.SendMessage(client.Channels[0], req);
                //}


                /*
                Console.Write("> ");
                var command = Console.ReadLine();
                switch (command)
                {
                    case "exit":
                        isExit = true;
                        break;
                    default:
                        if (!string.IsNullOrEmpty(command))
                        {
                            if (command.StartsWith("/") && command.Length > 1)
                            {
                                client.SendRawMessage(command.Substring(1));
                            }
                            else
                            {
                                Console.WriteLine("unknown command '{0}'", command);
                            }
                        }
                        break;
                }
                */

                if(!PluginForm.connected)
                    break;

            }
            client.Disconnect();
        }

        private static void IrcClient_Registered(object sender, EventArgs e)
        {
            var client = (IrcClient)sender;

            client.LocalUser.NoticeReceived += IrcClient_LocalUser_NoticeReceived;
            client.LocalUser.MessageReceived += IrcClient_LocalUser_MessageReceived;
            client.LocalUser.JoinedChannel += IrcClient_LocalUser_JoinedChannel;
            client.LocalUser.LeftChannel += IrcClient_LocalUser_LeftChannel;
        }

        private static void IrcClient_LocalUser_LeftChannel(object sender, IrcChannelEventArgs e)
        {
            var localUser = (IrcLocalUser)sender;

            e.Channel.UserJoined -= IrcClient_Channel_UserJoined;
            e.Channel.UserLeft -= IrcClient_Channel_UserLeft;
            e.Channel.MessageReceived -= IrcClient_Channel_MessageReceived;
            e.Channel.NoticeReceived -= IrcClient_Channel_NoticeReceived;

            //Console.WriteLine("You left the channel {0}.", e.Channel.Name);
        }

        private static void IrcClient_LocalUser_JoinedChannel(object sender, IrcChannelEventArgs e)
        {
            var localUser = (IrcLocalUser)sender;

            e.Channel.UserJoined += IrcClient_Channel_UserJoined;
            e.Channel.UserLeft += IrcClient_Channel_UserLeft;
            e.Channel.MessageReceived += IrcClient_Channel_MessageReceived;
            e.Channel.NoticeReceived += IrcClient_Channel_NoticeReceived;

            //Console.WriteLine("You joined the channel {0}.", e.Channel.Name);
        }

        private static void IrcClient_Channel_NoticeReceived(object sender, IrcMessageEventArgs e)
        {
            var channel = (IrcChannel)sender;

            //Console.WriteLine("[{0}] Notice: {1}.", channel.Name, e.Text);
        }

        public static void Console(string text)
        {
            SyncObjectSingleton.FormExecute(() =>
            {
                PluginForm.pf.tbOnlineFlow.Text +=  (string.IsNullOrWhiteSpace(PluginForm.pf.tbOnlineFlow.Text) ? "" : Environment.NewLine) + text;
                PluginForm.pf.tbOnlineFlow.SelectionStart = PluginForm.pf.tbOnlineFlow.Text.Length;
                PluginForm.pf.tbOnlineFlow.ScrollToCaret();
            });
        }

        private static void IrcClient_Channel_MessageReceived(object sender, IrcMessageEventArgs e)
        {
            SyncObjectSingleton.FormExecute(() =>
            {
                try
                {
                    var channel = (IrcChannel)sender;
                    if (e.Source is IrcUser)
                    {
                        // Read message.
                        //Console.WriteLine("[{0}]({1}): {2}.", channel.Name, e.Source.Name, e.Text);
                        string msg = e.Text;

                        var msgparts = msg.Split(' ');
                        switch (msgparts[0].Trim().ToUpper())
                        {
                            case "BLAST":
                                {
                                    //-----
                                    LocalNetCoreRouter.Route(RTCV.NetCore.Endpoints.CorruptCore, RTCV.NetCore.Commands.Basic.ManualBlast, true);
                                    Console("Manual Blast");
                                    break;
                                }

                            case "AUTOCORRUPT":
                                {
                                    if (PluginForm.pf.rbBlastControl.Checked)
                                        break;

                                    if (msgparts.Length­ > 0 && msgparts[1].Trim().ToUpper() == "ON")
                                    {
                                        if (!RTCV.CorruptCore.RtcCore.AutoCorrupt)
                                        {
                                            S.GET<CoreForm>().StartAutoCorrupt(null, null);
                                            Console("Auto-Corrupt ON");
                                        }
                                        //-----
                                    }
                                    else if (msgparts.Length > 0 && msgparts[1].Trim().ToUpper() == "OFF")
                                    {
                                        if (RTCV.CorruptCore.RtcCore.AutoCorrupt)
                                        {
                                            S.GET<CoreForm>().StartAutoCorrupt(null, null);
                                            Console("Auto-Corrupt OFF");
                                        }
                                        //-----
                                    }
                                    break;
                                }

                            case "INTENSITY":
                                {
                                    if (PluginForm.pf.rbBlastControl.Checked)
                                        break;

                                    if (msgparts.Length > 0 && Int32.TryParse(msgparts[1].Trim().ToUpper(), out int val))
                                    {
                                        RtcCore.Intensity = val;
                                        S.GET<GeneralParametersForm>().multiTB_Intensity.Value = val;
                                        S.GET<GeneralParametersForm>().multiTB_Intensity.OnValueChanged(new ValueUpdateEventArgs(val));
                                        Console($"Intensity {val}");
                                        //-----
                                    }
                                    break;
                                }

                            case "DELAY":
                                {
                                    if (PluginForm.pf.rbBlastControl.Checked)
                                        break;

                                    if (msgparts.Length > 0 && Int32.TryParse(msgparts[1].Trim().ToUpper(), out int val))
                                    {
                                        RtcCore.ErrorDelay = val;
                                        S.GET<GeneralParametersForm>().multiTB_ErrorDelay.Value = val;
                                        S.GET<GeneralParametersForm>().multiTB_ErrorDelay.OnValueChanged(new ValueUpdateEventArgs(val));
                                        Console($"Error Delay {val}");
                                        //-----
                                    }
                                    break;
                                }

                            case "ENGINE":
                                {
                                    if (PluginForm.pf.rbBlastControl.Checked)
                                        break;

                                    if (msgparts.Length > 0)
                                    {
                                        var cef = S.GET<CorruptionEngineForm>();
                                        var cb = cef.cbSelectedEngine;
                                        switch (msgparts[1].Trim().ToUpper())
                                        {
                                            case "NIGHTMARE":
                                                {
                                                    var val = "Nightmare Engine";
                                                    for (int i = 0; i < cb.Items.Count; i++)
                                                        if (cb.Items[i].ToString() == val)
                                                        {
                                                            cb.SelectedIndex = i;
                                                            Console($"Swithed to {val}");
                                                            break;
                                                        }
                                                    //-----
                                                    break;
                                                }
                                            case "HELLGENIE":
                                                {
                                                    var val = "Hellgenie Engine";
                                                    for (int i = 0; i < cb.Items.Count; i++)
                                                        if (cb.Items[i].ToString() == val)
                                                        {
                                                            cb.SelectedIndex = i;
                                                            Console($"Swithed to {val}");
                                                            break;
                                                        }
                                                    //-----
                                                    break;
                                                }
                                            case "DISTORTION":
                                                {
                                                    var val = "Distortion Engine";
                                                    for (int i = 0; i < cb.Items.Count; i++)
                                                        if (cb.Items[i].ToString() == val)
                                                        {
                                                            cb.SelectedIndex = i;
                                                            Console($"Swithed to {val}");
                                                            break;
                                                        }
                                                    //-----
                                                    break;
                                                }
                                            case "FREEZE":
                                                {
                                                    var val = "Freeze Engine";
                                                    for (int i = 0; i < cb.Items.Count; i++)
                                                        if (cb.Items[i].ToString() == val)
                                                        {
                                                            cb.SelectedIndex = i;
                                                            Console($"Swithed to {val}");
                                                            break;
                                                        }
                                                    //-----
                                                    break;
                                                }
                                            case "PIPE":
                                                {
                                                    var val = "Pipe Engine";
                                                    for (int i = 0; i < cb.Items.Count; i++)
                                                        if (cb.Items[i].ToString() == val)
                                                        {
                                                            cb.SelectedIndex = i;
                                                            Console($"Swithed to {val}");
                                                            break;
                                                        }
                                                    //-----
                                                    break;
                                                }
                                            case "VECTOR":
                                                {
                                                    var val = "Vector Engine";
                                                    for (int i = 0; i < cb.Items.Count; i++)
                                                        if (cb.Items[i].ToString() == val)
                                                        {
                                                            cb.SelectedIndex = i;
                                                            Console($"Swithed to {val}");
                                                            break;
                                                        }
                                                    //-----
                                                    break;
                                                }
                                            case "CLUSTER":
                                                {
                                                    var val = "Cluster Engine";
                                                    for (int i = 0; i < cb.Items.Count; i++)
                                                        if (cb.Items[i].ToString() == val)
                                                        {
                                                            cb.SelectedIndex = i;
                                                            Console($"Swithed to {val}");
                                                            break;
                                                        }
                                                    //-----
                                                    break;
                                                }
                                        }
                                    }
                                    break;
                                }

                            case "LIMITER":
                                {
                                    if (PluginForm.pf.rbBlastControl.Checked)
                                        break;

                                    if (msgparts.Length­ > 0)
                                    {
                                        var val = msgparts[1].Trim().ToUpper();
                                        var cef = S.GET<CorruptionEngineForm>();
                                        var cb = cef.VectorEngineControl.cbVectorLimiterList;
                                        for (int i = 0; i < cb.Items.Count; i++)
                                        {
                                            dynamic item = cb.Items[i] as dynamic;

                                            if (item.Name.ToUpper() == val)
                                            {
                                                cb.SelectedIndex = i;
                                                Console($"Limiter List {val}");
                                                break;
                                            }
                                        }
                                        //-----
                                    }
                                    break;
                                }
                            case "VALUE":
                                {
                                    if (PluginForm.pf.rbBlastControl.Checked)
                                        break;

                                    if (msgparts.Length­ > 0)
                                    {
                                        var val = msgparts[1].Trim().ToUpper();
                                        var cef = S.GET<CorruptionEngineForm>();
                                        var cb = cef.VectorEngineControl.cbVectorValueList;
                                        for (int i = 0; i < cb.Items.Count; i++)
                                        {
                                            dynamic item = cb.Items[i] as dynamic;

                                            if (item.Name.ToUpper() == val)
                                            {
                                                cb.SelectedIndex = i;
                                                Console($"Value List {val}");
                                                break;
                                            }
                                        }
                                        //-----
                                    }
                                    break;
                                }
                            case "MAXUNITS":
                                {
                                    if (PluginForm.pf.rbBlastControl.Checked)
                                        break;

                                    if (msgparts.Length > 0 && Int32.TryParse(msgparts[1].Trim().ToUpper(), out int val))
                                    {
                                        S.GET<CorruptionEngineForm>().HellgenieEngineControl.updownMaxCheats.Value = val;
                                        Console($"Max Active Units {val}");
                                        //-----
                                    }
                                    break;
                                }
                            case "SELECT":
                                {
                                    if (PluginForm.pf.rbBlastControl.Checked)
                                        break;

                                    if (msgparts.Length­ > 0)
                                    {
                                        var val = string.Join(" ", msgparts.Where(it => it != msgparts[0])).Trim().ToUpper();
                                        var currentDomains = S.GET<MemoryDomainsForm>().lbMemoryDomains.Items.Cast<string>().ToArray();

                                        if (val == "ALL")
                                        {
                                            var lb = S.GET<MemoryDomainsForm>().lbMemoryDomains;
                                            for (int i = 0; i < lb.Items.Count; i++)
                                            {
                                                lb.SetSelected(i, true);
                                            }
                                            Console($"Selected all domains");
                                        }
                                        else
                                        {
                                            string found = null;
                                            for (int i = 0; i < currentDomains.Length; i++)
                                                if (currentDomains[i].ToUpper().Trim() == val)
                                                {
                                                    found = currentDomains[i];
                                                    break;
                                                }

                                            if (found != null)
                                            {
                                                var lb = S.GET<MemoryDomainsForm>().lbMemoryDomains;

                                                for (int i = 0; i < lb.Items.Count; i++)
                                                {
                                                    if (lb.Items[i].ToString() == found)
                                                    {
                                                        lb.SetSelected(i, true);
                                                        Console($"Selected domain {val}");
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        //-----
                                    }
                                    break;
                                }
                            case "DESELECT":
                                {
                                    if (PluginForm.pf.rbBlastControl.Checked)
                                        break;

                                    if (msgparts.Length­ > 0)
                                    {


                                        var val = string.Join(" ", msgparts.Where(it => it != msgparts[0])).Trim().ToUpper();
                                        var currentDomains = S.GET<MemoryDomainsForm>().lbMemoryDomains.Items.Cast<string>().ToArray();

                                        string found = null;
                                        for (int i = 0; i < currentDomains.Length; i++)
                                            if (currentDomains[i].ToUpper().Trim() == val)
                                            {
                                                found = currentDomains[i];
                                                break;
                                            }

                                        if (found != null)
                                        {
                                            var lb = S.GET<MemoryDomainsForm>().lbMemoryDomains;

                                            for (int i = 0; i < lb.Items.Count; i++)
                                            {
                                                if (lb.Items[i].ToString() == found)
                                                {
                                                    lb.SetSelected(i, false);
                                                    Console($"Deselected domain {val}");
                                                    break;
                                                }
                                            }
                                        }
                                        //-----
                                    }
                                    break;
                                }

                            case "RESET":
                                {
                                    if (!PluginForm.pf.rbTotalControl.Checked)
                                        break;

                                    LocalNetCoreRouter.Route(RTCV.NetCore.Endpoints.Vanguard, RTCV.NetCore.Commands.Emulator.ResetGame, null);

                                    Console($"Reset the game");
                                    break;
                                }

                            case "RELOAD":
                                {
                                    if (!PluginForm.pf.rbTotalControl.Checked)
                                        break;

                                    UICore.CheckHotkey("Reload Corruption");

                                    Console($"Reloaded Corruption");
                                    break;
                                }

                            case "RAW":
                                {
                                    if (!PluginForm.pf.rbTotalControl.Checked)
                                        break;

                                    UICore.CheckHotkey("Send Raw to Stash");

                                    Console($"Send Raw to Stash");
                                    break;
                                }

                            case "REBLAST":
                                {
                                    if (!PluginForm.pf.rbTotalControl.Checked)
                                        break;

                                    UICore.CheckHotkey("BlastLayer Re-Blast");

                                    Console($"Re-Blast last corruption");
                                    break;
                                }

                            case "SAVESTATE":
                                {
                                    if (!PluginForm.pf.rbTotalControl.Checked)
                                        break;

                                    UICore.CheckHotkey("New Savestate");

                                    Console($"Created a new savestate");
                                    break;
                                }
                            case "LOADSTATE":
                                {
                                    if (!PluginForm.pf.rbTotalControl.Checked)
                                        break;

                                    UICore.CheckHotkey("Load");

                                    Console($"Loaded the current savestate");
                                    break;
                                }
                            case "GHBLAST":
                                {
                                    if (!PluginForm.pf.rbTotalControl.Checked)
                                        break;

                                    UICore.CheckHotkey("Load and Corrupt");

                                    Console($"Fired GH Corrupt");
                                    break;
                                }
                            case "SENDSTOCKPILE":
                                {
                                    if (!PluginForm.pf.rbTotalControl.Checked)
                                        break;

                                    S.GET<StashHistoryForm>().DontLoadSelectedStash = true;
                                    S.GET<StashHistoryForm>().lbStashHistory.SelectedIndex = S.GET<StashHistoryForm>().lbStashHistory.Items.Count - 1;

                                    UICore.CheckHotkey("Stash->Stockpile");

                                    Console($"Sent stash item to stockpile");
                                    break;
                                }

                        }

                    }
                }
                catch (Exception ex)
                {
                    _ = ex;
                }
            });
        }

        private static void IrcClient_Channel_UserLeft(object sender, IrcChannelUserEventArgs e)
        {
            var channel = (IrcChannel)sender;
            //Console.WriteLine("[{0}] User {1} left the channel.", channel.Name, e.ChannelUser.User.NickName);
        }

        private static void IrcClient_Channel_UserJoined(object sender, IrcChannelUserEventArgs e)
        {
            var channel = (IrcChannel)sender;
            //Console.WriteLine("[{0}] User {1} joined the channel.", channel.Name, e.ChannelUser.User.NickName);
        }

        private static void IrcClient_LocalUser_MessageReceived(object sender, IrcMessageEventArgs e)
        {
            var localUser = (IrcLocalUser)sender;

            if (e.Source is IrcUser)
            {
                // Read message.
                //Console.WriteLine("({0}): {1}.", e.Source.Name, e.Text);
            }
            else
            {
                //Console.WriteLine("({0}) Message: {1}.", e.Source.Name, e.Text);
            }
        }

        private static void IrcClient_LocalUser_NoticeReceived(object sender, IrcMessageEventArgs e)
        {
            var localUser = (IrcLocalUser)sender;
            //Console.WriteLine("Notice: {0}.", e.Text);
        }

        private static void IrcClient_Disconnected(object sender, EventArgs e)
        {
            var client = (IrcClient)sender;
        }

        private static void IrcClient_Connected(object sender, EventArgs e)
        {
            var client = (IrcClient)sender;
        }

        internal static void Disconnect()
        {
            try
            {
                PluginForm.TwitchChatThread.Abort();
            }
            catch { }
        }
    }

}

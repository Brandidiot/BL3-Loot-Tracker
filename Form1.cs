using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Media;
using Gma.System.MouseKeyHook;

namespace BL3_Loot_Tracker
{

    public partial class BL3LT : Form
    {
        private readonly Stopwatch _stopWatch = new Stopwatch();
        private bool _started = false;

        private List<Runs> _runs = new List<Runs>();

        public BL3LT()
        {
            InitializeComponent();

            //Build a list
            var bossesList = new List<string>(new string[]
            {
                "Aurelia", "Borman Nates", "Baron Noggin", "Bellik Primis", "Captain Thunk and Sloth", "Chupacabratch", "Crawly Family",
                "Dinkeblot", "Dr. Benedict", "El Dragon Jr", "Eleanor and The Heart", "Empowered Grawn", "Empowered Scholar", "Evil Lilith", "Fabricator", 
                "Freddie the Traitor", "GenIVIV", "Gigamind", "Handsome Jackie", "Heckle and Hyde", "Hot Karl", "Jackpot the Jack's bot", "Judge Hightower", 
                "Katagawa Ball", "Killavolt", "Kormash", "Locomöbius", "Manvark", "Maxitrillion", "Mouthpiece", "One Punch", "Phoenix", "Private Beans", 
                "Psychobillies", "Psychoreaver", "Rakkman", "Road Dog", "Ruiner", "Scraptrap Prime", "Skrakk", "Sky Bullies", "Tarantella", "The Graveward", "The Rampager", 
                "The Unstoppable", "The Quartermaster", "Troy Calypso", "Tyreen Calypso", "Urist McEnforcer", "Warden", "Wendigo", "Wick and Worty"
            });

            //Setup data binding
            foreach (var t in bossesList)
            {
                bossComboBox.Items.Add(t);
            }

            // make it readonly
            bossComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            bossComboBox.MaxDropDownItems = 5;

            LoadRunsList();

            var hook = Hook.GlobalEvents();
            hook.KeyDown += Hook_KeyDown;
        }

        private void Hook_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 45:
                    Start_Btn_Click(sender, e);
                    break;
                case 36:
                    Stop_Btn_Click(sender,e);
                    break;
                case 33:
                    Reset_Btn_Click(sender, e);
                    break;
            }
        }

        private void LoadRunsList()
        {
            _runs = SqliteDataAccess.LoadRuns();

            WireUpRunsList();
        }

        private void WireUpRunsList()
        {
            //listRunsListBox.DataSource = null;
            listRunsListBox.DataSource = _runs;
            listRunsListBox.DisplayMember = "Run";
        }

        private void Start_Btn_Click(object sender, EventArgs e)
        {
            var player = new SoundPlayer(@".\Start.wav");
            player.Play();

            _started = true;
            _stopWatch.Start();
        }

        private void Stop_Btn_Click(object sender, EventArgs e)
        {
            var player = new SoundPlayer(@".\Stop.wav");
            player.Play();

            _started = false;
            _stopWatch.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!_started)
            {
                return;
            }

            // Get the elapsed time as a TimeSpan value.
            var ts = _stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            var elapsedTime = $"{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";

            Timer_Txt.Text = elapsedTime;

        }

        private void bossComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Get the currently selected item in the ComboBox.
            if (bossComboBox.SelectedItem == null)
            {
                return;
            }

            itemList.Items.Clear();

            var boss = new Boss();

            var curItem = bossComboBox.SelectedItem.ToString();

            switch (curItem)
            {
                case "Aurelia":
                {
                    boss.Drop = new string[2] { "Juliet's Dazzle", "Frozen Heart" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Baron Noggin":
                {
                    boss.Drop = new string[2] { "Superball", "Executor" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Borman Nates":
                {
                    boss.Drop = new string[3] {"Cutsman", "Psycho Stabber", "Sawbar"};

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Captain Thunk and Sloth":
                {
                    boss.Drop = new string[4] { "Bangarang", "Mongol", "Fastball", "It's Piss" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Chupacabratch":
                {
                    boss.Drop = new string[2] { "Chupa's Organ", "Nagata" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Crawly Family":
                {
                    boss.Drop = new string[2] { "Linoge", "Predatory Lending" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Dinkeblot":
                {
                    boss.Drop = new string[2] { "Lucian's Call", "The Butcher" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "El Dragon Jr":
                {
                    boss.Drop = new string[2] { "Stop-Gap", "Unleash the Dragon" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Mouthpiece":
                {
                    boss.Drop = new string[2] { "Mind-Killer", "Nemesis" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "GenIVIV":
                {
                    boss.Drop = new string[3] { "Polybius", "Reflux", "Ten Gallon" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Gigamind":
                {
                    boss.Drop = new string[2] { "Smart-Gun", "Red Card" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Handsome Jackie":
                {
                    boss.Drop = new string[2] { "Handsome Jackhammer", "Nimble Jack" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Heckle and Hyde":
                {
                    boss.Drop = new string[2] { "Alchemist", "Pestilence" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Hot Karl":
                {
                    boss.Drop = new string[3] { "Embrace the Pain", "Pain is Power", "Sledge's Shotgun" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Judge Hightower":
                {
                    boss.Drop = new string[2] { "Carrier", "Conference Call" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Katagawa Ball":
                {
                    boss.Drop = new string[2] { "Brainstormer", "Multi-Tap" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Killavolt":
                {
                    boss.Drop = new string[2] { "9-Volt", "The Monarch" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Manvark":
                {
                    boss.Drop = new string[2] { "Flakker", "Try-Bolt" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Maxitrillion":
                {
                    boss.Drop = new string[2] { "ASMD", "The Horizon" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "One Punch":
                {
                    boss.Drop = new string[2] { "One Pump Chump", "Sleeping Giant" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Phoenix":
                {
                    boss.Drop = new string[3] { "Malak's Bane", "Deathless", "Phoenix Tears" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Private Beans":
                {
                    boss.Drop = new string[3] { "Trevonator", "Westergun", "Front Loader" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Psychobillies":
                {
                    boss.Drop = new string[3] { "Devil's Foursum", "Kaos", "Electric Banjo" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Rakkman":
                {
                    boss.Drop = new string[1] { "Gunerang" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Road Dog":
                {
                    boss.Drop = new string[3] { "Hellwalker", "Redline", "Splatter Gun" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Skrakk":
                {
                    boss.Drop = new string[2] { "SkekSil", "Infiltrator" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Sky Bullies":
                {
                    boss.Drop = new string[2] { "Rebel Yell", "Hex" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Tarantella":
                {
                    boss.Drop = new string[3] { "Hive", "Roisen's Thorns", "Re-Router" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Urist McEnforcer":
                {
                    boss.Drop = new string[2] { "Masterwork Crossbow", "Re-Charger" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "The Graveward":
                {
                    boss.Drop = new string[3] { "The Lob", "Ward", "Grave" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "The Rampager":
                {
                    boss.Drop = new string[2] { "Good Juju", "The Duc" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "The Unstoppable":
                {
                    boss.Drop = new string[3] { "Devastator", "Band of Sitorak", "Big Boom Blaster" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Troy Calypso":
                {
                    boss.Drop = new string[2] { "Occultist", "Vosk's Deathgrip" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Tyreen Calypso":
                {
                    boss.Drop = new string[3] { "Bitch", "King's Call", "Queen's Call" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Warden":
                {
                    boss.Drop = new string[2] { "Freeman", "Plaguebearer" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Wick and Worty":
                {
                    boss.Drop = new string[4] { "AAA", "Phebert", "Black Hole", "Quasar" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Scraptrap Prime":
                {
                    boss.Drop = new string[2] { "Boomer", "Lucky 7" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Fabricator":
                {
                    boss.Drop = new string[1] { "Ion Cannon" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Freddie the Traitor":
                {
                    boss.Drop = new string[1] { "AutoAimè" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Jackpot the Jack's bot":
                {
                    boss.Drop = new string[6] { "Cheap Tips", "Craps", "Golden Rule", "Green Monster", "Seein' Dead", "St4ckbot" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Empowered Scholar":
                {
                    boss.Drop = new string[1] { "Void Rift" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Wendigo":
                {
                    boss.Drop = new string[1] { "Stauros' Burn" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Empowered Grawn":
                {
                    boss.Drop = new string[1] { "Lunacy" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Eleanor and The Heart":
                {
                    boss.Drop = new string[1] { "Love Drill" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Kormash":
                {
                    boss.Drop = new string[1] { "Stonethrower" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Bellik Primis":
                {
                    boss.Drop = new string[1] { "Chandelier" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "The Quartermaster":
                {
                    boss.Drop = new string[1] { "Miscreant" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Ruiner":
                {
                    boss.Drop = new string[1] { "Bloom" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Evil Lilith":
                {
                    boss.Drop = new string[3] { "Blood-Starved Beast", "Prompt Critical", "Muse" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Locomöbius":
                {
                    boss.Drop = new string[3] { "Blind Sage", "Faulty Star", "Hustler" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Dr. Benedict":
                {
                    boss.Drop = new string[3] { "Convergence", "Plus Ultra", "Peregrine" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
                case "Psychoreaver":
                {
                    boss.Drop = new string[2] { "Major Kong", "Rebound" };

                    foreach (var t in boss.Drop)
                    {
                        itemList.Items.Add(t);
                    }

                    break;
                }
            }
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            Runs r = new Runs();

            var date = DateTime.Today;
            var items = new List<string>();

            r.Date = date.ToString("MM/dd/yy");
            r.Boss = bossComboBox.Text;
            r.Time = Timer_Txt.Text;

            //Implement loot recording
            foreach (var i in itemList.SelectedItems)
            {
                items.Add(i.ToString());
            }

            r.Loot = String.Join(", ", items);

            SqliteDataAccess.SaveRuns(r);

            Reset_Btn_Click(sender, e);
            itemList.SelectedIndex = -1;

            LoadRunsList();

            listRunsListBox.TopIndex = listRunsListBox.Items.Count - 1;
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadRunsList();
        }

        private void Reset_Btn_Click(object sender, EventArgs e)
        {
            _started = false;
            _stopWatch.Reset();

            // Get the elapsed time as a TimeSpan value.
            var ts = _stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            var elapsedTime = $"{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";

            Timer_Txt.Text = elapsedTime;
        }
    }
}

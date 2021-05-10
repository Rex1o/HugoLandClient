using HugoWorld.BLL;
using HugoWorld_Client.HL_Services;
using HugoWorld_Client.Vue;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace HugoWorld
{

    public partial class HugoWorld : Form
    {
        private Stopwatch _timer = new Stopwatch();
        private double _lastTime;
        private long _frameCounter;
        private GameState _gameState;
        private bool connected = false;
        private HeroServiceClient heroService;


        public HugoWorld()
        {
            heroService = new HeroServiceClient();
            //Setup the form
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

            //Startup the game state
            _gameState = new GameState(ClientSize);

            initialize();
        }

        private void initialize()
        {
            _gameState.Initialize();

            if (connected)
            {
                //Initialise and start the timer
                _lastTime = 0.0;
                _timer.Reset();
                _timer.Start();
            }
        }

        private void Crusader_Paint(object sender, PaintEventArgs e)
        {
            //Work out how long since we were last here in seconds
            double gameTime = _timer.ElapsedMilliseconds / 1000.0;
            double elapsedTime = gameTime - _lastTime;
            _lastTime = gameTime;
            _frameCounter++;

            if (connected)
            {
                try
                {
                    //Perform any animation and updates
                    _gameState.Update(gameTime, elapsedTime);

                    //Draw everything
                    _gameState.Draw(e.Graphics);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veuillez vérifier la connexion à votre VPN!");
                    Application.Exit();
                }
            }

            //Force the next Paint()
            this.Invalidate();
        }

        private void Crusader_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                DialogResult result = Outils.ShowInfoMessage("Do you wish to return to the main menu? Your progress will be automatically saved and you will be disconnected from the game.", "Warning!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    this.Enabled = false;
                    _gameState.KeyDown(e.KeyCode);
                    heroService.ConnectDisconnectHeroById(Outils.GetHero().Id, false);
                    ShowMenu();
                }
            }
            else
            {
                _gameState.KeyDown(e.KeyCode);
            }
        }

        private void Crusader_Shown(object sender, EventArgs e)
        {
            //Il dit qu'il veut voir l'autre fen�tre derri�re donc j'ai mis les
            //forms dans l'event shown masi pour le character selection, il vas falloir modifier le code
            //pcqu'il est intilialis� dans le form initialise (et ici nous somme apr�s cette m�thode)

            //ShowLoginForm Here
            Form Login = new frmConnection();
            //block thread until logged in
            this.Enabled = false;
            Login.ShowDialog();

            while (Login.DialogResult != DialogResult.OK)
            {
                if (Login.DialogResult == DialogResult.No)
                {
                    this.Close();
                    Application.Exit();
                }
                else
                    Login.ShowDialog();
            }

            ShowMenu();
        }

        private void ShowMenu()
        {
            frmMenu menu = new frmMenu();
            menu.ShowDialog();

            while (menu.DialogResult != DialogResult.OK && menu.DialogResult != DialogResult.Abort)
                menu.ShowDialog();

            if (menu.DialogResult == DialogResult.Abort)
            {
                this.Close();
                Application.Exit();
            }
            else
            {
                //Loads the hero into Outils
                if (heroService.IsHeroAvailable(Outils.GetHero().Id))
                {
                    heroService.ConnectDisconnectHeroById(Outils.GetHero().Id, true);
                    Outils.GetHero().EstConnecte = true;
                    try
                    {
                        //Then Show help/Start game
                        this.Enabled = true;
                        this.Show();
                        _gameState = new GameState(ClientSize);
                        connected = true;
                        initialize();
                        Form help = new helpform();
                        help.StartPosition = FormStartPosition.CenterScreen;
                        help.Show();
                        help.Focus();
                    }
                    catch (Exception)
                    {
                        this.Close();
                    }
                }
                else
                {
                    Outils.ShowInfoMessage("A player is currently connected to this Hero. Please choose another Hero that isn't connected.", "Warning!", MessageBoxButtons.OK);
                    ShowMenu();
                }
            }
        }

        private void HugoWorld_FormClosing(object sender, FormClosingEventArgs e)
        {
            _gameState.KeyDown(Keys.Escape);
            if (Outils.GetHero() != null)
                heroService.ConnectDisconnectHeroById(Outils.GetHero().Id, false);
        }
    }
}
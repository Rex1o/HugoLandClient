using HugoWorld.BLL;
using HugoWorld.Vue;
using HugoWorld_Client.Vue;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace HugoWorld {

    public partial class HugoWorld : Form {
        private Stopwatch _timer = new Stopwatch();
        private double _lastTime;
        private long _frameCounter;
        private GameState _gameState;
        private bool connected = false;

        public HugoWorld()
        {
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
                //Perform any animation and updates
                _gameState.Update(gameTime, elapsedTime);

                //Draw everything
                _gameState.Draw(e.Graphics);
            }

            //Force the next Paint()
            this.Invalidate();
        }

        private void Crusader_KeyDown(object sender, KeyEventArgs e)
        {
            _gameState.KeyDown(e.KeyCode);
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
                Login.ShowDialog();

            // Show MainMenu
            frmMenu menu = new frmMenu();
            menu.ShowDialog();

            while (menu.DialogResult != DialogResult.OK && menu.DialogResult != DialogResult.Abort)
                menu.ShowDialog();

            if (menu.DialogResult == DialogResult.Abort)
                this.Close();
            else
            {
                //Loads the hero into Outils
                Outils.SetHero(menu.currentHero);
                //Then Show help/Start game
                this.Enabled = true;
                this.Show();

                connected = true;
                initialize();
                Form help = new helpform();
                help.StartPosition = FormStartPosition.CenterScreen;
                help.Show();
                help.Focus();
            }
        }
    }
}
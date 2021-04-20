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

            //Initialise and start the timer
            _lastTime = 0.0;
            _timer.Reset();
            _timer.Start();
        }

        private void Crusader_Paint(object sender, PaintEventArgs e)
        {
            //Work out how long since we were last here in seconds
            double gameTime = _timer.ElapsedMilliseconds / 1000.0;
            double elapsedTime = gameTime - _lastTime;
            _lastTime = gameTime;
            _frameCounter++;

            //Perform any animation and updates
            _gameState.Update(gameTime, elapsedTime);

            //Draw everything
            _gameState.Draw(e.Graphics);

            //Force the next Paint()
            this.Invalidate();
        }

        private void Crusader_KeyDown(object sender, KeyEventArgs e)
        {
            _gameState.KeyDown(e.KeyCode);
        }

        private void Crusader_Shown(object sender, EventArgs e)
        {
            //Il dit qu'il veut voir l'autre fenêtre derrière donc j'ai mis les
            //forms dans l'event shown masi pour le character selection, il vas falloir modifier le code
            //pcqu'il est intilialisé dans le form initialise (et ici nous somme après cette méthode)

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

            //Loads the hero into the game
            _gameState.LoadHero(menu.currentHero);

            //Then Show help/Start game
            this.Enabled = true;
            Form help = new helpform();
            help.StartPosition = FormStartPosition.CenterScreen;
            help.Show();
            help.Focus();
        }
    }
}
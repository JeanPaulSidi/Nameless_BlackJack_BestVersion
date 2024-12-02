using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nameless_BlackJack
{
    public partial class frmMain : Form
    {
        Card[] CardsArray = new Card[52];

        List<Card> Deck = new List<Card>();

        List<PictureBox> PlayerPictureboxes = new List<PictureBox>();

        List<PictureBox> DealerPictureboxes = new List<PictureBox>();

        Card DealerSecondCard; 

        string PlayerName;

        int PlayerHandValue;
        int DealerHandValue;

        int PlayerScore;
        int DealerScore;

        int TotalPlayedGames;
        int TotalWonGames;
        int TotalLostGames;
        int TotalTies;

        int IndexPlayerPictureboxes;
        int IndexDealerPictureboxes;

        public void CreateCardObjects() 
        {
            CardsArray[0] = new Card(2, Properties.Resources._2_of_clubs);
            CardsArray[1] = new Card(2, Properties.Resources._2_of_diamonds);
            CardsArray[2] = new Card(2, Properties.Resources._2_of_hearts);
            CardsArray[3] = new Card(2, Properties.Resources._2_of_spades);

            CardsArray[4] = new Card(3, Properties.Resources._3_of_clubs);
            CardsArray[5] = new Card(3, Properties.Resources._3_of_diamonds);
            CardsArray[6] = new Card(3, Properties.Resources._3_of_hearts);
            CardsArray[7] = new Card(3, Properties.Resources._3_of_spades);

            CardsArray[8] = new Card(4, Properties.Resources._4_of_clubs);
            CardsArray[9] = new Card(4, Properties.Resources._4_of_diamonds);
            CardsArray[10] = new Card(4, Properties.Resources._4_of_hearts);
            CardsArray[11] = new Card(4, Properties.Resources._4_of_spades);

            CardsArray[12] = new Card(5, Properties.Resources._5_of_clubs);
            CardsArray[13] = new Card(5, Properties.Resources._5_of_diamonds);
            CardsArray[14] = new Card(5, Properties.Resources._5_of_hearts);
            CardsArray[15] = new Card(5, Properties.Resources._5_of_spades);

            CardsArray[16] = new Card(6, Properties.Resources._6_of_clubs);
            CardsArray[17] = new Card(6, Properties.Resources._6_of_diamonds);
            CardsArray[18] = new Card(6, Properties.Resources._6_of_hearts);
            CardsArray[19] = new Card(6, Properties.Resources._6_of_spades);

            CardsArray[20] = new Card(7, Properties.Resources._7_of_clubs);
            CardsArray[21] = new Card(7, Properties.Resources._7_of_diamonds);
            CardsArray[22] = new Card(7, Properties.Resources._7_of_hearts);
            CardsArray[23] = new Card(7, Properties.Resources._7_of_spades);

            CardsArray[24] = new Card(8, Properties.Resources._8_of_clubs);
            CardsArray[25] = new Card(8, Properties.Resources._8_of_diamonds);
            CardsArray[26] = new Card(8, Properties.Resources._8_of_hearts);
            CardsArray[27] = new Card(8, Properties.Resources._8_of_spades);

            CardsArray[28] = new Card(9, Properties.Resources._9_of_clubs);
            CardsArray[29] = new Card(9, Properties.Resources._9_of_diamonds);
            CardsArray[30] = new Card(9, Properties.Resources._9_of_hearts);
            CardsArray[31] = new Card(9, Properties.Resources._9_of_spades);

            CardsArray[32] = new Card(10, Properties.Resources._10_of_clubs);
            CardsArray[33] = new Card(10, Properties.Resources._10_of_diamonds);
            CardsArray[34] = new Card(10, Properties.Resources._10_of_hearts);
            CardsArray[35] = new Card(10, Properties.Resources._10_of_spades);

            CardsArray[36] = new Card(10, Properties.Resources.jack_of_clubs);
            CardsArray[37] = new Card(10, Properties.Resources.jack_of_diamonds);
            CardsArray[38] = new Card(10, Properties.Resources.jack_of_hearts);
            CardsArray[39] = new Card(10, Properties.Resources.jack_of_spades);

            CardsArray[40] = new Card(10, Properties.Resources.king_of_clubs);
            CardsArray[41] = new Card(10, Properties.Resources.king_of_diamonds);
            CardsArray[42] = new Card(10, Properties.Resources.king_of_hearts);
            CardsArray[43] = new Card(10, Properties.Resources.king_of_spades);

            CardsArray[44] = new Card(10, Properties.Resources.queen_of_clubs);
            CardsArray[45] = new Card(10, Properties.Resources.queen_of_diamonds);
            CardsArray[46] = new Card(10, Properties.Resources.queen_of_hearts);
            CardsArray[47] = new Card(10, Properties.Resources.queen_of_spades);

            CardsArray[48] = new Card(11, Properties.Resources.ace_of_clubs);
            CardsArray[49] = new Card(11, Properties.Resources.ace_of_diamonds);
            CardsArray[50] = new Card(11, Properties.Resources.ace_of_hearts);
            CardsArray[51] = new Card(11, Properties.Resources.ace_of_spades);

        }


        public void CreatePlayerpictureboxes() 
        {
            PlayerPictureboxes.Add(pictureBox1);
            PlayerPictureboxes.Add(pictureBox2);
            PlayerPictureboxes.Add(pictureBox3);
            PlayerPictureboxes.Add(pictureBox4);
            PlayerPictureboxes.Add(pictureBox5);
            PlayerPictureboxes.Add(pictureBox6);
            PlayerPictureboxes.Add(pictureBox7);
            PlayerPictureboxes.Add(pictureBox8);
        }

        public void CreateDealerPictureboxes() 
        {
            DealerPictureboxes.Add(pictureBox9);
            DealerPictureboxes.Add(pictureBox10);
            DealerPictureboxes.Add(pictureBox11);
            DealerPictureboxes.Add(pictureBox12);
            DealerPictureboxes.Add(pictureBox13);
            DealerPictureboxes.Add(pictureBox14);
            DealerPictureboxes.Add(pictureBox15);

        }

        public int GenerateRandomNumber(int Max) 
        {
            Random random = new Random();
            int RandomNumber = 0;

            RandomNumber = random.Next(0, Max);
            return RandomNumber;

        }

        public void BuildTheDeckOfCards() 
        {
            Card CardPicked;
            int Index;

            Deck.Clear();

            do 
            {
                Index = GenerateRandomNumber(CardsArray.Length);
                CardPicked = CardsArray[Index];

                if ( ! Deck.Contains(CardPicked) ) 
                {
                    Deck.Add(CardPicked);
                }

            }while ( Deck.Count < CardsArray.Length );


        }

        public Card DealCard() 
        {
            int Index;
            Card CardDealt;

            Index = GenerateRandomNumber(Deck.Count);
            CardDealt = Deck[Index];
            Deck.RemoveAt(Index);
            
            return CardDealt;
        }

        public void DealCardToPlayer() 
        {
            int Index;
            Card NewCard;

            Index = IndexPlayerPictureboxes;
            NewCard = DealCard();
            PlayerHandValue += NewCard.PointValue;
            txtPlayerHandValue.Text = PlayerHandValue.ToString();
            PlayerPictureboxes[Index].Image = NewCard.Image;
            PlayerPictureboxes[Index].Visible = true;

            if (Index > 3) 
            {
                PlayerPictureboxes[Index].BringToFront();
            }

            IndexPlayerPictureboxes++;
        }

        public void DealCardToDealer() 
        {
            int Index;
            Card NewCard;

            Index = IndexDealerPictureboxes;
            NewCard = DealCard();
            DealerHandValue += NewCard.PointValue;
            txtDealerHandValue.Text = DealerHandValue.ToString();
            DealerPictureboxes[Index].Image = NewCard.Image;
            DealerPictureboxes[Index].Visible = true;

            if (Index < 12) 
            {
                DealerPictureboxes[Index].BringToFront();
            }

            IndexDealerPictureboxes++;
        }

        public void UpdateScores() 
        {
            txtDealerScore.Text = DealerScore.ToString();
            txtPlayerScore.Text = PlayerScore.ToString();
        }

        public void CheckPlayerHand() 
        {
            if (PlayerHandValue == 21) 
            {
                lblPlayerName.Text = "Bravo " + PlayerName + ", you win!";
                lblPlayerName.Visible = true;
                PlayerScore++;
                txtPlayerScore.Text = PlayerScore.ToString();
                TotalWonGames++;
                ShowScoreBoard();
                btnNewGame.Visible = true;
                btnExit.Visible = true;
            }
            else if (PlayerHandValue > 21) 
            {
                lblPlayerName.Text = "Sorry " + PlayerName + ", you lose";
                lblPlayerName.Visible = true;
                DealerScore++;
                txtDealerScore.Text = DealerScore.ToString();
                TotalLostGames++;
                ShowScoreBoard();
                btnNewGame.Visible = true;
                btnExit.Visible = true;
            }
            else 
            {
                btnHit.Visible = true;
                btnStand.Visible = true;
            }
            UpdateScores();
        }

        public void CompareBothHandValues() 
        {
            if (DealerHandValue < PlayerHandValue) 
            {
                lblPlayerName.Text = "Bravo " + PlayerName + ", you win!";
                lblPlayerName.Visible = true;
                PlayerScore++;
                TotalWonGames++;
                btnNewGame.Visible = true;
                btnExit.Visible = true;
            }
            else if (DealerHandValue > PlayerHandValue) 
            {
                lblPlayerName.Text = "Sorry " + PlayerName + ", you lose";
                lblPlayerName.Visible = true;
                DealerScore++;
                TotalLostGames++;
                btnNewGame.Visible = true;
                btnExit.Visible = true;
            }
            else 
            {
                lblPlayerName.Text = "It's a tie!";
                lblPlayerName.Visible = true;
                TotalTies++;
                btnNewGame.Visible = true;
                btnExit.Visible = true;
            }
            ShowScoreBoard();
        }

        public void CheckDealerHand() 
        {
            if (DealerHandValue == 21) 
            {
                lblPlayerName.Text = "Sorry " + PlayerName + ", you lose";
                lblPlayerName.Visible = true;
                DealerScore++;
                TotalLostGames++;
                ShowScoreBoard();
                btnNewGame.Visible = true;
                btnExit.Visible = true;
            }
            else if (DealerHandValue > 21) 
            {
                lblPlayerName.Text = "Bravo " + PlayerName + ", you win!";
                lblPlayerName.Visible = true;
                PlayerScore++;
                TotalWonGames++;
                ShowScoreBoard();
                btnNewGame.Visible = true;
                btnExit.Visible = true;

            }
            else 
            {
                CompareBothHandValues();
            }
            UpdateScores();
        }

        public void HidePictureboxes() 
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;

        }

        public void HideScoreBoard() 
        {
            lblScoreboard.Visible = false;
            lblGames.Visible = false;
            lblWon.Visible = false;
            lblLost.Visible = false;
            lblTies.Visible = false;
            txtGames.Visible = false;
            txtWon.Visible = false;
            txtLost.Visible = false;
            txtTies.Visible = false;

        }

        public void ShowScoreBoard() 
        {
            lblScoreboard.Visible = true;
            lblGames.Visible = true;
            lblWon.Visible = true;
            lblLost.Visible = true;
            lblTies.Visible = true;
            txtGames.Visible = true;
            txtWon.Visible = true;
            txtLost.Visible = true;
            txtTies.Visible = true;

            txtGames.Text = TotalPlayedGames.ToString();
            txtWon.Text = TotalWonGames.ToString();
            txtLost.Text = TotalLostGames.ToString();
            txtTies.Text = TotalTies.ToString();
        }

        public void ShowGameBoard() 
        {
            lblDealerCards.Visible = true;
            lblDealerHandValue.Visible = true;
            txtDealerHandValue.Visible = true;
            lblDealerScore.Visible = true;
            txtDealerScore.Visible = true;

            lblPlayerCards.Visible = true;
            lblPlayerHandValue.Visible = true;
            txtPlayerHandValue.Visible = true;
            lblPlayerScore.Visible = true;
            txtPlayerScore.Visible = true;

            lblPlayerName.Visible = false;
            txtPlayerName.Visible = false;

            txtPlayerScore.Text = PlayerScore.ToString();
            txtDealerScore.Text = DealerScore.ToString();
        }

        public void CoverDealerCards() 
        {
            DealerPictureboxes[IndexDealerPictureboxes].Image = Properties.Resources.Back;
            DealerPictureboxes[IndexDealerPictureboxes].Visible = true;


        }

        public void UncoverDealerCard() 
        {

            DealerPictureboxes[IndexDealerPictureboxes - 1].Image = DealerSecondCard.Image;
            DealerHandValue += DealerSecondCard.PointValue;
            txtDealerHandValue.Text = DealerHandValue.ToString();
        }

        public void ResetValues() 
        {
            PlayerHandValue = 0;
            DealerHandValue = 0;

            IndexPlayerPictureboxes = 0;
            IndexDealerPictureboxes = 0;

            txtPlayerHandValue.Text = string.Empty;
            txtDealerHandValue.Text = string.Empty;
        }

        public void InitializeScoreBoard() 
        {
            TotalPlayedGames = 0;
            TotalWonGames = 0;
            TotalLostGames = 0;
            TotalTies = 0;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            btnHit.Visible = false;
            btnStand.Visible = false;

            DealCardToPlayer();
            CheckPlayerHand();
        }

        private void btnStand_Click(object sender, EventArgs e)
        {
            btnStand.Visible = false;
            btnHit.Visible = false;

            UncoverDealerCard();

            while (DealerHandValue < 17)
            {
                DealCardToDealer();
            }

            CheckDealerHand();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (Deck.Count < 7)
            {
                Deck.Clear();
                BuildTheDeckOfCards();
            }

            btnNewGame.Visible = false;
            btnExit.Visible = false;
            lblPlayerName.Visible = false;
            txtPlayerName.Visible = false;
            TotalPlayedGames++;

            ResetValues();
            HidePictureboxes();
            HideScoreBoard();
            ShowGameBoard();

            DealCardToPlayer();

            DealCardToDealer();

            DealCardToPlayer();

            DealerSecondCard = DealCard();
            CoverDealerCards();
            IndexDealerPictureboxes++;

            CheckPlayerHand();


        }

        private void txtPlayerName_TextChanged(object sender, EventArgs e)
        {
            PlayerName = txtPlayerName.Text;
            btnNewGame.Visible = txtPlayerName.TextLength > 0;
           
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            PlayerScore = 0;
            DealerScore = 0;
            InitializeScoreBoard();

            CreateCardObjects();
            CreatePlayerpictureboxes();
            CreateDealerPictureboxes();
            BuildTheDeckOfCards();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

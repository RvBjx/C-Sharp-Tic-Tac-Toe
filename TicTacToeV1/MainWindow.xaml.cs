﻿using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToeV1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Private Members
        /// <summary>
        /// Holds the current results of cells in the active game
        /// </summary>
        private MarkType[] mResults;


        /// <summary>
        /// True if its player 1's turn (X) or player 2's turn (O)
        /// </summary>
        private bool mPlayer1Turn;

        /// <summary>
        /// True if the game has ended
        /// </summary>
        private bool mGameEnd;



        #endregion

        #region Constructor

        /// <summary>
        /// Default consturctor
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();

            NewGame();

        }

        #endregion

        /// <summary>
        /// Starts a new game and clears all values back to the start
        /// </summary>
        #region Starts game
        private void NewGame()
        {
            // Create a new blank array of free cells
            mResults = new MarkType[9];

            for (var i = 0; i < mResults.Length; i++)
                mResults[i] = MarkType.Free;
            // Make sure Player 1 starts the game
            mPlayer1Turn = true;

            // Interate every button on the grid
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                // change content, back- and foreground to default values
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Black; // Normal würde dort Blue hinkommen
            });
            // makes sure that the game hasn't ended
            mGameEnd = false;
        }
        #endregion
        #region Button handler and gap filler
        /// <summary>
        /// Handles a button click event
        /// </summary>
        /// <param name="sender">The button was clicked</param>
        /// <param name="e">The events of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mGameEnd)
            {
                NewGame();
                return;
            }
            // cast the sender to a button
            var button = (Button)sender;

            // find the button position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            // dont do anything if the cell already has a value in it
            if (mResults[index] != MarkType.Free)
                return;

            //set the cell value based on which player turn it is
            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            // set button text to the result
            button.Content = mPlayer1Turn ? "❌" : "◯";

            //change noughts to green
           // if (!mPlayer1Turn)
               // button.Foreground = Brushes.Red; Dieser Teil ist Kommentiert, da dann auch die O s schwarz sind

            // toggle the players turns
            mPlayer1Turn ^= true;

            //checks for a winner
            CheckForWinner();
        }
        #endregion

        //Checks if there is a winner of a 3 line straight
        private void CheckForWinner()
        {
            #region Horizontal wins
            // Check for horizontal wins



            // Row 0
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                // ends game
                mGameEnd = true;
                // Highlight winning cells in green
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.LightGreen;
            }

            // Row 1
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                // ends game
                mGameEnd = true;
                // Highlight winning cells in green
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.LightGreen;
            }

            // Row 2
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                // ends game
                mGameEnd = true;
                // Highlight winning cells in green
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.LightGreen;
            }
            #endregion
            #region Vertical wins
            // Check for vertical wins



            // Column 0
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                // ends game
                mGameEnd = true;
                // Highlight winning cells in green
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.LightGreen;
            }
            
            // Column 1
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                // ends game
                mGameEnd = true;
                // Highlight winning cells in green
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.LightGreen;
            }
            
            // Column 2
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                // ends game
                mGameEnd = true;
                // Highlight winning cells in green
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.LightGreen;
            }
            #endregion
            #region Diagonal wins
            // Check for diagonal wins



            // top left to bottom right
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                // ends game
                mGameEnd = true;
                // Highlight winning cells in green
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.LightGreen;
            }

            // top right to bottom left
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                // ends game
                mGameEnd = true;
                // Highlight winning cells in green
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.LightGreen;
            }

            #endregion

            #region No winners
            if (!mResults.Any(f => f == MarkType.Free) && !mGameEnd)
            {
                mGameEnd = true;
                // Interate every button on the grid
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    // change content, back- and foreground to default values
                    button.Background = Brushes.LightPink;
                });
            }
            #endregion
        }
    }
}

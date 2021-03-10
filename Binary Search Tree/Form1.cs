/* -----------EXECERCISE 2: BINARY SEARCH TREE--------------
 * STUDENT NAME: EMELY DIAZ
 * STUDENT NUMBER: 2018-30326
 * DATE: APRIL 1, 2019
 * 
 * DESCRIPTON
 * In this program, I used windows form to create a program for BST.
 * 8 METHODS (INSERT, DELLETE, MINIMUM, MAXIMUM, SUCESSOR, PREDECESSOR, SEARCH, PRINT).
 * Implement using LinkedList
 
 */

using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace Binary_Search_Tree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BinarySearchTree NewTree;

        private void btnMenu_Click(object sender, EventArgs e)
        {
            NewTree = new BinarySearchTree();//create new tree as empty

            DisPlayMenu();//display the menu

        }

        public string inputNumber;//make the input numbe to be global variable

        public void DisPlayMenu()//THIS WILL BE CALLED MANY TIMES UNTIL THE USER WILL SELECT EXIT
        {
            //POP UP INPUT BOX FOR THE OPTIONS 1 - 5
            //THEN STORE THE INPUT VALUE IN THE inputNumber VARIABLE
            inputNumber = Interaction.InputBox("Please Input Number: \n[1] Insert node to binary tree" +
                "\n[2] Delete node from binary tree \n[3] Minimum \n[4] Maximum \n[5] Successor" +
                "\n[6] Predecessor \n[7] Search \n[8] Print BST \n \n", "Binary Search Tree");
            
            string number;

            // USE SWITCH CASE STATEMENT FOR THE 8 OPTIONS

            switch (inputNumber)
            {

                //IF USER INPUT "1"
                case "1":
                    //INSERT NUMBER
                    number = Interaction.InputBox("Please input the number you want to insert:", "Insert");

                    //accept only integers
                    try
                    {
                        NewTree.InsertNodeNonRC(NewTree, Convert.ToInt16(number));
                    }

                    catch (System.FormatException)
                    {
                        MessageBox.Show("Invalid format. Please input number only.");

                    }

                    DisPlayMenu();//DISPLAY THE MENU

                    break;

                case "2"://delete node


                    number = Interaction.InputBox("Please input the number you want to delete:", "Delete");


                    try
                    {
                        NewTree.Delete(NewTree, Convert.ToInt16(number));
                    }

                    catch (System.FormatException e)
                    {
                        MessageBox.Show("Invalid format. Please input number only.");

                    }

                    DisPlayMenu();//DISPLAY THE MENU

                    break;

                case "3"://search the minimum in the tree
                    NewTree.Minimum(NewTree);
                    DisPlayMenu();
                    break;

                case "4"://search the maximum in the tree
                    NewTree.Maximum(NewTree);
                    DisPlayMenu();
                    break;

                case "5"://find the successor of the specificed value
                    number = Interaction.InputBox("Please input the number you want to search its successor:", "Successor");


                    try
                    {
                        NewTree.Successor(NewTree, Convert.ToInt16(number));
                    }

                    catch (System.FormatException e)
                    {
                        MessageBox.Show("Invalid format. Please input number only.");

                    }

                    DisPlayMenu();//DISPLAY THE MENU

                    break;
                case "6"://find the predecessor of the specificed value
                    number = Interaction.InputBox("Please input the number you want to search its predecessor:", "Predecessor");


                    try
                    {
                        NewTree.Predecessor(NewTree, Convert.ToInt16(number));
                    }

                    catch (System.FormatException e)
                    {
                        MessageBox.Show("Invalid format. Please input number only.");

                    }

                    DisPlayMenu();//DISPLAY THE MENU

                    break;

                case "7"://search value
                    number = Interaction.InputBox("Please input the number you want to search:", "Search");

                    try
                    {
                        NewTree.Search(NewTree, Convert.ToInt16(number));
                    }

                    catch (System.FormatException e)
                    {
                        MessageBox.Show("Invalid format. Please input number only.");

                    }
                    DisPlayMenu();

                    break;

                case "8"://print in asecending order 
                    NewTree.PrintInOrderRC_(NewTree);

                    DisPlayMenu();

                    break;

                default:
                    MessageBox.Show("Please type a valid number.");

                    DialogResult ExitOrNot = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo);


                    if (ExitOrNot == DialogResult.No)//exit the pop up window
                    {
                        DisPlayMenu();
                    }

                    break;
            }

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

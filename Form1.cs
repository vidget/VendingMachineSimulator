//Gregory Norris CIS232 C# Mid Term Vending Machine Simulator

using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Vending_Machine_Simulator___Midterm
{
    public partial class Form1 : Form

    {

//Creates a List of Products called vendingMachine
        List<Product> vendingMachine = new List<Product>();
       
//totalMoneyPutIn is the amount the customer puts in the machine
        Double totalMoneyPutIn = 0.0;

//change is the amount left after purchase
        double change = 0.0;

//item holds the Char value of the button pressed A-H
        char item = (' ');

        double weight = 170.0;
        double calories = 0;
        double weeklyWeight = 0.0;

//Sound Files
        private void ButtonSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.buttonPress);
            simpleSound.Play();
        }

        private void CoinSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.coin);
            simpleSound.Play();
        }

        private void DropSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.candydrop);
            simpleSound.Play();
        }

        private void CoinReturnSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.coinreturn);
            simpleSound.Play();
        }

        private void OutOfStockSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.outofstock);
            simpleSound.Play();
        }

        private void DoorSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.dooropen);
            simpleSound.Play();
        }

        private void ResetChangeLabelData()
        {
            labelChangeLeft.Text = "$0.00";
            labelSmallChange.Text = "$0.00";
            labelThankYou.Visible = false;
        }

        private void ResetCoinInLabelData()
        {
            totalMoneyPutIn = 0.00;
            labelTotalCoins.Text = ("$0.00");
            labelSmallCoinsIn.Text = ("S0.00");
            labelThankYou.Visible = false;
        }

//Sets the vending display data from the Product list and uses an if statement to determine if the product is empty and displays the empty image

        private void SetVendingDisplay()
        {
            labelNameProd1.Text = (vendingMachine[0].Name);
            labelPriceProd1.Text = (vendingMachine[0].Price.ToString("c"));
            labelQtyProd1.Text = (vendingMachine[0].Quantity.ToString());

                if(vendingMachine[0].Quantity<1)
                {
                    pictureBoxEmptyA.Visible = true;
                }


            labelNameProd2.Text = (vendingMachine[1].Name);
            labelPriceProd2.Text = (vendingMachine[1].Price.ToString("c"));
            labelQtyProd2.Text = (vendingMachine[1].Quantity.ToString());

                if (vendingMachine[1].Quantity < 1)
                {
                    pictureBoxEmptyB.Visible = true;
                }

            labelNameProd3.Text = (vendingMachine[2].Name);
            labelPriceProd3.Text = (vendingMachine[2].Price.ToString("c"));
            labelQtyProd3.Text = (vendingMachine[2].Quantity.ToString());

                if (vendingMachine[2].Quantity < 1)
                {
                    pictureBoxEmptyC.Visible = true;
                }

            labelNameProd4.Text = (vendingMachine[3].Name);
            labelPriceProd4.Text = (vendingMachine[3].Price.ToString("c"));
            labelQtyProd4.Text = (vendingMachine[3].Quantity.ToString());

                if (vendingMachine[3].Quantity < 1)
                {
                    pictureBoxEmptyD.Visible = true;
                }

            labelNameProd5.Text = (vendingMachine[4].Name);
            labelPriceProd5.Text = (vendingMachine[4].Price.ToString("c"));
            labelQtyProd5.Text = (vendingMachine[4].Quantity.ToString());

                if (vendingMachine[4].Quantity <1)
                {
                    pictureBoxEmptyE.Visible = true;
                }

            labelNameProd6.Text = (vendingMachine[5].Name);
            labelPriceProd6.Text = (vendingMachine[5].Price.ToString("c"));
            labelQtyProd6.Text = (vendingMachine[5].Quantity.ToString());

                if (vendingMachine[5].Quantity <1)
                {
                    pictureBoxEmptyF.Visible = true;
                }

            labelNameProd7.Text = (vendingMachine[6].Name);
            labelPriceProd7.Text = (vendingMachine[6].Price.ToString("c"));
            labelQtyProd7.Text = (vendingMachine[6].Quantity.ToString());

                if (vendingMachine[6].Quantity <1)
                {
                    pictureBoxEmptyG.Visible = true;
                }

                labelNameProd8.Text = (vendingMachine[7].Name);
                labelPriceProd8.Text = (vendingMachine[7].Price.ToString("c"));
                labelQtyProd8.Text = (vendingMachine[7].Quantity.ToString());

                if (vendingMachine[7].Quantity <1)
                {
                    pictureBoxEmptyH.Visible = true;
                }

        }
        
        private void SetCoinInLabelData()
        {
            labelTotalCoins.Text = totalMoneyPutIn.ToString("c");
            labelSmallCoinsIn.Text = totalMoneyPutIn.ToString("c");
        }

        private void SetChangeLabelData()
        {
            labelChangeLeft.Text = change.ToString("c");
            labelSmallChange.Text = change.ToString("c");
        }

        private void ResetSelection()
        {
            labelSelection.Text = (" ");
            item = (' ');
        }

        private void ResetMachineDoor()
        {
            pictureBoxDoorClosed.Visible = true;
            pictureBoxDoorSnickers.Visible = false;
            doorDoritos.Visible = false;
            doorDrPepper.Visible = false;
            doorSkittles.Visible = false;
            doorPepsi.Visible = false;
            doorHershey.Visible = false;
            doorFunYun.Visible = false;
            doorPB.Visible = false;
            doorEmpty.Visible = false;
        }

        private void PurchaseSequence()
        {
             DropSound();
             SetChangeLabelData();
             ResetCoinInLabelData();
             ResetSelection();
             labelThankYou.Visible = true;
        }

        private void CoinInSequence()
        {
             ResetMachineDoor();
             CoinSound();
             SetCoinInLabelData();
             ResetChangeLabelData();
        }
        
        
        private void weightGain(double calories)
        {

            if (calories >= 1000)
            {
                man1.Visible = false;
                man2.Visible = true;
            }
            if (calories >= 2000)
            {
                man1.Visible = false;
                man2.Visible = false;
                man3.Visible = true;
            }
            if (calories >= 3000)
            {
                man1.Visible = false;
                man2.Visible = false;
                man3.Visible = false;
                man4.Visible = true;
            }

            if (calories >= 4000)
            {
                man1.Visible = false;
                man2.Visible = false;
                man3.Visible = false;
                man4.Visible = false;
                man5.Visible = true;
            }

            if (calories >= 5000)
            {
                man1.Visible = false;
                man2.Visible = false;
                man3.Visible = false;
                man4.Visible = false;
                man5.Visible = false;
                man6.Visible = true;
            }

            if (calories >= 6000)
            {
                man1.Visible = false;
                man2.Visible = false;
                man3.Visible = false;
                man4.Visible = false;
                man5.Visible = false;
                man6.Visible = false;
                man7.Visible = true;
            }


        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

//rawText is the complete line read
            string rawText;

//rawProduct is a string that holds all the elements for 1 products
            string[] rawProducts = new string[3];

//sets the delimiter to ,
            char[] delim = { ',' };

//reads in the JunkFood.csv file
            try
            {
                StreamReader inputFile;

                inputFile = File.OpenText("JunkFood.csv");

                while (!inputFile.EndOfStream)
                        {

                        //create a temp Product to hold on complete products data as it's read in, the tempObjects data is then ADDED to the vendingMachine List
                            Product tempProduct = new Product();
                            
                            rawText = inputFile.ReadLine();
                            rawProducts = rawText.Split(delim);

                            tempProduct.Name = rawProducts[0];
                            tempProduct.Price = Convert.ToDouble(rawProducts[1]);
                            tempProduct.Quantity = Convert.ToInt16(rawProducts[2]);

                            vendingMachine.Add(tempProduct);
                        }
                       inputFile.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SetVendingDisplay();

        }

//SELECTOR BUTTON sets the various labels and sets the ITEM variable to the appropriate CHAR

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonSound();
            ResetMachineDoor();
            labelSelection.Text = ("A");
            labelSmallSelection.Text = ("A");
            item = ('A');
            ResetChangeLabelData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ButtonSound();
            ResetMachineDoor();
            labelSelection.Text = ("B");
            labelSmallSelection.Text = ("B");
            item = ('B');
            ResetChangeLabelData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ButtonSound();
            ResetMachineDoor();
            labelSelection.Text = ("C");
            labelSmallSelection.Text = ("C");
            item = ('C');
            ResetChangeLabelData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ButtonSound();
            ResetMachineDoor();
            labelSelection.Text = ("D");
            labelSmallSelection.Text = ("D");
            item = ('D');
            ResetChangeLabelData();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ButtonSound();
            ResetMachineDoor();
            labelSelection.Text = ("E");
            labelSmallSelection.Text = ("E");
            item = ('E');
            ResetChangeLabelData();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ButtonSound();
            ResetMachineDoor();
            labelSelection.Text = ("F");
            labelSmallSelection.Text = ("F");
            item = ('F');
            ResetChangeLabelData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ButtonSound();
            ResetMachineDoor();
            labelSelection.Text = ("G");
            labelSmallSelection.Text = ("G");
            item = ('G');
            ResetChangeLabelData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ButtonSound();
            ResetMachineDoor();
            labelSelection.Text = ("H");
            labelSmallSelection.Text = ("H");
            item = ('H');
            ResetChangeLabelData();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ButtonSound();
            ResetMachineDoor();
            ResetSelection();
            ResetChangeLabelData();
            labelSmallSelection.Text = (" ");
        }

 //These are the COIN Input pictureBoxes

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            totalMoneyPutIn = totalMoneyPutIn + 1.00;
            CoinInSequence();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            totalMoneyPutIn = totalMoneyPutIn + 0.25;
            CoinInSequence();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            totalMoneyPutIn = totalMoneyPutIn + 0.10;
            CoinInSequence();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            totalMoneyPutIn = totalMoneyPutIn + 0.05;
            CoinInSequence();
        }

//ORDER BUTTON

        private void button1_Click(object sender, EventArgs e)
       
        {
            //turns off the INSERT COIN prompt
            greetingLabel.Visible = false; 
            labelSmallSelection.Text = (" ");
            ResetMachineDoor();
            ResetChangeLabelData();
            SetVendingDisplay();
            
            switch (item)
            {
                case 'A':

                    if (vendingMachine[0].Quantity >= 1)
                        {

                            if (vendingMachine[0].Quantity >= 1 && vendingMachine[0].Price <= totalMoneyPutIn)
                            {
                                change = totalMoneyPutIn - vendingMachine[0].Price;
                                vendingMachine[0].Quantity = vendingMachine[0].Quantity - 1;
                                labelQtyProd1.Text = (vendingMachine[0].Quantity.ToString());

                                PurchaseSequence();

                                calories = calories + 250;
                                weight = weight + 0.5;

                                calorieLabel.Text = calories.ToString();
                                weightLabel.Text = weight.ToString();
                                weeklyWeightLabel.Text = Convert.ToString(.5);

                                weightGain(calories);

//Show the Snickers in Door5
                                pictureBoxDoorClosed.Visible = false;
                                pictureBoxDoorSnickers.Visible = true;
                                SetVendingDisplay();
                                                                
                            }
                            else
                            {
                                OutOfStockSound();
                                MessageBox.Show("Please insert more coins");
                            }

                        }
                        else
                        {
                            OutOfStockSound();
                            MessageBox.Show("Sorry this item is out of Stock");
                            ResetSelection();
                        }
                break;

                case 'B':

                        if (vendingMachine[1].Quantity >= 1)
                        {

                            if (vendingMachine[1].Quantity >= 1 && vendingMachine[1].Price <= totalMoneyPutIn)
                            {
                                change = totalMoneyPutIn - vendingMachine[1].Price;
                                vendingMachine[1].Quantity = vendingMachine[1].Quantity - 1;
                                labelQtyProd2.Text = (vendingMachine[1].Quantity.ToString());

                                PurchaseSequence();


                                calories = calories + 262;
                                weight = weight + .52;
                                calorieLabel.Text = calories.ToString();
                                weightLabel.Text = weight.ToString();
                                weeklyWeightLabel.Text = Convert.ToString(.52);


                                weightGain(calories);
//Show the Doritos in Door
                                pictureBoxDoorClosed.Visible = false;
                                doorDoritos.Visible = true;
                                SetVendingDisplay();

                            }
                            else
                            {
                                OutOfStockSound();
                                MessageBox.Show("Please insert more coins");
                            }

                            
                        }
                        else
                        {
                            OutOfStockSound();
                            MessageBox.Show("Sorry this item is out of Stock");
                            ResetSelection();
                        }
                break;

                case 'C':
                     if (vendingMachine[2].Quantity >= 1)
                        {

                            if (vendingMachine[2].Quantity >= 1 && vendingMachine[2].Price <= totalMoneyPutIn)
                            {
                                change = totalMoneyPutIn - vendingMachine[2].Price;
                                vendingMachine[2].Quantity = vendingMachine[2].Quantity - 1;
                                labelQtyProd3.Text = (vendingMachine[2].Quantity.ToString());



                                PurchaseSequence();

                                calories = calories + 150;
                                weight = weight + 0.40;
                                calorieLabel.Text = calories.ToString();
                                weightLabel.Text = weight.ToString();



                                weightGain(calories);
 //Show the DrPepper in Door
                                pictureBoxDoorClosed.Visible = false;
                                doorDrPepper.Visible = true;
                                SetVendingDisplay();
                            }
                            else
                            {
                                OutOfStockSound();
                                MessageBox.Show("Please insert more coins");
                            }
                        }
                        else
                        {
                            OutOfStockSound();
                            MessageBox.Show("Sorry this item is out of Stock");
                            ResetSelection();
                        }
                break;

                case 'D':
                     if (vendingMachine[3].Quantity >= 1)
                        {

                            if (vendingMachine[3].Quantity >= 1 && vendingMachine[3].Price <= totalMoneyPutIn)
                            {
                                change = totalMoneyPutIn - vendingMachine[3].Price;
                                vendingMachine[3].Quantity = vendingMachine[3].Quantity - 1;
                                labelQtyProd4.Text = (vendingMachine[3].Quantity.ToString());

                                PurchaseSequence();

                                calories = calories + 250;
                                weight = weight + 1.15;
                                calorieLabel.Text = calories.ToString();
                                weightLabel.Text = weight.ToString();



                                weightGain(calories);

 //Show the Skittles in Door


                                pictureBoxDoorClosed.Visible = false;
                                doorSkittles.Visible = true;
                                SetVendingDisplay();



                            }
                            else
                            {
                                OutOfStockSound();
                                MessageBox.Show("Please insert more coins");
                            }
                        }
                        else
                        {
                            OutOfStockSound();
                            MessageBox.Show("Sorry this item is out of Stock");
                            ResetSelection();
                        }
                break;

                case 'E':
                    if (vendingMachine[4].Quantity >= 1)
                        {

                            if (vendingMachine[4].Quantity >= 1 && vendingMachine[4].Price <= totalMoneyPutIn)
                            {
                                change = totalMoneyPutIn - vendingMachine[4].Price;
                                vendingMachine[4].Quantity = vendingMachine[4].Quantity - 1;
                                labelQtyProd5.Text = (vendingMachine[4].Quantity.ToString());

                                PurchaseSequence();

                                calories = calories + 250;
                                weight = weight + 1.15;
                                calorieLabel.Text = calories.ToString();
                                weightLabel.Text = weight.ToString();



                                weightGain(calories);



//Show the Pepsi in Door
                                pictureBoxDoorClosed.Visible = false;
                                doorPepsi.Visible = true;
                                SetVendingDisplay();
                            }
                            else
                            {
                                OutOfStockSound();
                                MessageBox.Show("Please insert more coins");
                            }
                        }
                        else
                        {
                            OutOfStockSound();
                            MessageBox.Show("Sorry this item is out of Stock");
                            ResetSelection();
                        }
                break;

                case 'F':
                    if (vendingMachine[5].Quantity >= 1)
                        {

                            if (vendingMachine[5].Quantity >= 1 && vendingMachine[5].Price <= totalMoneyPutIn)
                            {
                                change = totalMoneyPutIn - vendingMachine[5].Price;
                                vendingMachine[5].Quantity = vendingMachine[5].Quantity - 1;
                                labelQtyProd6.Text = (vendingMachine[5].Quantity.ToString());

                                PurchaseSequence();

                                calories = calories + 250;
                                weight = weight + 1.15;
                                calorieLabel.Text = calories.ToString();
                                weightLabel.Text = weight.ToString();



                                weightGain(calories);

//Show the Hershey in Door
                                pictureBoxDoorClosed.Visible = false;
                                doorHershey.Visible = true;
                                SetVendingDisplay();

                            }
                            else
                            {
                                OutOfStockSound();
                                MessageBox.Show("Please insert more coins");
                            }
                        }
                        else
                        {
                            OutOfStockSound();
                            MessageBox.Show("Sorry this item is out of Stock");
                            ResetSelection();
                        }
                break;

                case 'G':
                    if (vendingMachine[6].Quantity >= 1)
                        {

                            if (vendingMachine[6].Quantity >= 1 && vendingMachine[6].Price <= totalMoneyPutIn)
                            {
                                change = totalMoneyPutIn - vendingMachine[6].Price;
                                vendingMachine[6].Quantity = vendingMachine[6].Quantity - 1;
                                labelQtyProd7.Text = (vendingMachine[6].Quantity.ToString());

                                PurchaseSequence();

                                calories = calories + 250;
                                weight = weight + 1.15;
                                calorieLabel.Text = calories.ToString();
                                weightLabel.Text = weight.ToString();



                                weightGain(calories);

//Show the FunYun in Door
                                pictureBoxDoorClosed.Visible = false;
                                doorFunYun.Visible = true;
                                SetVendingDisplay();
                            }
                            else
                            {
                                OutOfStockSound();
                                MessageBox.Show("Please insert more coins");
                            }
                        }
                        else
                        {
                            OutOfStockSound();
                            MessageBox.Show("Sorry this item is out of Stock");
                            ResetSelection();
                        }
                         break;
                case 'H':
                     if (vendingMachine[7].Quantity >= 1)
                        {

                            if (vendingMachine[7].Quantity >= 1 && vendingMachine[7].Price <= totalMoneyPutIn)
                            {
                                change = totalMoneyPutIn - vendingMachine[7].Price;
                                vendingMachine[7].Quantity = vendingMachine[7].Quantity - 1;
                                labelQtyProd8.Text = (vendingMachine[7].Quantity.ToString());

                                PurchaseSequence();

                                calories = calories + 250;
                                weight = weight + 1.15;
                                calorieLabel.Text = calories.ToString();
                                weightLabel.Text = weight.ToString();



                                weightGain(calories);

 //Show the Peanut Butter Cookies in Door
                                pictureBoxDoorClosed.Visible = false;
                                doorPB.Visible = true;
                                SetVendingDisplay();

                            }
                            else
                            {
                                OutOfStockSound();
                                MessageBox.Show("Please insert more coins");
                            }
                        }
                        else
                        {
                            OutOfStockSound();
                            MessageBox.Show("Sorry this item is out of Stock");
                            ResetSelection();
                        }
                         break;
                    
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ResetChangeLabelData();
            ResetCoinInLabelData();
        }

        private void buttonCancel_Click(object sender, EventArgs e)

        {
            greetingLabel.Visible = true;
            ResetMachineDoor();
            ResetCoinInLabelData();
            ResetSelection();
            ResetChangeLabelData();
        }

        private void doorFunYun_Click(object sender, EventArgs e)
        {
            DoorSound();
            ResetMachineDoor();
        }

        private void doorPB_Click(object sender, EventArgs e)
        {
            DoorSound();
            ResetMachineDoor();
        }

        private void pictureBoxDoorSnickers_Click(object sender, EventArgs e)
        {
            DoorSound();
            ResetMachineDoor();
        }

        private void doorDoritos_Click(object sender, EventArgs e)
        {
            DoorSound();
            ResetMachineDoor();
        }

        private void doorDrPepper_Click(object sender, EventArgs e)
        {
            DoorSound();
            ResetMachineDoor();
        }

        private void doorSkittles_Click(object sender, EventArgs e)
        {
            DoorSound();
            ResetMachineDoor();
        }

        private void doorHershey_Click(object sender, EventArgs e)
        {
            DoorSound();
            ResetMachineDoor();
        }

        private void doorPepsi_Click(object sender, EventArgs e)
        {
            DoorSound();
            ResetMachineDoor();
        }

        private void pictureBoxDoorClosed_Click(object sender, EventArgs e)
        {
            pictureBoxDoorClosed.Visible = false;
            doorEmpty.Visible = true;
            DoorSound();
        }

        private void doorEmpty_Click(object sender, EventArgs e)
        {
            pictureBoxDoorClosed.Visible = true;
            doorEmpty.Visible = false;
            DoorSound();
        }

        
    }
}

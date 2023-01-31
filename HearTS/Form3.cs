using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CognitiveServices.Speech;
using Firebase.Database;
using Firebase.Database.Query;


namespace HearTS
{
    public partial class Form3 : Form
    {
        private Button[] buttons;
        private Random rand;
        private Button randomButton;
       
        List<string> wordList = new List<string>();
        List<string> shuffledWords = new List<string>();
        
        public Form3()
        {
            InitializeComponent();
            this.MaximizeBox = false;

                 
            buttons = new Button[] { button1, button2, button3, button4 };
            rand = new Random();
          
          
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            getWords();
            ButtonDisable();

        }
        private void button5_Click(object sender, EventArgs e)
        {

            seslendir();
           
            ButtonEnable();


        }
        public async void getWords()
        {
           
            // Firebase bağlantısı için gerekli bilgiler
            var firebase = new FirebaseClient("https://hearts-8187c-default-rtdb.firebaseio.com/");
            var wordData= await firebase.Child("words").OnceAsync<string>();
            //buttons = new Button[] { button1, button2, button3, button4 };

            foreach (var data in wordData)
            {
                wordList.Add(data.Key);
            }
            //rand = new Random();

        }

        public void shuffle(List<string>wordList)
        {
            shuffledWords = wordList.OrderBy(x => rand.Next()).ToList();
            for (int i = 0; i < buttons.Length; i++)
            {

                buttons[i].Text = shuffledWords[i];

            }
            
        }





        private async void seslendir()
        {

            shuffle(wordList);           
            //buttons = new Button[] { button1, button2, button3, button4 };
            randomButton = buttons[rand.Next(buttons.Length)];

            // Azure Speech Services kullanmak için gerekli olan kimlik bilgileri
            string subscriptionKey = "37acc756bb794815b919566626818017";
            string serviceRegion = "eastus";

            var config = SpeechConfig.FromSubscription(subscriptionKey, serviceRegion);
            config.SpeechSynthesisLanguage = "tr-TR";
            var synthesizer = new SpeechSynthesizer(config);
            var result = await synthesizer.SpeakTextAsync(randomButton.Text);

            if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                MessageBox.Show($"CANCELED: Reason={cancellation.Reason}");
            }
            
        }


        private void button10_Click(object sender, EventArgs e)
        {
            Form1 geri = new Form1();
            geri.Show();
            this.Hide();
        }



        private void button1_Click(object sender, EventArgs e)
        {

            var clickedButton = (Button)sender;
            if (clickedButton.Text == randomButton.Text)
            {

                MessageBox.Show("Doğru!", "HearTS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ButtonDisable();

                System.Threading.Thread.Sleep(1000);

                seslendir();


                ButtonEnable();

            }
            else
            {

                MessageBox.Show("Yanlış!","HearTS",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            if (clickedButton.Text == randomButton.Text)
            {

                MessageBox.Show("Doğru!","HearTS",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
                ButtonDisable();

                System.Threading.Thread.Sleep(1000);

                seslendir();

                ButtonEnable();
            }
            else
            {

                MessageBox.Show("Yanlış!", "HearTS", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            if (clickedButton.Text == randomButton.Text)
            {

                MessageBox.Show("Doğru!", "HearTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ButtonDisable();

                System.Threading.Thread.Sleep(1000);

                seslendir();

                ButtonEnable();

            }
            else
            {

                MessageBox.Show("Yanlış!", "HearTS", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error); 
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            if (clickedButton.Text == randomButton.Text)
            {

                MessageBox.Show("Doğru!", "HearTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ButtonDisable();

                System.Threading.Thread.Sleep(1000);

                seslendir();

                ButtonEnable();

            }
            else
            {

                MessageBox.Show("Yanlış!", "HearTS", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void ButtonEnable()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void ButtonDisable()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        

    }
}

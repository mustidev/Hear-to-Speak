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
    public partial class Form2 : Form
    {

        List<string> wordList = new List<string>();
        List<string> shuffledWords = new List<string>();
        private Button[] buttons;

        public Form2()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            fireBaseDB();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private async void fireBaseDB()
        {
            var firebase = new FirebaseClient("https://hearts-8187c-default-rtdb.firebaseio.com/");
            var wordData = await firebase.Child("words").OnceAsync<string>();

            foreach (var data in wordData)
            {
                wordList.Add(data.Key);
            }
            buttons = new Button [] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (Button button in buttons)
            {
                button.Click += new EventHandler(Button_Click);


            }
            Random rand = new Random();
            shuffledWords = wordList.OrderBy(x => rand.Next()).ToList();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Text = shuffledWords[i];
            }
        }

   
        private void Form2_Load(object sender, EventArgs e)
        {

            System.Threading.Thread.Sleep(1000);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1 geri = new Form1();
            geri.Show();
            this.Hide();
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            // Your subscription key and service region

            string subscriptionKey = "37acc756bb794815b919566626818017";
            string serviceRegion = "eastus";


            // Create a config with the subscription key and service region
            var config = SpeechConfig.FromSubscription(subscriptionKey, serviceRegion);

            // Set the language to Turkish
            config.SpeechSynthesisLanguage = "tr-TR";

            // Create a synthesizer
            var synthesizer = new SpeechSynthesizer(config);

            // Get the text from button
            Button button = (Button)sender;
            string text = button.Text;

            // Speak the text
            var result = await synthesizer.SpeakTextAsync(text);

            // Check for errors

            if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                MessageBox.Show($"CANCELED: Reason={cancellation.Reason}");
            }
        }

    }


}

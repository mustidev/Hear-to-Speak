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
    public partial class Form4 : Form
    {       
        private Random rand;
        List<string> wordList = new List<string>();
        List<string> shuffledWords = new List<string>();
        FirebaseClient firebase;
        public Form4()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            rand = new Random();
            
        }
        private async void Form4_Load(object sender, EventArgs e)

        {
            // Firebase biçin gerekli bağlantılar 
            firebase = new FirebaseClient("https://hearts-8187c-default-rtdb.firebaseio.com/");
            var wordData = await firebase.Child("words").OnceAsync<string>();
            foreach (var data in wordData)
            {
                wordList.Add(data.Key);
            }
            SetRandomWords();


        }
        private void button10_Click(object sender, EventArgs e)
        {
            Form1 geri = new Form1();
            geri.Show();
            this.Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            

            // Azure Speech Services kullanmak için gerekli olan kimlik bilgileri
            var subscriptionKey = "Your_Subscription_Key";   
            var region = "eastus";

            var config = SpeechConfig.FromSubscription(subscriptionKey, region);

            config.SpeechRecognitionLanguage = "tr-TR";
            
            using (var recognizer = new SpeechRecognizer(config))
            {

                var result = await recognizer.RecognizeOnceAsync();

                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                   
            
                    if (result.Text.ToLower().Substring(0, result.Text.Length-1)==(label2.Text.ToLower().ToString()))
                    {
                        MessageBox.Show("Doğru!", "HearTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetRandomWords();
                    }
                    else
                    {
                        MessageBox.Show("Yanlış! Tekrar Deneyin..", "HearTS",MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                else if (result.Reason == ResultReason.NoMatch)
                {
                    MessageBox.Show("Üzgünüz, konuşma tanınmadı.","HearTS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }

                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(result);
                    MessageBox.Show($"Cancelled due to {cancellation.Reason}");
                }
            }

        }

        private void SetRandomWords()
        {
            shuffledWords = wordList.OrderBy(x => rand.Next()).ToList();
            for (int i = 0; i < wordList.Count; i++)
            {
                label2.Text = shuffledWords[i];
            }

        }


    }
}

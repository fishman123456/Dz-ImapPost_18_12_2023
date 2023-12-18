using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace DzпImapPost_18_12_2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static string Code;
        
        // генератор случайных 6 символов
        public static string GenRand()
        {
            // создаём обьект под хранение случайных чисел
            Random rnd = new Random();
            // создаём константную строку для выбора случайных символов
            const string chars = "0123456789";
            // https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
            return new string(Enumerable.Repeat(chars,6)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
        public static string SendPost(string userPost, string randCode)
        {
            // создание клиента
            SmtpClient smtpClient = new SmtpClient("smtp.mail.ru");
            // номер порта
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;                   //     ящик           временный пароль( вторичный пароль)
            smtpClient.Credentials = new NetworkCredential("A_Fiscman@list.ru", "ittEHuHPF0TDK19ZqAT2");
            // отправка сообщения     откуда        куда        заголовок    тело
            smtpClient.Send("A_Fiscman@list.ru", userPost, "код для регистрации", randCode);
            return randCode;
        }
        
        private void buttSend_Click(object sender, RoutedEventArgs e)
        {
            // берем ящик введенный пользователем
            string userPost = textboxPost.Text;
            // 
            string randCode = GenRand();
            SendPost(userPost,randCode);
            Code = randCode;
            
        }

        private void buttReg_Click(object sender, RoutedEventArgs e)
        {
            // проверяем код введенный пользователем 
            if (Code == textboxPass.Text)
            {
                MessageBox.Show("You win");
            }
        }
    }
}
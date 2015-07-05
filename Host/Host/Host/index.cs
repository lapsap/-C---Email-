using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Diagnostics; // for debugging logging

namespace Host
{
    public partial class index : Form
    {
        // wamp stuff
        private static MySql.Data.MySqlClient.MySqlConnection conn;
        private static string wampid = "root";
        private static string wamppass = "";
        private static string wampdb = "lapmail";
        private static string wampserver = "localhost";
        //
        const int PORT_NO = 5000;   //Port number to conenct
        const string SERVER_IP = "127.0.0.1";   //host ip;;;;
        TcpClient client;
        NetworkStream nwStream;
        //
        IPAddress localAdd = IPAddress.Parse(SERVER_IP);
        TcpListener listener;
        Thread threadClient;    //for continuesly listening for data input

        public index()
        {
            InitializeComponent();
            //
            try
            {
                listener = new TcpListener(localAdd, PORT_NO);
                listener.Start();           //start the server  
                threadClient = new Thread(serverListen);    //which void should this thread be link  to 
                threadClient.Start();   //start listening for data
            }
            catch (Exception ex)
            {
                Debug.WriteLine("host, index() error" );
            }
        }
        //
        private static void ConnectDatabase()   //connect to database void 
        {
            string cn = "server="+wampserver+"; user id="+wampid+"; password="+wamppass+"; database="+wampdb+"";
            conn = new MySql.Data.MySqlClient.MySqlConnection(cn);
            conn.Open();
        }
        //
        public static void sqlpost(string input)
        {
            ConnectDatabase();

            // string mySelectQuery = "INSERT INTO lapsap (name,comment) VALUES ('chris','this is a comment')";
            MySqlCommand filmsCommand = new MySqlCommand(input, conn);

            filmsCommand.ExecuteNonQuery();
            filmsCommand.Connection.Close();

            conn.Close();
        }
        //
        public static string sqlgetuser(string user,string pass,string name,string function)
        {
            try
            {
                //check if user exits
                ConnectDatabase();
                string mySelectQuery = "SELECT pass,username FROM user WHERE username = '"+user+"'";
                MySqlCommand filmsCommand = new MySqlCommand(mySelectQuery, conn);
                string result = "oopps";
                bool userExits = false;

                MySqlDataReader reader = filmsCommand.ExecuteReader();

                string username,password = "" ;
                try //if user exit,for checking password
                {
                    reader.Read();
                    username = reader.GetString("username");
                    password = reader.GetString("pass");
                    userExits = true;
                }
                catch  // if user dont exits, for creating new user
                {
                    Debug.WriteLine("host/index/sqlgetuser error"); 
                    //MessageBox.Show("hehe");
                }
                filmsCommand.Connection.Close();//close db connection

                //logic
                if (function == "make") // make new user
                {
                    if (userExits) return "User Already Exits !"; //return value if a username already exits
                    else
                    {
                        try
                        {
                            sqlpost("INSERT INTO user (name,username,pass) VALUES ('" + name + "','" + user + "','" + pass + "')"); // create the user
                            return "User Created !";
                        }
                        catch
                        {
                            return "fail to create user";
                        }
                    }
                }
                else if (function == "login")
                {
                    if (!userExits) return "nouser";
                    else
                    {
                        if (pass == password) return "pass";
                        else return "fail";
                    }
                }
              
                
               
                return result;
            }
            catch (Exception ex)
            {
               // Debug.WriteLine(ex);
                
                MessageBox.Show(ex.ToString());
                return "";
            }
        }
        //
        public static string makeUser(string name, string user, string pass)
        {
            string check = sqlgetuser(user, pass, name, "make");

            return check;
        }
        //
        delegate void setTextCallBack(string input);    //method for outside thread to write in text field
        public void addText(string input)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                setTextCallBack d = new setTextCallBack(addText);
                this.Invoke(d, new object[] { input });
            }
            else
            {
                richTextBox1.Text += input + "\n";
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
            }
        }
        //
        private void processData(string input)
        {
            string[] split = new string[] { "!@#$%" };
            string[] temp = input.Split(split, StringSplitOptions.None);
            int to = Int16.Parse(temp[0]);

            switch (to)
            {
                case 1 :
                    checkPass(temp[1],temp[2]);
                    break;
            }


        }
        //
        private void serverSend(string input)
        {
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(input);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
        }
        //
        public void serverListen()  // get data 
        {
            while (true)    //need to change
            {       
                try
                {
                    client = listener.AcceptTcpClient();  // wait for connection
                    //---get the incoming data through a network stream---
                    nwStream = client.GetStream();
                    byte[] buffer = new byte[client.ReceiveBufferSize];

                    //---read incoming stream---
                    int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
                    //---convert the data received into a string---
                    string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
              

                    processData(dataReceived); // see what to do with the data(addUser,newMail,readMail...)
                    addText(dataReceived);  // add to text fielddd

                    client.Close();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("serverListen() error");
                    Debug.WriteLine("Host, serverListen() error " + ex); 
                }
            }
        }
        //
        private void button1_Click(object sender, EventArgs e) // for testing only
        {
            sqlpost("INSERT INTO user (name,username,pass) VALUES ('chris','hihitan','password')");

            string textToSend = DateTime.Now.ToString();

            //---create a TCPClient object at the IP and port no.---
            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            NetworkStream nwStream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

            //---send the text---
            //      Console.WriteLine("Sending : " + textToSend);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
            client.Close();
        }
        //
       
        private void index_FormClosed(object sender, FormClosedEventArgs e)
        {
            listener.Stop();
            threadClient.Abort();
        }
        
        //
        private void checkPass(string user, string pass)
        {
            string result = sqlgetuser(user, pass, "-1", "login");
            serverSend(result);
        }
        //
        private void sendMail(string dateTime, string from, string to, string ip, string subject, string msg)
        {

        }
        //
        private string readMail(string user,int ID)
        {
            string result = " ";
            return result;
        }
        //
        private void deleteMail(string user,int ID)
        {

        }
        //
        private string listMail(string user, int ID)
        {
            string result = " ";
            return result;
        }

        private void btn_addUser_Click(object sender, EventArgs e)
        {
            addUser formAddUser = new addUser();
            formAddUser.Show();
        }
        //
        

    }
}

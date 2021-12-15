using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulation
{
    public class OnlyCodeSimulation
    {

        private bool working = false;
        private int countUser = 0;


        public void SimpleGenerateUser() 
        {
            string login, password, name, test;

            string[] Arrlogin = { "Abdul228", "Axmed438", "Dudon336", "KireyaBitcoin" };   
            string[] Arrpassword = { "Qu3jdh", "okH84N", "Pkijf94", "Fsndb72" };           
            string[] Arrname = { "Имя1", "Имя2", "Имя3", "Имя4" };                         
            string[] Arrtest = { "Ещё_данные", "Ещё_данные", "Ещё_данные", "Ещё_данные" };

            Random random = new Random();

            while (working)
            {

                login = Arrlogin[random.Next(0, Arrlogin.Length - 1)];
                password = Arrpassword[random.Next(0, Arrpassword.Length - 1)];
                name = Arrname[random.Next(0, Arrname.Length - 1)];
                test = Arrtest[random.Next(0, Arrtest.Length - 1)];

                
                countUser++; 

                //Расскоментировать если работаете из формы
               // labelCount.Invoke(new Action(() => labelCount.Text = countUser.ToString())); 


                Thread.Sleep(1000); 

            }



        }




        private void Start() 
        {
            working = true; 
            Task.Run(() => SimpleGenerateUser()); 
        }

        private void Stop()
        {
            working = false;
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {

            Start();

        }

        private void buttonStop_Click(object sender, EventArgs e) 
        {
            Stop(); 

        }


    }
}

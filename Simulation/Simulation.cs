using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    public partial class Simulation : Form
    {
        public Simulation()
        {
            InitializeComponent();
        }

        private bool working = false; // Переменая, которая принимает значение TRUE - FALSE, с помощью ее цикл генерации будет работать пока он не станет FALSE
        private int countUser = 0; // Переменая, которая будет считать кол-во сгенерированных пользователей





        public void SimpleGenerateUser() // самая обычная симуляция регистрации ваших Юзеров
        {
            string login, password, name, test; // переменные в которые у нас записывается рандомное значение из массивов ниже

            /// Массивы с рандомными даннами для рандомной генерации пользователей

            string[] Arrlogin = { "Abdul228", "Axmed438", "Dudon336", "KireyaBitcoin" };   //Ваши Логины
            string[] Arrpassword = { "Qu3jdh", "okH84N", "Pkijf94", "Fsndb72" };           //Ваши Пароли
            string[] Arrname = { "Имя1", "Имя2", "Имя3", "Имя4" };                         //Ваши Имена
            string[] Arrtest = { "Ещё_данные", "Ещё_данные", "Ещё_данные", "Ещё_данные" }; //Ещё какие-то данные(телефон, прописка, пасп. данные и тд.)

            //--------------------------------------------------------------------------------------------------------------------------------------------------------//

            Random random = new Random(); // переменная для вызова метода Next(), который генерирует рандомное число



            // Тут у нас цикл, в котором и будет происходить вся "МАГИЯ"

            while (working) // Если working = TRUE, то наш цикл начинает работать и генерировать данные
            {

                /*
                 Тут мы при каждом проходе цикла записываем новое значение в переменные, забирая из массивов одно рандомное значение
                ПРИМЕР: 
                этот кусок кода random.Next(0, Arrlogin.Length - 1) у нас сгенерировал число 2 , значит в переменную login запишется значение - Dudon336 и тп.
                 */
                login = Arrlogin[random.Next(0, Arrlogin.Length - 1)];
                password = Arrpassword[random.Next(0,Arrpassword.Length - 1)];
                name = Arrname[random.Next(0,Arrname.Length - 1)];
                test = Arrtest[random.Next(0,Arrtest.Length - 1)];

                //--------------------------------------------------------------------------------------------------------------------------------------------------------//

                // После того как мы записали во все переменные рандомные данные и у нас получается что-то типо: login = Dudon336, password = Fsndb72 нам нужно занести эти значения в БД

                /*
                  
                 ТУТ нужно вызвать функцию, которая это внесёт в БД, тк все используют разные БД не могу привести какой-то единый вариант
                 
                */
                countUser++; // Тк мы сгенерировали одного пользователя увеличиваем переменную на 1 P.S - при каждом новом проходе чикла она будет дальше увеличиваться


                labelCount.Invoke(new Action(() => labelCount.Text = countUser.ToString())); // Выводим кол-во сгенерированных пользователей на форму


                Thread.Sleep(1000); // "Перерыв" между генерацией, то есть если 1000мс, то каждую секунду будет генерироваться один Юзер




            }
        }


        private void Start() // Функция запуска генерации
        {
            working = true; // устанавливая значение True мы запускаем генерацию
            Task.Run(() => SimpleGenerateUser()); // Запускаем наши функцию генерации в отдельном потоке (НЕ ВНИКАЙТЕ, ПРОСТО ТАК НАДО)
        }

        private void Stop()// Функция остановки генерации
        {
            working = false; // устанавливая значение False мы останавливаем генерацию
        }


        private void buttonStart_Click(object sender, EventArgs e) // функция нажатия кнопки Старт
        {

            Start(); // вызывая функцию Start() мы запускаем генерацию

        }

        private void buttonStop_Click(object sender, EventArgs e) // функция нажатия кнопки Стоп
        {
            Stop(); // вызывая функцию Stop() мы останавливаем генерацию

        }
    }
}

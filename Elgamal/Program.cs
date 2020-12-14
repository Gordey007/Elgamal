using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgamal
{

    class Program
    {
       
        static void Main(string[] args)
        {
            // выбор параметров
            // p - простое число
            long p = 227;
            // первообразный корень по модулю p и меньше p
            long g = 2;

            // Боб
            // cb - секретное число боба
            // 1 < cb < p—1
            long cb = 223;

            // рассчет открытого числа Боба
            long db = Convert.ToInt64(Math.Pow(g, cb) % p); 

            // алиса шифрует
            // 1 < k < p - 1
            // 1 <= k <= p - 2
            // 1 < k < p - 2 
            //int k = rnd.Next(2, p-1);
            long k = 7;

            // рассчет открытого числа Алисы
            long r = Convert.ToInt64(Math.Pow(g, k) % p);

            // messeng хранит собщение
            string messeng;

            Console.Write("Введите тексто, который хотите зашифровать шифром Эль Гамаля и отправить Бобу: ");
            // ввод с клавиатуры
            messeng = Console.ReadLine();

            // массив байд (коды символов) 
            // character_code хранит коды символов текста
            byte[] character_code = Encoding.UTF8.GetBytes(messeng);
            // encrypted_character_code хранит зашифрованные коды символов 
            byte[] encrypted_character_code = character_code;
            // decryption_character_code хранит расшифрованные коды символов
            byte[] decryption_character_code = encrypted_character_code;

            // шифрование
            for (int i = 0; i < character_code.Length; i++)
            {
                //Console.WriteLine(character_code[i]);
                                            // вызов метода шифрования и отправление нужных параметров
                encrypted_character_code[i] = encryption(character_code[i], p,g,db,k);
             
            }

            //преобразование кодов символов в символы и запись в строковую переменную byte_messeng
            //Encoding.UTF8.GetString(encrypted_character_code) - преобразование
            string encrypted_messeng = Encoding.UTF8.GetString(encrypted_character_code);
            
            //вывод в консоль 
            Console.WriteLine("Боб получил, судя повсему, шифрованный текст от Алисы: "+ encrypted_messeng);

            // дешифрование
            for (int i = 0; i < character_code.Length; i++)
            {
                //Console.WriteLine(character_code[i]);
                                              // вызов метода дешифрования и отправление нужных параметров
                decryption_character_code[i] = decryption(encrypted_character_code[i], r,p, cb);
            }

            // запись в строковую переменную decryption_messeng преобразованые расшифрованые коды символов в символы
            // Encoding.UTF8.GetString(decryption_character_code) - преобразование
            string decryption_messeng = Encoding.UTF8.GetString(decryption_character_code);
            Console.WriteLine("Боб дешифровал сообщение от Алисы: " + decryption_messeng);
        }
        
        // метод шифрование
        public static byte encryption(byte character_code, long p, long g, double db, long k)
        {
            
            
            // mc - полученый код символа, mc < p
            long mc = character_code;

            // шифрование кода символа
            long e = Convert.ToInt64(mc * Math.Pow(db, k) % p);

            // запись в байтовую переменую шифрованый код символа 
            byte encrypted_character_code = (byte)e;

            //возращение шифрованый код символа
            return (encrypted_character_code);
        }


        public static byte decryption(byte encrypted_character_code, long r, long p, long cb)
        {

            // дешифрование
            long messeng = Convert.ToInt64(encrypted_character_code * Math.Pow(r, p - 1 - cb) % p);

            // запись в байтовую переменую дешифрованый код символа 
            byte decryption_character_code = (byte)messeng;

            //возвращение дешифрованый код символа
            return (decryption_character_code);
        }

    }
}

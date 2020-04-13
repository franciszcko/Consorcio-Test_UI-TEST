using OpenQA.Selenium;
using EAAutoFramework.Base;
using EAAutoFramework.Config;
using System.IO;
using NUnit.Framework;
using EAAutoFramework.Helpers;
using System.Security.Cryptography;
using System.Text;
using System;

namespace EAAutoFramework.Helpers
{
    public class Util 
    {
    
        public Util () { }
        public static void TakeScreenshot (ParallelConfig driver, string feature,string scenario)
        {
            Screenshot screenshot = driver.Driver.GetScreenshot();
            string screenshotFile = Path.Combine(TestContext.CurrentContext.WorkDirectory,"[Feature]"+feature+"[Scenario]"+scenario+".png");
            LogHelpers.WriteSteps("(Se realiza captura de pantalla...)",feature,scenario);
            screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(screenshotFile, scenario);

        }
        public string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Settings.Key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Settings.Key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        // espacios, se refiere a espacios en blanco despues del caracter especial que estamos buscando, para que nos los considere la selección del texto
        //dirección indicar con => para derecha o con <= para izquierda
        public static string SearchTextInString(char xChar, string textString, int espacios, string direccion)
        {

            string text;

            if (direccion.CompareTo("=>") == 0)
            {

                int index = textString.IndexOf(xChar);
                text = textString.Substring(index + espacios + 1);

            }
            else if (direccion.CompareTo("<=") == 0)
            {

                int index = textString.IndexOf(xChar);
                int length = textString.Length;
                text = textString.Substring(0, index - espacios);

            }
            else
                text = "revise las instrucciones de uso del metodo";
          
            return text;

        }
        

    }
}

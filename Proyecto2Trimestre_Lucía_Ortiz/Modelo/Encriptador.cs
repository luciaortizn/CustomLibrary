﻿using System.Security.Cryptography;
using System.Text;

namespace Proyecto2Trimestre_Lucía_Ortiz.Modelo {
    public class Encriptador
    {
        public static string ObtenerHash(string input)
        {
            
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // convertir a bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // hacer cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }


}
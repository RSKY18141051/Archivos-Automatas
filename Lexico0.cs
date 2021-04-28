using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Archivos
{
    class Lexico0 : IDisposable
    {
        private StreamReader archivo;
        private StreamWriter bitacora;

        public Lexico0()
        {
            Console.WriteLine("Compilando prueba.txt");
           
            if (File.Exists("C:\\Archivos\\prueba.txt"))
            {
                archivo = new StreamReader("C:\\Archivos\\prueba.txt");
                bitacora = new StreamWriter("C:\\Archivos\\prueba.log");
                bitacora.AutoFlush = true;
                bitacora.WriteLine("Archivo: prueba.txt");
                bitacora.WriteLine("Directorio: C:\\Archivos");
            }
            else
            {
                throw new Exception("El archivo prueba.txt no existe.");
            }
        }
        
        //~Lexico0()
        public void Dispose()
        {
            Console.WriteLine("\n Finaliza compilacion de prueba.txt");
            CerrarArchivos();
            //Console.ReadKey();
        }

        private void CerrarArchivos()
        {
            archivo.Close();
            bitacora.Close();
        }

        public void Display()
        {
            while (!archivo.EndOfStream)
            {
                Console.Write((char) archivo.Read());
            }
        }

        public void Display2()
        {
            while (!archivo.EndOfStream)
            {
                Console.Write((char)archivo.Peek());
                archivo.Read();
            }
        }

        public void Load()
        {
            while (!archivo.EndOfStream)
            {
                bitacora.Write((char)archivo.Read());
            }
        }

        public void Encrypt()
        {
            while (!archivo.EndOfStream)
            {
                char c;
                if (char.IsLetter(c = (char)(archivo.Read())))
                {
                    bitacora.Write((char)(c + 1));
                }
                else
                {
                    bitacora.Write(c);
                }

                //bitacora.Write((char)(archivo.Read()+1));
            }
        }

        public void Mosca(char letra)
        {
            while (!archivo.EndOfStream)
            {
                char c;
                if (char.IsLetter(c = (char)(archivo.Read())))
                {
                    if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                    {
                        c = letra;
                    }
                }

                bitacora.Write((char)(c));
            }
        }

        public void Encrypt2()
        {
            while (!archivo.EndOfStream)
            {
                char c;
                if (char.IsLetter(c = (char)(archivo.Peek())))
                {
                    bitacora.Write((char)(c + 1));
                }
                else
                {
                    bitacora.Write(c);
                }

                archivo.Read();
            }
        }

        public void Token() //antes conocido como palabra
        {
            char c;
            string palabra = "";

            while (char.IsWhiteSpace(c = (char)archivo.Read()))
            {
                //Este ciclo busca el primer caracter valido :)
            }

            palabra += c; //Es lo mismo que el palabra que esta dentro del if de abajo
            if (char.IsLetter(c))
            {
                //Encontro una letra :D
                //palabra += c;

                while (char.IsLetter(c = (char)archivo.Peek()))
                {
                    //Concatenar mas letras para formar la palabra :O
                    palabra += c;
                    archivo.Read();
                }
            }
            else if (char.IsDigit(c))
            {
                //Si no es letra es otro caracter
                while (char.IsDigit(c = (char)archivo.Peek()))
                {
                    //Concatenar mas letras para formar la palabra :O
                    palabra += c;
                    archivo.Read();
                }
            }
            bitacora.WriteLine("Token = " + palabra);
            /* //Hace lo mismo que el bitacora de arriba tecnicamente
            if (palabra !="")
            {
                bitacora.WriteLine("Palabra = " + palabra);
            }
            */
        }

        public bool FinArchivo()
        {
            return archivo.EndOfStream;
        }
    }
}

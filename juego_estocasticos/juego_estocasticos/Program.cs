using System;

namespace juego_estocasticos
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random aleatorio = new Random();
            int carta1 = 0, carta2 = 0, nuevacarta = 0, total = 0, jugadores = 0, n = 0;
            string continuar = "";

            //Cambio
            int[] CambioDeEstados = new int[21];
            int Posicion = 1;
            int TamañoImpresion = 0;
            CambioDeEstados[0] = 0;

            Console.WriteLine("Ingresa el número de jugadores (minimo 2, máximo 5): ");
            n = int.Parse(Console.ReadLine());

            while (n < 2 || n > 5)
            {
                Console.WriteLine("Cantidad invalida de jugadores, intente de nuevo");
                n = int.Parse(Console.ReadLine());

            }

            string[] players = new string[n];
            int[] puntajes = new int[n];


            while (jugadores < n)
            {


                Console.WriteLine("Nueva ronda");
                Console.WriteLine("Bienvenido jugador " + (jugadores + 1));

                Console.WriteLine("¿Cuál es tu nombre?");
                string nombre = Console.ReadLine();
                players[jugadores] = nombre;


                carta1 = aleatorio.Next(1, 7);
                carta2 = aleatorio.Next(1, 7);
                Console.WriteLine("Lanzamiento1 = " + carta1);
                Console.WriteLine("Lanzamiento2 = " + carta2);
                total = carta1 + carta2;
                Console.WriteLine("Total = " + total);


                //Cambio2
                CambioDeEstados[Posicion] = total;
                Console.WriteLine(CambioDeEstados[Posicion]);
                Posicion = Posicion + 1;
                

                Console.Write("¿Desea lanzar otra vez? (si/no): ");
                continuar = Console.ReadLine();

                if (continuar == "no")
                {
                    TamañoImpresion = Posicion;
                    Posicion = 0;
                }


                while (continuar == "si")
                {


                    nuevacarta = aleatorio.Next(1, 7);
                    Console.WriteLine("Dado = " + nuevacarta);
                    total += nuevacarta;
                    Console.WriteLine("Total = " + total);
                    //Cambio nn
                    CambioDeEstados[Posicion] = total;
                    Console.WriteLine(CambioDeEstados[Posicion]);


                    if (total == 21)
                    {
                        Console.WriteLine("Has alcanzado el puntaje maximo");

                        //Cambio3
                        CambioDeEstados[Posicion] = total;
                        Console.WriteLine(CambioDeEstados[Posicion]);
                        TamañoImpresion = Posicion;
                        Posicion = 0;

                        break;
                    }

                    if (total > 21)
                    {
                        Console.WriteLine("No obtienes ningun punto");
                        total = 0;

                        //Cambio4
                        CambioDeEstados[Posicion] = total;
                        Console.WriteLine(CambioDeEstados[Posicion]);
                        TamañoImpresion = Posicion;
                        Posicion = 0;

                        break;
                    }

                    else
                    {
                        Console.Write("Desea lanzar otra vez? (si/no): ");
                        continuar = Console.ReadLine();
                        if (continuar == "no")
                        {
                            TamañoImpresion = Posicion;
                            Posicion = 0;
                        }
                    }
                    Posicion = Posicion+1;

                }

                //Cambio5
                for (int p = 0; p < TamañoImpresion; p++)
                {

                    Console.WriteLine("Estado " + p + ": " + CambioDeEstados[p]);
                    
                }

            }

            puntajes[jugadores] = total;
            jugadores++;
        

        for (int j = 0; j < players.Length; j++)
            {

                for (int i = 0; i < players.Length - 1; i++)
                {
                    if (puntajes[i] > puntajes[i + 1])
                    {
                        int temporalpuntajes = puntajes[i + 1];
                        puntajes[i + 1] = puntajes[i];
                        puntajes[i] = temporalpuntajes;

                        string temporalj = players[i];
                        players[i] = players[i + 1];
                        players[i + 1] = temporalj;
                    }

                }
            }


            
            
            
            if (puntajes[n - 1] == puntajes[n - 2])
            {
                Console.WriteLine(players[n - 1] + " y " +  players[n - 2] + "empatan en primer lugar con: " + puntajes[n - 2] +
                                  " puntos");
                Console.WriteLine("Seguidos por " + players[n - 3] + " con " + puntajes[n - 3] + " puntos");
                Console.WriteLine("Gracias por jugar.");
            }
            else
            {
                Console.WriteLine("El ganador es: " + players[n - 1] + " con " + puntajes[n - 1] + " puntos");
                Console.WriteLine("En segundo lugar : " + players[n - 2] + " con " + puntajes[n - 2] + " puntos");
                Console.WriteLine("Gracias por jugar.");
            }
        }
    }
}
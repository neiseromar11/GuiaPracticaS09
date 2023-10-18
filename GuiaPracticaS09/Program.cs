using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GuiaPracticaS09
{
    internal class Program
    {
        static float caja = 0.0f;
        static float vendidosLimpieza = 0;
        static float vendidosAbarrotes = 0;
        static float vendidosGolosinas = 0;
        static float vendidosElectronicos = 0;
        static float devueltosLimpieza = 0;
        static float devueltosAbarrotes = 0;
        static float devueltosGolosinas = 0;
        static float devueltosElectronicos = 0;
        static void Main(string[] args)
        {
            MenuPrincipal();
            Console.ReadKey();
        }
        static void MenuPrincipal() {
            escribir("=======================");
            escribir("Tienda de Don lucas");
            escribir(" 1: Registrar venta");
            escribir(" 2: Registrar devolución");
            escribir(" 3: Cerrar Caja");
            escribir("=======================");

            int opcion = valor("Ingrese una opcion : ");
            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    RegistrarVenta();
                    break;
                case 2:
                    Console.Clear();
                    RegistrarDevolucion();
                    break;
                case 3:
                    Console.Clear();
                  MostrarEstadisticasFinales();
                    break;

                default:
                   escribir("Escoja una opcion. ");
                    break;
            }
         
        }
        static void RegistrarVenta()
        {
            escribir("=======================");
            escribir("Registrar Venta de: ");
            escribir("=======================");
            escribir(" 1: Limpieza");
            escribir(" 2: Abarrotes");
            escribir(" 3: Golosinas");
            escribir(" 4: Eletrónicos");
            escribir(" 5: <- Regresar ");
            escribir("=======================");
            
            int registrarV = valor ("Ingrese una opcion : ");
            switch (registrarV)
            {
                case 1:
                    RegistrarVentaPro("Limpieza", ref vendidosLimpieza);
                    break;
                case 2:
                    RegistrarVentaPro("Abarrotes", ref vendidosAbarrotes);
                    break;
                case 3:
                    RegistrarVentaPro("Golosinas", ref vendidosGolosinas);
                    break;
                case 4:
                    RegistrarVentaPro("Electronicos", ref vendidosElectronicos);
                    break;
                case 5:
                    escribir("Regresando al menú principal");
                    MenuPrincipal();
                    break;
            }
        }
        static void RegistrarVentaPro(string tipoProducto, ref float vendidos) {
            Console.Clear();
            escribir("=======================");
            escribir("Registrar venta de "+ tipoProducto);
            escribir("=======================");     
            float cantidadV = valorValidar("ingrese cantidad (unidades) : ");
            float precioV = valorValidar("Ingrese precio : S/ ");
            vendidos += cantidadV;
            float totalV = cantidadV * precioV;
            caja += totalV;
            escribir("=======================");
            escribir("Se han ingresado "+cantidadV+" unidades de "+ tipoProducto);
            escribir($"Se han ingresado S/ {(cantidadV * precioV):f2} en caja");
            escribir("=======================");
            escribir("1: Registrar más productos de esta categoría");
            escribir("2: <- Regresar al menú principal");
            escribir("=======================");
            int opcion = valor("Ingrese una opción: ");
            if (opcion == 1)
            {
                Console.Clear();
                RegistrarVentaPro(tipoProducto, ref vendidos);
            }
            else if (opcion == 2)
            {
                Console.Clear();
                MenuPrincipal();
            }
            else
            {
                escribir("Opción no válida. Regresando al menú principal.");
                MenuPrincipal();
            }
        }
        static void RegistrarDevolucion()
        {
            escribir("=======================");
            escribir("Registrar devolución de: ");
            escribir("=======================");
            escribir(" 1: Limpieza");
            escribir(" 2: Abarrotes");
            escribir(" 3: Golosinas ");
            escribir(" 4: Electrónicos");
            escribir(" 5: <- Regresar");
            escribir("=======================");
            int registrarV =valor("Ingrese una opcion : ");
            switch (registrarV)
            {
                case 1:
                    RegistrarDevolucionPro("Limpieza", ref devueltosLimpieza);
                    break;
                case 2:
                    RegistrarDevolucionPro("Abarrotes", ref devueltosAbarrotes);
                    break;
                case 3:
                    RegistrarDevolucionPro("Golosinas", ref devueltosGolosinas);
                    break;
                case 4:
                    RegistrarDevolucionPro("Electronicos", ref devueltosElectronicos);
                    break;
                case 5:
                    escribir("Regresando al menú principal");
                    MenuPrincipal();
                    break;
            }
        }
        static void RegistrarDevolucionPro(string tipoProductoDevolucion, ref float devueltos) {
            Console.Clear();
            escribir("=======================");
            escribir("Registrar venta de " + tipoProductoDevolucion);
            escribir("=======================");
            float cantidadV = valorValidar("ingrese cantidad (unidades) : ");
            float precioV = valorValidar("Ingrese precio : S/ ");
            devueltos += cantidadV;
            float totalDev = cantidadV * precioV;
            caja -= totalDev;
            escribir("=======================");
            escribir("Se han regresado " + cantidadV + " unidades de " + tipoProductoDevolucion);
            escribir($"Se han ingresado S/ {(cantidadV * precioV):f2} en caja");
            escribir("=======================");
            escribir("1: Registrar más productos de esta categoría");
            escribir("2: <- Regresar al menú principal");
            escribir("=======================");
            int opcion = valor("Ingrese una opción: ");
            if (opcion == 1)
            {
                Console.Clear();
                RegistrarVentaPro(tipoProductoDevolucion , ref devueltos);
            }
            else if (opcion == 2)
            {
                Console.Clear();
                MenuPrincipal();
            }
            else
            {
                escribir("Opción no válida. Regresando al menú principal.");
                MenuPrincipal();
            }
        }
        static void MostrarEstadisticasFinales()
        {
            escribir("=======================");
            escribir("Cerrando Caja");
            escribir("=======================");
            escribir("Totales");
            escribir("=======================");

            MostrarEstadisticasPorRubro("Limpieza", vendidosLimpieza, devueltosLimpieza);
            MostrarEstadisticasPorRubro("Abarrotes", vendidosAbarrotes, devueltosAbarrotes);
            MostrarEstadisticasPorRubro("Golosinas", vendidosGolosinas, devueltosGolosinas);
            MostrarEstadisticasPorRubro("Electronicos", vendidosElectronicos, devueltosElectronicos);

            escribir($"Queda en caja S/{caja:f2}");
            Console.ReadKey();
        }

        static void MostrarEstadisticasPorRubro(string rubro, float vendidos, float devueltos)
        {
            float total = vendidos - devueltos;

            escribir($"\t\t| {vendidos} vendidos");
            escribir($"{rubro} \t| {devueltos} devueltos");
            escribir($"\t\t| {total} en total");
            escribir($"\t\t| S/ {(total):f2} en caja");
            escribir("=======================");
        }

        public static int valor(string pretext)
        {
            Console.Write(pretext);
            string val = Console.ReadLine();
            return int.Parse(val);
        }
        public static float valorValidar(string pretext2) {
            Console.Write(pretext2);
            string vale=Console.ReadLine();
            return float.Parse(vale);
        }
        public static void escribir(string texto) {
            Console.WriteLine(texto);

        }


    }
}

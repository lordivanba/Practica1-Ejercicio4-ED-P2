using System;
using System.Collections.Generic;
using System.Linq;

namespace practica1_ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            int numeroElementos;
            string nombreProducto;
            double precioProducto;
            int cantidadProducto;
            int opcion = 0;
            int eliminarId;
            double total;


            var listaProductos = new List<Producto>();
            var listaOrdenada = new List<Producto>();
            var listaTotal = new List<double>();

            Console.WriteLine("Ingrese el numero de productos que desea agregar");
            numeroElementos = Convert.ToInt32(Console.ReadLine());

            for(int i = 1; i<=numeroElementos; i++){

                System.Console.WriteLine($"\nIngrese el nombre del producto {i}:");
                nombreProducto = Console.ReadLine();
                System.Console.WriteLine($"Ingrese el precio del producto {i}:");
                precioProducto = Convert.ToDouble(Console.ReadLine());
                System.Console.WriteLine($"Ingrese la cantidad del producto {i}:");
                cantidadProducto = Convert.ToInt32(Console.ReadLine());

                listaProductos.Add(new Producto(){
                    Id = i, Nombre = nombreProducto, Precio = precioProducto, Cantidad = cantidadProducto
                });
            }


            while(opcion != 5){
                System.Console.WriteLine("\nIngrese la opcion\n1. Listar productos\n2. Eliminar productos por Id\n3. Ordenar por nombres\n4. Mostrar el costo total de compra\n5. Salir del programa");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch(opcion){
                    case 1:
                        foreach(var item in listaProductos){
                            System.Console.WriteLine($"\nId: {item.Id}\nNombre: {item.Nombre}\nPrecio: {item.Precio}\nCantidad: {item.Cantidad}");
                        }
                        break;
                    
                    case 2:
                        System.Console.WriteLine("Ingrese el Id del producto que desea eliminar");
                        eliminarId = Convert.ToInt32(Console.ReadLine());

                        var producto = listaProductos.Find(producto => producto.Id == eliminarId);
                        listaProductos.Remove(producto);

                        System.Console.WriteLine($"\nEl producto con Id: {producto.Id} y nombre: {producto.Nombre} ha sido eliminado.\n");
                        break;

                    case 3:

                        listaOrdenada = listaProductos.OrderBy(producto => producto.Nombre).ToList();
                        foreach(var item in listaOrdenada){
                            System.Console.WriteLine($"\nId: {item.Id}\nNombre: {item.Nombre}\nPrecio: {item.Precio}\nCantidad: {item.Cantidad}");
                        }
                        break;

                    case 4:
                        // Lista del costo total
                        total = 0;
                        listaTotal.Clear();
                        foreach (var item in listaProductos)
                        {
                            listaTotal.Add(item.Cantidad * item.Precio);
                        }
                        foreach (var item in listaTotal)
                        {
                            total = total + item;
                        }

                        System.Console.WriteLine($"\nCosto total de compra: {total}\n");

                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }

            
            Console.ReadKey();
        }
    }
}

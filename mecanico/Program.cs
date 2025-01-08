using System;
using System.Collections.Generic;

namespace TallerMecanico
{
    //OBJETO CLIENTE 
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroContacto { get; set; }

        public Cliente(string nombre, string apellido, string numeroContacto)
        {
            Nombre = nombre;
            Apellido = apellido;
            NumeroContacto = numeroContacto;
        }
    }
    //OBJETO VEHICULO 
    public class Vehiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Matricula { get; set; }
        public Cliente Propietario { get; set; }

        public Vehiculo(string marca, string modelo, string matricula, Cliente propietario)
        {
            Marca = marca;
            Modelo = modelo;
            Matricula = matricula;
            Propietario = propietario;
        }
    }

    //OBJETO MECANICO
    public class Mecanico
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public Mecanico(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }
    }

    //OBJETO REPARACION
    public class Reparacion
    {
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
        public Vehiculo VehiculoReparado { get; set; }
        public Mecanico MecanicoEncargado { get; set; }

        public Reparacion(DateTime fecha, string detalle, Vehiculo vehiculoReparado, Mecanico mecanicoEncargado)
        {
            Fecha = fecha;
            Detalle = detalle;
            VehiculoReparado = vehiculoReparado;
            MecanicoEncargado = mecanicoEncargado;
        }
    }
    //TALLER MECANICO
    class Program
    {
        static List<Cliente> clientes = new List<Cliente>();
        static List<Vehiculo> vehiculos = new List<Vehiculo>();
        static List<Mecanico> mecanicos = new List<Mecanico>();
        static List<Reparacion> reparaciones = new List<Reparacion>();

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.WriteLine("\n----- Menú Taller Mecánico -----");
                Console.WriteLine("1. Registrar cliente");
                Console.WriteLine("2. Registrar vehículo");
                Console.WriteLine("3. Registrar mecánico");
                Console.WriteLine("4. Registrar reparación");
                Console.WriteLine("5. Consultar historial de reparaciones");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarCliente();
                        break;
                    case 2:
                        RegistrarVehiculo();
                        break;
                    case 3:
                        RegistrarMecanico();
                        break;
                    case 4:
                        RegistrarReparacion();
                        break;
                    case 5:
                        ConsultarReparaciones();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 6);
        }

        static void RegistrarCliente()
        {
            Console.Write("Ingrese nombre del cliente: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese apellido del cliente: ");
            string apellido = Console.ReadLine();
            Console.Write("Ingrese número de contacto: ");
            string numeroContacto = Console.ReadLine();

            Cliente cliente = new Cliente(nombre, apellido, numeroContacto);
            clientes.Add(cliente);
            Console.WriteLine("Cliente registrado con éxito.");
        }

        static void RegistrarVehiculo()
        {
            Console.Write("Ingrese matrícula del vehículo: ");
            string matricula = Console.ReadLine();
            Console.Write("Ingrese marca del vehículo: ");
            string marca = Console.ReadLine();
            Console.Write("Ingrese modelo del vehículo: ");
            string modelo = Console.ReadLine();
            Console.WriteLine("Seleccione el propietario:");
            for (int i = 0; i < clientes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {clientes[i].Nombre} {clientes[i].Apellido}");
            }
            int propietarioIndex = int.Parse(Console.ReadLine()) - 1;

            Vehiculo vehiculo = new Vehiculo(marca, modelo, matricula, clientes[propietarioIndex]);
            vehiculos.Add(vehiculo);
            Console.WriteLine("Vehículo registrado con éxito.");
        }

        static void RegistrarMecanico()
        {
            Console.Write("Ingrese nombre del mecánico: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese apellido del mecánico: ");
            string apellido = Console.ReadLine();

            Mecanico mecanico = new Mecanico(nombre, apellido);
            mecanicos.Add(mecanico);
            Console.WriteLine("Mecánico registrado con éxito.");
        }

        static void RegistrarReparacion()
        {
            Console.WriteLine("Seleccione el vehículo a reparar:");
            for (int i = 0; i < vehiculos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {vehiculos[i].Marca} {vehiculos[i].Modelo} - Matrícula: {vehiculos[i].Matricula}");
            }
            int vehiculoIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Seleccione el mecánico encargado:");
            for (int i = 0; i < mecanicos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {mecanicos[i].Nombre} {mecanicos[i].Apellido}");
            }
            int mecanicoIndex = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Ingrese detalle de la reparación: ");
            string detalle = Console.ReadLine();

            Reparacion reparacion = new Reparacion(DateTime.Now, detalle, vehiculos[vehiculoIndex], mecanicos[mecanicoIndex]);
            reparaciones.Add(reparacion);
            Console.WriteLine("Reparación registrada con éxito.");
        }

        static void ConsultarReparaciones()
        {
            foreach (var reparacion in reparaciones)
            {
                Console.WriteLine("\n----- Historial de Reparaciones -----");
                Console.WriteLine($"Cliente: {reparacion.VehiculoReparado.Propietario.Nombre} {reparacion.VehiculoReparado.Propietario.Apellido} - {reparacion.VehiculoReparado.Propietario.NumeroContacto}");
                Console.WriteLine($"Vehículo: {reparacion.VehiculoReparado.Marca} {reparacion.VehiculoReparado.Modelo} - Matrícula: {reparacion.VehiculoReparado.Matricula}");
                Console.WriteLine($"Fecha de reparación: {reparacion.Fecha.ToShortDateString()}");
                Console.WriteLine($"Detalle: {reparacion.Detalle}");
                Console.WriteLine($"Mecánico encargado: {reparacion.MecanicoEncargado.Nombre} {reparacion.MecanicoEncargado.Apellido}");
            }
        }
    }
}


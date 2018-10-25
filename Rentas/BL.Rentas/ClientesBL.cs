using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class ClientesBL
    {
        public BindingList<Cliente> ListaClientes { get; set; }

        //Propiedades
        public ClientesBL()
        {
            ListaClientes = new BindingList<Cliente>();

            var cliente1 = new Cliente();
            cliente1.Nombre = "Yoselin Bardales Ramirez";
            cliente1.Correo = "yoselinBRamires@gmail.com";
            cliente1.Direccion = "Col. Buenos Aires";
            cliente1.Telefono = 98653254;
            cliente1.Id = 1;
            cliente1.Activo = true;
            ListaClientes.Add(cliente1);

            var cliente2 = new Cliente();
            cliente2.Nombre = "Ridel Zaldivar";
            cliente2.Correo = "ridelZaldivar@gmail.com";
            cliente2.Direccion = "Col. La Esperanza";
            cliente2.Telefono = 97849562;
            cliente2.Id = 2;
            cliente2.Activo = true;
            ListaClientes.Add(cliente2);

            var cliente3 = new Cliente();
            cliente3.Nombre = "Kevin Sosa";
            cliente3.Correo = "kevinSosa@gmail.com";
            cliente3.Direccion = "Col. Las Delicias";
            cliente3.Telefono = 99847562;
            cliente3.Id = 3;
            cliente3.Activo = true;
            ListaClientes.Add(cliente3);

            var cliente4 = new Cliente();
            cliente4.Nombre = "Ever Fuentes";
            cliente4.Correo = "everFuentes@gmail.com";
            cliente4.Direccion = "Col. El Faro";
            cliente4.Telefono = 92871526;
            cliente4.Id = 4;
            cliente4.Activo = true;
            ListaClientes.Add(cliente4);

            var cliente5 = new Cliente();
            cliente5.Nombre = "Oslin Ochoa";
            cliente5.Correo = "oslinOchoa@gmail.com";
            cliente5.Direccion = "Col. Pueblo Nuevo";
            cliente5.Telefono = 936954875;
            cliente5.Id = 5;
            cliente5.Activo = true;
            ListaClientes.Add(cliente5);
        }
        public BindingList<Cliente> ObtenerClientes()
        {
            return ListaClientes;
        }

        public Resultado GuardarCliente(Cliente cliente)
        {
            var resultado = Validar(cliente);
            if(resultado.Exitoso == false)
            {
                return resultado;
            }

            if(cliente.Id == 0)
            {
                cliente.Id = ListaClientes.Max(item => item.Id) + 1;
            }

            resultado.Exitoso = true;
            return resultado;
        }

        //Agregar Clietes
        public void AgregarCliente()
        {
            var nuevoCliente = new Cliente();
            ListaClientes.Add(nuevoCliente);
        }

        public bool EliminarCliente(int id)
        {
            foreach (var cliente in ListaClientes)
            {
                if(cliente.Id == id)
                {
                    ListaClientes.Remove(cliente);
                    return true;
                }
            }
            return false;
        }

        private Resultado Validar(Cliente cliente)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (string.IsNullOrEmpty(cliente.Correo) == true)
            {
                resultado.Mensaje = "Ingrese un Correo Electronico";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(cliente.Direccion) == true)
            {
                resultado.Mensaje = "Ingrese una Direccion";
                resultado.Exitoso = false;
            }

            if (cliente.Telefono <= 0)
            {
                resultado.Mensaje = "Ingrese un numero de Telefono";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(cliente.Nombre) == true)
            {
                resultado.Mensaje = "Ingrese un Nombre";
                resultado.Exitoso = false;
            }

            return resultado;
        }

    }
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
    }

    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}

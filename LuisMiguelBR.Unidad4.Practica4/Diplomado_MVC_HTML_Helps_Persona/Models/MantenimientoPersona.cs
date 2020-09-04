using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplomado_MVC_HTML_Helps_Persona.Models
{
    public class MantenimientoPersona
    {
        List<Persona> ListaPersonas = new List<Persona>()
        {
        new Persona() { Codigo = 1,
                        Nombre ="Juan Carlos Reyes",
                        Peso = 67.3f,
                        Trabaja = false,
                        FechaNacimiento = new DateTime(1976,12,25) },
        new Persona() { Codigo = 2,
                        Nombre = "Ana Maria Medina",
                        Peso = 55.7f,
                        Trabaja = true,
                        FechaNacimiento=new DateTime(1983,2,18) },
        new Persona() { Codigo = 3,
                        Nombre ="Pedro Antonio Matos",
                        Peso = 92.5f,
                        Trabaja = true,
                        FechaNacimiento = new DateTime(1993,5,1) }
        };

        public Persona Retornar(int cod)
        {
            foreach (var per in ListaPersonas)
                if (per.Codigo == cod)
                    return per;
            return null;
        }
    }
}
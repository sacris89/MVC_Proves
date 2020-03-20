using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using web.Models;

namespace web.Funciones
{

    public class Fichero_Configuracion
    {
        public void read()
        {
         String fichero =   File.ReadAllText("Configuracion.json");        
         Persona aaa = JsonConvert.DeserializeObject<Persona>(fichero);

        }
    }
}
    


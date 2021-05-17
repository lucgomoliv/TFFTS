using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TFTFS.Models;

namespace TFTFS.Utils
{
    public static class IOUtils
    {
        public static List<T> ListaObjetosArquivo<T>(T model)
        {
            string path = $"{model.GetType().Name}s.json";
            if (!File.Exists(path))
                File.WriteAllText(path, "[]");
            return JArray.Parse(File.ReadAllText(path)).ToObject<List<T>>();
        }

        public static void Criar<T>(T model)
        {
            string path = $"{model.GetType().Name}s.json";
            string dados = "[]";
            if (File.Exists(path))
            {
                var obj = JArray.Parse(File.ReadAllText(path));
                obj.Add(JToken.FromObject(model));
                dados = obj.ToString();
            }
            File.WriteAllText(path, dados);
        }

        public static void EditarUsuario(Usuario usuario)
        {
            string path = $"Usuarios.json";
            string dados = "[]";
            if (File.Exists(path))
            {
                var array = JArray.Parse(File.ReadAllText(path));
                var index = array.ToObject<List<Usuario>>().FindIndex(x => x.Conta == usuario.Conta);
                array[index] = JToken.FromObject(usuario);
                dados = array.ToString();
            }
            File.WriteAllText(path, dados);
        }

        public static Usuario GetUsuario(int conta)
        {
            return JArray.Parse(File.ReadAllText("Usuarios.json")).ToObject<List<Usuario>>().Find(x => x.Conta == conta);
        }

        public static int GerarConta()
        {
            if (File.Exists("Usuarios.json"))
                if (JArray.Parse(File.ReadAllText("Usuarios.json")).Count() > 0)
                    return JArray.Parse(File.ReadAllText("Usuarios.json")).Last().ToObject<Usuario>().Conta + 1;
            return 1;
        }
    }
}

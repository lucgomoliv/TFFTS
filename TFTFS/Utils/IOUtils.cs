using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TFTFS.Models;

namespace TFTFS.Utils
{
    public static class IOUtils
    {
        static ReaderWriterLock lockerUsuario = new ReaderWriterLock();
        static ReaderWriterLock lockerSaque = new ReaderWriterLock();
        static ReaderWriterLock lockerDeposito = new ReaderWriterLock();

        public static List<T> ListaObjetosArquivo<T>(T model)
        {
            string path = $"{model.GetType().Name}s.json";
            try
            {
                switch (model.GetType().Name)
                {
                    case "Usuario": lockerUsuario.AcquireWriterLock(int.MaxValue); break;
                    case "Saque": lockerSaque.AcquireWriterLock(int.MaxValue); break;
                    case "Deposito": lockerDeposito.AcquireWriterLock(int.MaxValue); break;
                }
                if (!File.Exists(path) || File.ReadAllText(path) == "")
                    File.WriteAllText(path, "[]");
                return JArray.Parse(File.ReadAllText(path)).ToObject<List<T>>();
            }
            finally
            {
                switch (model.GetType().Name)
                {
                    case "Usuario": lockerUsuario.ReleaseWriterLock(); break;
                    case "Saque": lockerSaque.ReleaseWriterLock(); break;
                    case "Deposito": lockerDeposito.ReleaseWriterLock(); break;
                }
            }
        }

        public static void Criar<T>(T model)
        {
            string path = $"{model.GetType().Name}s.json";
            string dados = "[]";
            try
            {
                switch (model.GetType().Name)
                {
                    case "Usuario": lockerUsuario.AcquireWriterLock(int.MaxValue); break;
                    case "Saque": lockerSaque.AcquireWriterLock(int.MaxValue); break;
                    case "Deposito": lockerDeposito.AcquireWriterLock(int.MaxValue); break;
                }
                if (File.Exists(path))
                {
                    var obj = JArray.Parse(File.ReadAllText(path));
                    obj.Add(JToken.FromObject(model));
                    dados = obj.ToString();
                }
                File.WriteAllText(path, dados);
            }
            finally
            {
                switch (model.GetType().Name)
                {
                    case "Usuario": lockerUsuario.ReleaseWriterLock(); break;
                    case "Saque": lockerSaque.ReleaseWriterLock(); break;
                    case "Deposito": lockerDeposito.ReleaseWriterLock(); break;
                }
            }
        }

        public static void EditarUsuario(Usuario usuario)
        {
            string path = $"Usuarios.json";
            string dados = "[]";
            try
            {
                switch (usuario.GetType().Name)
                {
                    case "Usuario": lockerUsuario.AcquireWriterLock(int.MaxValue); break;
                    case "Saque": lockerSaque.AcquireWriterLock(int.MaxValue); break;
                    case "Deposito": lockerDeposito.AcquireWriterLock(int.MaxValue); break;
                }
                if (File.Exists(path))
                {
                    var array = JArray.Parse(File.ReadAllText(path));
                    var index = array.ToObject<List<Usuario>>().FindIndex(x => x.Conta == usuario.Conta);
                    array[index] = JToken.FromObject(usuario);
                    dados = array.ToString();
                }
                File.WriteAllText(path, dados);
            }
            finally
            {
                switch (usuario.GetType().Name)
                {
                    case "Usuario": lockerUsuario.ReleaseWriterLock(); break;
                    case "Saque": lockerSaque.ReleaseWriterLock(); break;
                    case "Deposito": lockerDeposito.ReleaseWriterLock(); break;
                }
            }
        }

        public static Usuario GetUsuario(int conta)
        {
            try
            {
                lockerUsuario.AcquireReaderLock(int.MaxValue);
                return JArray.Parse(File.ReadAllText("Usuarios.json")).ToObject<List<Usuario>>().Find(x => x.Conta == conta);
            }
            finally
            {
                lockerUsuario.ReleaseReaderLock();
            }
        }

        public static int GerarConta()
        {
            try
            {
                lockerUsuario.AcquireReaderLock(int.MaxValue);
                if (File.Exists("Usuarios.json"))
                    if (JArray.Parse(File.ReadAllText("Usuarios.json")).Count() > 0)
                        return JArray.Parse(File.ReadAllText("Usuarios.json")).Last().ToObject<Usuario>().Conta + 1;
                return 1;
            }
            finally
            {
                lockerUsuario.ReleaseReaderLock();
            }
        }
    }
}

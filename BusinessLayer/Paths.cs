using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class Paths
    {
        public string PathFile = @"C:\\rptsGnrl\\pathInstanciaIContasis.txt";
        public string PathFileInit = @"C:\\rptsGnrl\\pathInstanciaIContasisInit.txt";
        public string PathUser = @"C:\\rptsGnrl\\user.txt";
        public string PathRUC = @"C:\\rptsGnrl\\ruc.txt";
        public string PathIdCompany = @"C:\\rptsGnrl\\idCompany.txt";
        public string PathPrincipalDirectory = @"C:/rptsGnrl/";
        public string PathRCP       =   "rptCntsPndts/";
        public string PathMU        =   "rptsMrgTld/";
        public string PathMND       =   "rptMNgcLd/";
        public string PathEDRPMS    =   "rptStdPmS/";
        public string PathREF       =   "rptStdFncr/";
        public string PathFCD       =   "rptFldcd/";  
        public string PathImagenLogo = "./images/logo.png";
        public string nameDomain    = "http://licenciacontasis.net/ReportWeb";
        VerificarInstancia verificarInstancia = new VerificarInstancia();
        //Jorge Luis|24/10/2017|RW-19
        /*Método para leer un txt con el path de la instancia de Contasis*/
        public string readPathInstanceIContasis()
        {
            string pathInstance;
            StreamReader pathInstanceFile = new StreamReader(PathFile);
            return pathInstance = pathInstanceFile.ReadLine().Replace('\\', '/').Trim();
        }
        //Jorge Luis|24/10/2017|RW-19
        /*Método para leer un txt con el path de la instancia de Contasis inicial*/
        public string readPathInstanceIContasisInit()
        {
            string pathInstance;
            StreamReader pathInstanceFile = new StreamReader(PathFileInit);
            return pathInstance = pathInstanceFile.ReadLine().Replace('\\', '/').Trim();
        }
        //Jorge Luis|07/11/2017|RW-19
        /*Método para leer un archivo*/
        public string readFile(string path)
        {
            string text;
            /*llama al método 'ComprobarExistenciaPathFile' para verficar la existencia de un archivo, sólo 
             despues de haber comprobado su existencia, procede a leer este archivo*/
            if (ComprobarExistenciaPathFile(path))
            {
                StreamReader pathInstanceFile = new StreamReader(path);
                text = pathInstanceFile.ReadLine().Trim();
            }
            else
                text = "SinTexto";
            return text;
        }
        //Jorge Luis|24/10/2017|RW-19
        /*Método para comprobar la existencia del txt con el path de la instancia de Contasis*/
        public bool ComprobarExistenciaPathFile() {
            bool resultado = false;
            /*Comprueba la existencia de un archivo específico*/
            if (File.Exists(PathFile))
                resultado = true;
            return resultado;
        }
        //Jorge Luis|24/10/2017|RW-19
        /*Método para comprobar la existencia de un archivo, con un parámetro*/
        public bool ComprobarExistenciaPathFile(string path)
        {
            bool resultado = false;
            /*Comprueba la existencia de un archivo mediante un path*/
            if (File.Exists(path))
                resultado = true;
            return resultado;
        }
        //Jorge Luis|24/10/2017|RW-19
        /*Método para leer el txt y saber si la ruta proporcionada es la correcta*/
        public bool ComprobarExistenciaPathEmpresas(string pathInstanciaContasis) {
            bool resultado = false;
            /*Método para comprobar la existencia de varios archivos, con un parámetro*/
            if (File.Exists(pathInstanciaContasis + "/PATH.DBF") && File.Exists(pathInstanciaContasis + "/EMPRESAS.DBF"))
                resultado = true;
            return resultado;
        }
        //Jorge Luis|24/10/2017|RW-19
        /*Método para crear un txt con la ruta de la instacia de Contasis*/
        public bool createPathFile() {
            bool comprobacionExito = false;
            List<string> listInstancesContasis = new List<string>();
            listInstancesContasis = verificarInstancia.getInstanceContasis();
            if (listInstancesContasis.Count() > 1 || listInstancesContasis.Count() == 0)
            {
                FolderBrowserDialog CarpetaDatos = new FolderBrowserDialog();
                DialogResult resultado = MessageBox.Show("Hemos detectado más de una o ninguna instancia de Contasis. Antes de empezar debe proporcionar su instancia de Contasis. Por favor, ubique la ruta donde realizó la instalación, ejemplo: 'C:/Contasis14'.", "Comprobación de existencia de path", MessageBoxButtons.OK, MessageBoxIcon.Information);
                resultado = CarpetaDatos.ShowDialog();
                /*Otorga permisos ilimitados*/
                PermissionSet perms = new PermissionSet(null);
                perms.AddPermission(new UIPermission(PermissionState.Unrestricted));
                perms.AddPermission(new RegistryPermission(PermissionState.Unrestricted));
                /*realiza la creación de un archivo, sólo despues de pasar las siguientes validaciones*/
                if (ValidateCreationPathFile(CarpetaDatos.SelectedPath.ToString()))
                {
                    /*Comprueba que el usuario le haya otorgado una ruta*/
                    if (resultado == DialogResult.OK)
                    {
                        bool comprobacionFile = ComprobarExistenciaPathFile();
                        /*Comprueba la existencia de este archivo, y de validarlo, lo crea.*/
                        if (comprobacionFile)
                        {
                            File.Delete(PathFile);
                            File.Delete(PathFileInit);
                            using (StreamWriter createFile = new StreamWriter(PathFile, false))
                                createFile.WriteLine(CarpetaDatos.SelectedPath.ToString());
                            using (StreamWriter createFileInit = new StreamWriter(PathFileInit, false))
                                createFileInit.WriteLine(CarpetaDatos.SelectedPath.ToString());
                        }
                        else
                        {
                            using (StreamWriter createFile = new StreamWriter(PathFile, false))
                            {
                                createFile.WriteLine(CarpetaDatos.SelectedPath.ToString());
                                MessageBox.Show("Ruta correcta", "Comprobación de ruta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            using (StreamWriter createFileInit = new StreamWriter(PathFileInit, false))
                                createFileInit.WriteLine(CarpetaDatos.SelectedPath.ToString());
                        }
                        comprobacionExito = true;
                    }
                    else
                        MessageBox.Show("Lo sentimos, no se pudo ubicar la instancia de Contasis.", "Error de comprobación de existencia de path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Lo sentimos, no se pudo ubicar la instancia de Contasis.", "Error de comprobación de existencia de path", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (ValidateCreationPathFile(listInstancesContasis[0].ToString()))
                {
                    /*Comprueba la existencia de este archivo, y de validarlo, lo crea.*/
                    if (ComprobarExistenciaPathFile())
                    {
                        File.Delete(PathFile);
                        File.Delete(PathFileInit);
                        using (StreamWriter createFile = new StreamWriter(PathFile, false))
                            createFile.WriteLine(listInstancesContasis[0].ToString());
                        using (StreamWriter createFileInit = new StreamWriter(PathFileInit, false))
                            createFileInit.WriteLine(listInstancesContasis[0].ToString());
                    }
                    else
                    {
                        using (StreamWriter createFile = new StreamWriter(PathFile, false))
                            createFile.WriteLine(listInstancesContasis[0].ToString());
                        using (StreamWriter createFileInit = new StreamWriter(PathFileInit, false))
                            createFileInit.WriteLine(listInstancesContasis[0].ToString());
                    }
                    comprobacionExito = true;
                }
                else
                {
                    FolderBrowserDialog CarpetaDatos = new FolderBrowserDialog();
                    DialogResult resultado = MessageBox.Show("Estamos teniendo problemas con la ruta de la instalación de Contasis, probablemente haya realizado la instalación en un disco diferente a 'C', debe proporcionar su instancia de Contasis. Por favor, ubique la ruta donde realizó la instalación, ejemplo: 'C:/Contasis14'.", "Comprobación de existencia de path", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resultado = CarpetaDatos.ShowDialog();
                    /*Otorga permisos ilimitados*/
                    PermissionSet perms = new PermissionSet(null);
                    perms.AddPermission(new UIPermission(PermissionState.Unrestricted));
                    perms.AddPermission(new RegistryPermission(PermissionState.Unrestricted));
                    /*realiza la creación de un archivo, sólo despues de pasar las siguientes validaciones*/
                    if (ValidateCreationPathFile(CarpetaDatos.SelectedPath.ToString()))
                    {
                        /*Comprueba que el usuario le haya otorgado una ruta*/
                        if (resultado == DialogResult.OK)
                        {
                            bool comprobacionFile = ComprobarExistenciaPathFile();
                            /*Comprueba la existencia de este archivo, y de validarlo, lo crea.*/
                            if (comprobacionFile)
                            {
                                File.Delete(PathFile);
                                File.Delete(PathFileInit);
                                using (StreamWriter createFile = new StreamWriter(PathFile, false))
                                    createFile.WriteLine(CarpetaDatos.SelectedPath.ToString());
                                using (StreamWriter createFileInit = new StreamWriter(PathFileInit, false))
                                    createFileInit.WriteLine(CarpetaDatos.SelectedPath.ToString());
                            }
                            else
                            {
                                using (StreamWriter createFile = new StreamWriter(PathFile, false))
                                    createFile.WriteLine(CarpetaDatos.SelectedPath.ToString());
                                using (StreamWriter createFileInit = new StreamWriter(PathFileInit, false))
                                    createFileInit.WriteLine(CarpetaDatos.SelectedPath.ToString());
                            }
                            comprobacionExito = true;
                        }
                        else
                            MessageBox.Show("Lo sentimos, no se pudo ubicar la instancia de Contasis.", "Error de comprobación de existencia de path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Lo sentimos, no se pudo ubicar la instancia de Contasis.", "Error de comprobación de existencia de path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            return comprobacionExito;
        }
        //Jorge Luis|24/10/2017|RW-19
        /*Método para validar el path de la instancia de Contasis*/
        public bool ValidateCreationPathFile(string pathTemporal) {
            bool resultado = false;
            /*Comprobar la existencia de varios archivos, con un parámetro temporal*/
            if (ComprobarExistenciaPathFile())
                resultado = true;
            else
            {
                /*validar que la ruta proporcianda por el usuario, sea la correcta, para ello lee las tablas en la raiz del proyecto*/
                if (ComprobarExistenciaPathEmpresas(pathTemporal))
                    resultado = true;
                else
                    resultado = false;
            }
            return resultado;
        }
        //Jorge Luis|24/10/2017|RW-19
        /*Método para listar los años registrados en la instancia de Contasis*/
        public List<string> listAnios() {
            List<string> listYearInClient = new List<string>();
            try
            {
                string dirPath = @"" + readPathInstanceIContasis().ToString().Replace('\\', '/');
                var dirs = from dir in Directory.EnumerateDirectories(dirPath, "20*") select dir;
                /*Emplea Linq para leer los directorios que empiecen por '20', seguidamente los guarda en una lista
                 Esto se emplea para descartar los path erroneos de la tabla DBF raiz 'PATH', que no elimina los 
                 registros y mantiene años sin datos*/
                foreach (var dir in dirs)
                    listYearInClient.Add(dir.Substring(dir.LastIndexOf("\\") + 1));
            }
            catch (UnauthorizedAccessException UAEx)
            {
                MessageBox.Show(UAEx.Message.ToString(), "Error en la comprobación de años", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (PathTooLongException PathEx)
            {
                MessageBox.Show(PathEx.Message.ToString(), "Error en la comprobación de años, ruta demasiado larga.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listYearInClient;
        }
        //Jorge Luis|24/10/2017|RW-19
        /*Método para crear un archivo json con años válidos*/
        public void ListYearsJson()
        {
            List<string> anios = listAnios();
            using (StreamWriter jsonListaCuentas = new StreamWriter(PathPrincipalDirectory + PathRCP + "listAnios.json", false))
            {
                jsonListaCuentas.WriteLine(JsonConvert.SerializeObject(anios, Formatting.Indented).ToString());
            }
        }
        //Jorge Luis|24/10/2017|RW-19
        /*Método para escribir la hora de la última actualización*/
        public void WriteLastUpdate()
        {
            DateTime localDate = DateTime.Now;
            if (File.Exists(PathPrincipalDirectory + "LastUpdate.txt"))
            {
                File.Delete(PathPrincipalDirectory + "LastUpdate.txt");
                using (StreamWriter LastUpdate = new StreamWriter(PathPrincipalDirectory + "LastUpdate.txt", false))
                    LastUpdate.WriteLine(localDate.ToString());
            }
            else
                using (StreamWriter LastUpdate = new StreamWriter(PathPrincipalDirectory + "LastUpdate.txt", false))
                    LastUpdate.WriteLine(localDate.ToString());
        }
    }
}

using System.Collections.Generic;
using System;
using System.Net;
using System.Threading.Tasks;
using MM.CAAM.Gestion.DTO.DTOs;
using MM.CAAM.Gestion.DTO.DTOs.Request;
using MM.CAAM.Gestion.DTO.DTOs.Response;
using MM.CAAM.Admin.Services.Exceptions;
using MM.CAAM.Gestion.DTO.Objects;
using System.IO;

namespace MM.CAAM.Admin.Services.Servicios
{
    public interface IFtpService
    {
        Task<string> UploadFile(string PathFile, string UsuarioFtp, string PasswordFtp, string UrlServidorFtp, string Directory, string FileName, int TimeOut = 60000);
        
    }

    public class FtpService : IFtpService
    { 
        public FtpService() 
        {
        }

        public async Task<string> UploadFile(string PathFile, string UrlServidorFtp, string Directory, string UsuarioFtp, string PasswordFtp, string FileName, int TimeOut = 60000)
        {
            #region ReemplazaNombreSiExiste
            int contador = 0;
            string fileExtension = Path.GetExtension(FileName);
            while (!string.IsNullOrEmpty(await ExisteArchivoFtp(UrlServidorFtp, Directory, UsuarioFtp, PasswordFtp, PathFile, FileName)))
            {
                contador++;
                var copyCount = $"_Copy({contador})";
                var copyCountAnterior = $"_Copy({(contador - 1)})";

                if (FileName.Contains(copyCountAnterior))
                {
                    FileName = FileName.Replace(copyCountAnterior, copyCount);
                }
                else
                {
                    FileName = FileName.Split('.')[0] + copyCount + fileExtension;
                }
            }
            #endregion

            if (!System.IO.File.Exists(PathFile))
            {
                throw new Exception("Archivo no encontrado");
            }

            var folders = Directory.Split("/");
            var directoryTmp = string.Empty;
            foreach(var folder in folders)
            {
                if (!string.IsNullOrEmpty(folder)) 
                {
                    directoryTmp = directoryTmp+ "/" + folder;
                    await ValidarCrearDirectorioFtp(UrlServidorFtp, directoryTmp, UsuarioFtp, PasswordFtp);
                }
            }

            await Upload(UrlServidorFtp, Directory, UsuarioFtp, PasswordFtp, PathFile, TimeOut, FileName);

            var pathServer = await ExisteArchivoFtp(UrlServidorFtp, Directory, UsuarioFtp, PasswordFtp, PathFile, FileName);
            return pathServer.Replace("ftp://", "");

        }

        public async Task Upload(string UrlServidorFtp, string Directory, string UsuarioFtp, string PasswordFtp, string PathFile, int TimeOut, string FileName)
        {
            //var FileName = "/" + Path.GetFileName(PathFile);

            var request = (FtpWebRequest)WebRequest.Create(Path.Combine(UrlServidorFtp + Directory + FileName));
            request.Credentials = new NetworkCredential(UsuarioFtp, PasswordFtp);
            request.Timeout = TimeOut;
            request.Method = WebRequestMethods.Ftp.UploadFile;

            using (Stream fileStream = System.IO.File.OpenRead(PathFile))
            using (Stream ftpStream = request.GetRequestStream())
            {
                fileStream.CopyTo(ftpStream);
            }
        }

        public async Task<bool> ValidarCrearDirectorioFtp(string UrlServidorFtp, string Directory, string UsuarioFtp, string PasswordFtp)
        {
            bool existe = false;

            FtpWebRequest request;
            request = (FtpWebRequest)WebRequest.Create(Path.Combine(UrlServidorFtp + Directory));
            request.Credentials = new NetworkCredential(UsuarioFtp, PasswordFtp);

            try
            {
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                StreamReader streamReader = new StreamReader(response.GetResponseStream());
                List<string> directories = new List<string>();

                string line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    directories.Add(line);
                    line = streamReader.ReadLine();
                }
                streamReader.Close();
            }
            catch (Exception e)
            {
                try
                {
                    request = WebRequest.Create(UrlServidorFtp + Directory) as FtpWebRequest;
                    request.Credentials = new NetworkCredential(UsuarioFtp, PasswordFtp);
                    request.Method = WebRequestMethods.Ftp.MakeDirectory;
                    FtpWebResponse ftpResp = request.GetResponse() as FtpWebResponse;
                }
                catch(Exception ex) {
                    throw new Exception($"Error al crear directorio {Directory} " + ex);
                }
                
            }

            return existe;
        }

        public async Task<string> ExisteArchivoFtp(string UrlServidorFtp, string Directory, string UsuarioFtp, string PasswordFtp, string PathFile, string FileName)
        {
            bool existe = false;
            string pathFileServer = string.Empty;

            //var FileName = "/" + Path.GetFileName(PathFile);

            FtpWebRequest request;
            request = (FtpWebRequest)WebRequest.Create(Path.Combine(UrlServidorFtp + Directory + FileName));
            request.Credentials = new NetworkCredential(UsuarioFtp, PasswordFtp);

            try
            {
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                StreamReader streamReader = new StreamReader(response.GetResponseStream());
                List<string> directories = new List<string>();

                string line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    directories.Add(line);
                    line = streamReader.ReadLine();
                }
                streamReader.Close();

                if(directories.Count > 0)
                {
                    existe = true;
                    pathFileServer = Path.Combine(UrlServidorFtp + Directory + FileName);
                }
            }
            catch (Exception ex)
            {
                
            }

            return pathFileServer;
        }

        public void DownloadToPc()
        {
            #region DOWNLOAD TO PC
            ////TODO: ADD FILE EXISTS AND TRY CATCH
            //var provider = new FileExtensionContentTypeProvider();
            //if(!provider.TryGetContentType(localFile, out var contentType))
            //{
            //    contentType = "application/octet-stream";
            //}
            //var bytes = await System.IO.File.ReadAllBytesAsync(localFile);
            //return File(bytes, contentType, Path.GetFileName(localFile));
            #endregion
        }

        /*HOW TO USE:
         * 
            private readonly string UsuarioFtp, PasswordFtp, UrlServidorFtp;
         * 
            UsuarioFtp = IConfiguration.GetSection("UsuarioFtp").Value;
            PasswordFtp = IConfiguration.GetSection("PasswordFtp").Value;
            UrlServidorFtp = IConfiguration.GetSection("FtpUrl").Value;
         * 
            #region Variables
            var pathFile = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"wwwroot", @"images", @"user_default.png");
            var fileName = "/"+Path.GetFileName(pathFile);
            var directory = "/machuca/imagenes_perfil"; 
            #endregion

            var uploadSuccess = await IFtpService.UploadFile(pathFile, UrlServidorFtp, directory, UsuarioFtp, PasswordFtp);
        */
    }

}

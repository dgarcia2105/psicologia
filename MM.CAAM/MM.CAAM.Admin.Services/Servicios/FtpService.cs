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
        Task<bool> UploadFile(string PathFile, string UsuarioFtp, string PasswordFtp, string UrlServidorFtp, string Directory, int TimeOut = 60000);
        
    }

    public class FtpService : IFtpService
    { 
        public FtpService() 
        {
        }

        public async Task<bool> UploadFile(string PathFile, string UrlServidorFtp, string Directory, string UsuarioFtp, string PasswordFtp, int TimeOut = 60000)
        {
            var ruta_archivo_ftp = string.Empty;

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

            await Upload(UrlServidorFtp, Directory, UsuarioFtp, PasswordFtp, PathFile, TimeOut);

            return await ExisteArchivoFtp(UrlServidorFtp, directoryTmp, UsuarioFtp, PasswordFtp, PathFile);

        }

        public async Task Upload(string UrlServidorFtp, string Directory, string UsuarioFtp, string PasswordFtp, string PathFile, int TimeOut)
        {
            var FileName = "/" + Path.GetFileName(PathFile);

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

        public async Task<bool> ExisteArchivoFtp(string UrlServidorFtp, string Directory, string UsuarioFtp, string PasswordFtp, string PathFile)
        {
            bool existe = false;

            var FileName = "/" + Path.GetFileName(PathFile);

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
                }
            }
            catch (Exception ex)
            {
                
            }

            return existe;
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
    }

}

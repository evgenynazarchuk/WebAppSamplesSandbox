using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.Eventing.Reader;

namespace FileUploading.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Uploading : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationContext _db;

        public Uploading(IWebHostEnvironment env, ApplicationContext db)
        {
            _env = env;
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilesFromDisk()
        {
            return Ok(_db.FileModel.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> GetFilesFromDb()
        {
            return Ok(_db.DbFileModel.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddFileToDisk(IFormFile file)
        {
            if (file == null)
            {
                return BadRequest();
            }

            var path = "/files/" + file.FileName;
            Console.WriteLine(_env.WebRootPath + path);
            using var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create);
            await file.CopyToAsync(fileStream);
            fileStream.Close();

            _db.FileModel.Add(new FileModel { Name = file.FileName, Path = path, ContentType = file.ContentType });
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddFilesToDisk(IFormFileCollection files)
        {
            if (files == null)
            {
                return BadRequest();
            }

            foreach (var file in files)
            {
                var path = "/files/" + file.FileName;
                Console.WriteLine(_env.WebRootPath + path);
                using var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create);
                await file.CopyToAsync(fileStream);
                fileStream.Close();
                _db.FileModel.Add(new FileModel { Name = file.FileName, Path = path, ContentType = file.ContentType });
            }
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddFileToDb(IFormFile file)
        {
            if (file == null)
            {
                return BadRequest();
            }

            using var readStream = new BinaryReader(file.OpenReadStream());
            var data = readStream.ReadBytes((int)file.Length);
            var dbFile = new DbFileModel
            {
                Name = file.FileName,
                Data = data,
                ContentType = file.ContentType
            };
            await _db.DbFileModel.AddAsync(dbFile);
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DownloadById1(int id)
        {
            var file = _db.FileModel.SingleOrDefault(x => x.Id == id);

            if (file == null)
            {
                return BadRequest();
            }

            return PhysicalFile(_env.WebRootPath + file.Path, file.ContentType, file.Name);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DownloadById2(int id)
        {
            var file = _db.FileModel.SingleOrDefault(x => x.Id == id);

            if (file == null)
            {
                return BadRequest();
            }

            return File(_env.WebRootPath + file.Path, file.ContentType, file.Name);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DownloadById3(int id)
        {
            var file = _db.FileModel.SingleOrDefault(x => x.Id == id);

            if (file == null)
            {
                return BadRequest();
            }

            string path = _env.WebRootPath + file.Path;
            var fileStream = new FileStream(path, FileMode.Open);
            
            return File(fileStream, file.ContentType, file.Name);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DownloadById4(int id)
        {
            var file = _db.DbFileModel.SingleOrDefault(x => x.Id == id);

            if (file == null)
            {
                return BadRequest();
            }

            return File(file.Data, file.ContentType, file.Name);
        }
    }
}

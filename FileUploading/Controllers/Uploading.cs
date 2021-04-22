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
            return Ok(_db.DiskFileModel.ToList());
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
            
            using var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create);
            await file.CopyToAsync(fileStream);
            fileStream.Close();

            _db.DiskFileModel.Add(new DiskFileModel
            {
                Name = file.FileName,
                Path = path,
                ContentType = file.ContentType
            });

            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddFilesToDisk([FromForm] IFormFileCollection file)
        {
            if (file == null)
            {
                return BadRequest();
            }

            foreach (var f in file)
            {
                var path = "/files/" + f.FileName;
                
                using var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create);
                await f.CopyToAsync(fileStream);
                fileStream.Close();

                _db.DiskFileModel.Add(new DiskFileModel 
                { 
                    Name = f.FileName, 
                    Path = path, 
                    ContentType = f.ContentType 
                });

                await _db.SaveChangesAsync();
            }
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
        public async Task<IActionResult> DownloadFromDisk1(int id)
        {
            var file = _db.DiskFileModel.SingleOrDefault(x => x.Id == id);

            if (file == null)
            {
                return NotFound();
            }

            return PhysicalFile(_env.WebRootPath + file.Path, file.ContentType, file.Name);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DownloadFromDisk2(int id)
        {
            var file = _db.DiskFileModel.SingleOrDefault(x => x.Id == id);

            if (file == null)
            {
                return BadRequest();
            }

            var path = Path.Combine(_env.WebRootPath, file.Path);

            return File(path, file.ContentType, file.Name);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DownloadFromDisk3(int id)
        {
            var file = _db.DiskFileModel.SingleOrDefault(x => x.Id == id);

            if (file == null)
            {
                return BadRequest();
            }

            string path = _env.WebRootPath + file.Path;
            var fileStream = new FileStream(path, FileMode.Open);
            
            return File(fileStream, file.ContentType, file.Name);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DownloadFromDb1(int id)
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

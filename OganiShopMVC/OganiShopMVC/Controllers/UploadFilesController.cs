using Microsoft.AspNetCore.Mvc;

namespace OganiShopMVC.Controllers
{
    
    public class UploadFilesController : Controller
    {

        private IHttpContextAccessor _httpContextAccessor;
        private IWebHostEnvironment _webHostEnvironment;
        public UploadFilesController(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public IActionResult UploadSingleFile(IFormFile file)
        {
            var totalFile = Request.Form.Files.Count;
            if (totalFile > 0)
            {
                var filess = Request.Form.Files[0];
                var fileInfor = new FileInfo(filess.FileName);
                var fileName = fileInfor.Name;
                var fileExtension = fileInfor.Extension;
                var fileSize = filess.Length;
                var acceptExtensions = new List<string>() { ".jpg", ".png", ".jpeg", ".webp", ".svg", ".docx", ".doc", ".xls", ".xlsx", ".csv" };
                var acceptSize = 10 * 1024 * 1024;

                if (acceptExtensions.Contains(fileExtension))
                {
                    if (fileSize <= acceptSize)
                    {
                        var wwwrootFolder = _webHostEnvironment.WebRootPath;
                        var uploadFolder = Path.Combine(wwwrootFolder, "uploads");

                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }
                        var dateNowToString = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss");
                        var fileNameFull = dateNowToString + "_" + fileName;
                        var uploadDir = Path.Combine(uploadFolder, fileNameFull);
                        using (var stream = new FileStream(uploadDir, FileMode.Create))
                        {
                            filess.CopyTo(stream);
                        }
                        using (var stream = new FileStream(uploadDir, FileMode.Create))
                        {
                            filess.CopyTo(stream);
                        }
                        return Ok(fileNameFull);

                    }
                    else
                    {
                        return BadRequest("File size Too large. Please upload file small than 10MB");
                    }
                }
                else
                {
                    return BadRequest("File Ext not in acceped list!");
                }

            }
            return BadRequest("No file exits");
        }
    }
}

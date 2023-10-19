using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProjetoDeRestaurante.Models;

namespace ProjetoDeRestaurante.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagensController : Controller
    {
        private readonly ConfigurationImagens _myConfig;
        private readonly IWebHostEnvironment _hostingEnvironment;//Essa interface nos proporciona informações de ambiente

        public AdminImagensController(IOptions<ConfigurationImagens> myConfig, IWebHostEnvironment hostingEnvironment)
        {
            _myConfig = myConfig.Value;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
                return View(ViewData);
            }
            if (files.Count > 10)
            {
                ViewData["Erro"] = "Error: Quantidade de arquivos excedeu o limite";
                return View(ViewData);
            }

            long size = files.Sum(f => f.Length);

            var filePathsName = new List<string>();

            var filepath = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            foreach (var formfile in files)
            {
                if (formfile.FileName.Contains(".jpg") || formfile.FileName.Contains(".gif") || formfile.FileName.Contains(".png"))
                {
                    var fileNameWithPath = string.Concat(filepath, "\\", formfile.FileName);
                    filePathsName.Add(fileNameWithPath);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await formfile.CopyToAsync(stream);
                    }
                }
            }

            ViewData["Resultado"] = $"{files.Count} arquivos forams enviados ao servior," + $"com tamanho total de : {size} bytes";
            ViewBag.Arquivos = filePathsName;

            return View(ViewData);
        }

        public IActionResult getImagens()
        {
            FileManagerModel model = new FileManagerModel();

            var userImagesPath = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            DirectoryInfo dir = new DirectoryInfo(userImagesPath);

            FileInfo[] files = dir.GetFiles();

            model.PathImagesProduto = _myConfig.NomePastaImagensProdutos;

            if (files.Length == 0)
            {
                ViewData["Erro"] = $"Nenhum arquivo encontrado na pasta {userImagesPath}";

            }

            model.Files = files;

            return View(model);
        }

        public IActionResult DeleteFile(string fname)
        {
            string _imagemDeleta = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos + "\\", fname);

            if ((System.IO.File.Exists(_imagemDeleta)))
            {
                System.IO.File.Delete(_imagemDeleta);
                ViewData["Deletado"] = $"Arquivos(s) {_imagemDeleta} deletado com sucesso";
            }

            return View("Index");
        }
    }
}

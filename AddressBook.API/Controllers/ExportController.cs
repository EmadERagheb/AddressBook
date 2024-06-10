using AddressBook.Domain.Contracts;
using AddressBook.Domain.DTOs.Person;
using AddressBook.Domain.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AddressBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExportController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("ExportListToExcel")]
        public async Task< IActionResult> ExportListToExcel()
        {
            var dataList = await _unitOfWork.Repository<Person>().GetAllAsync<GetPersonDTO>();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");
                var currentRow = 1;

                // Add header
                var properties = typeof(GetPersonDTO).GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cell(currentRow, i + 1).Value = properties[i].Name;
                }

                // Add data
                foreach (var data in dataList)
                {
                    currentRow++;
                    for (int i = 0; i < properties.Length; i++)
                    {
                        worksheet.Cell(currentRow, i + 1).Value = properties[i].GetValue(data).ToString();
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DataExport.xlsx");
                }

            }

        }
    }
}

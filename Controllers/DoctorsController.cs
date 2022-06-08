#nullable disable
using Microsoft.AspNetCore.Mvc;
using ClinicalApp.Data;
using ClinicalApp.Models;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using Microsoft.AspNetCore.Authorization;
using ClinicalApp.Interface;

namespace ClinicalApp.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorRespository _doctor;
        private readonly IWebHostEnvironment _environment;
        private readonly DatabaseContext _context;

        public DoctorsController(IDoctorRespository doctor, IWebHostEnvironment environment, DatabaseContext context)
        {
            _doctor = doctor;
            _environment = environment;
            _context = context;

        }


        [Authorize(Roles = "Admin, Doctor")]
        // GET: Doctors
        public async Task<IActionResult> Index()
        {
            List<Doctor> doctor = _doctor.GetAll();
            ViewBag.Count = _context.Doctors.Count();
            return View(doctor);
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor doctor = _doctor.GetDoctor(id);

            return View(doctor);
        }
        // GET: Doctors/Create
        [Authorize(Roles = "Admin, Doctor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorId,DoctorFirstName,DoctorLastName,DoctorEmail,DoctorAddress,DoctorPhoneNumber,DoctorDepartmetment")] Doctor doctor)
        {
            string webRootPath = _environment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            string fileName = Guid.NewGuid().ToString();
            var upload = Path.Combine(webRootPath, @"Images\Doctors\");
            var extention = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extention), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            doctor.Image = @"\Images\Doctors\" + fileName + extention;



            _doctor.Create(doctor);
            TempData["success"] = "Doctor was created successfully";
            return RedirectToAction(nameof(Index));

            //return View(doctor);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor doctor = _doctor.GetDoctor(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }
        [Authorize(Roles = "Admin")]
        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorId,DoctorFirstName,DoctorLastName,DoctorEmail,DoctorAddress,DoctorPhoneNumber,DoctorDepartmetment, Image")] Doctor doctor)
        {
            if (id != doctor.DoctorId)
            {
                return NotFound();
            }
            doctor = _doctor.Edit(doctor);
            //TempData["success"] = "Doctor was updated successfully";
            return RedirectToAction(nameof(Index));

            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor doctor = _doctor.GetDoctor(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }
        [Authorize(Roles = "Admin")]
        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Doctor doctor)
        {
            doctor = _doctor.Delete(doctor);
            return RedirectToAction(nameof(Index));
        }

        //private bool DoctorExists(int id)
        //{
        //    return _context.Doctors.Any(e => e.DoctorId == id);
        //}

        [HttpPost]
        public IActionResult GeneratePDF(string submit)
        {
            PdfDocument pdfDocument = new PdfDocument();

            pdfDocument.DocumentInformation.Title = "Table";

            //Adds new page
            PdfPage pdfPage = pdfDocument.Pages.Add();


            PdfStructureElement element = new PdfStructureElement(PdfTagType.Table);


            PdfGrid pdfGrid = new PdfGrid();
            pdfGrid.DataSource = _context.Patient_File.ToList();
            pdfGrid.Draw(pdfPage, new PointF(5, 100));

            pdfGrid.PdfTag = element;


            pdfGrid.Columns.Add(8);


            pdfGrid.Headers.Add(1);

            PdfGridRow pdfGridHeader = pdfGrid.Headers[0];

            pdfGridHeader.Style.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);

            pdfGridHeader.Style.TextBrush = PdfBrushes.Brown;

            var docs = _context.Patient_File.ToList();

            pdfGridHeader.PdfTag = new PdfStructureElement(PdfTagType.TableRow);

            pdfGridHeader.Cells[0].Value = docs.Select(p => p.DoctorFirstName);

            pdfGridHeader.Cells[0].PdfTag = new PdfStructureElement(PdfTagType.TableHeader);

            pdfGridHeader.Cells[1].Value = "Doctor's Last Name";

            pdfGridHeader.Cells[1].PdfTag = new PdfStructureElement(PdfTagType.TableHeader);

            pdfGridHeader.Cells[2].Value = "Doctor's Email";

            pdfGridHeader.Cells[2].PdfTag = new PdfStructureElement(PdfTagType.TableHeader);

            pdfGridHeader.Cells[3].Value = "Doctor's Number";

            pdfGridHeader.Cells[3].PdfTag = new PdfStructureElement(PdfTagType.TableHeader);

            pdfGridHeader.Cells[4].Value = "Doctor's Speciality";

            pdfGridHeader.Cells[4].PdfTag = new PdfStructureElement(PdfTagType.TableHeader);


            PdfGridRow pdfGridRow = pdfGrid.Rows.Add();

            //var doctors = _context.DoctorPrescription.ToList();

            pdfGridRow.Cells[0].Value = docs.Select(p => p.DoctorFirstName);

            pdfGridRow.Cells[1].Value = docs.Select(p => p.DoctorLastName);

            pdfGridRow.Cells[2].Value = docs.Select(p => p.DoctorEmail);

            pdfGridRow.Cells[3].Value = docs.Select(p => p.DoctorPhoneNumber);

            pdfGridRow.Cells[4].Value = docs.Select(p => p.DoctorDepartmetment);

            pdfGridRow.Cells[5].Value = docs.Select(p => p.PatientFirstName);

            pdfGridRow.Cells[6].Value = docs.Select(p => p.PatientLastName);

            pdfGridRow.Cells[8].Value = docs.Select(p => p.Address);



            pdfGridRow.Cells[0].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);

            pdfGridRow.Cells[1].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);

            pdfGridRow.Cells[2].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);

            pdfGridRow.Cells[3].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);

            pdfGridRow.Cells[4].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);

            pdfGridRow.Cells[5].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);

            pdfGridRow.Cells[6].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);

            pdfGridRow.Cells[7].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);


            //pdfGrid.Draw(pdfPage, PointF.Empty);


            MemoryStream stream = new MemoryStream();

            pdfDocument.Save(stream);

            stream.Position = 0;



            pdfDocument.Close(true);

            string contentType = "application/pdf";

            string fileName = "Output.pdf";

            //MemoryStream ms = new MemoryStream();
            //document.Save(ms);
            //document.Close(true);

            //ms.Position = 0;

            //FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
            //fileStreamResult.FileDownloadName = "Doctor's_prescription.pdf";

            return File(stream, contentType, fileName);
        }
    }
}

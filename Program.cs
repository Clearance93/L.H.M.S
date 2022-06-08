using ClinicalApp;
using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using ClinicalApp.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using EmailSender = ClinicalApp.Utility.EmailSender;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("DatabaseContextConnection");


builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
   // builder.Services.AddDbContext<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DatabaseContext>()
        .AddDefaultTokenProviders()
        .AddDefaultUI();


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;

    options.SignIn.RequireConfirmedEmail = true;
    options.SignIn.RequireConfirmedAccount = true;
});

//builder.Services.AddDefaultIdentity<ApplicationUser>();


builder.Services.AddSingleton<IEmailSender, EmailSender>();
builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = "/Identity/Account/Login";
    option.LogoutPath = "/Identity/Account/Logout";
    option.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddControllers();
builder.Services.AddScoped<IDoctorRespository, DoctorRepository>();
builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<ICleanerRepository, CleanerRepository>();
builder.Services.AddScoped<IFinanceRepository, FinanceRepository>();
builder.Services.AddScoped<IHRRepository, HRRepository>();
builder.Services.AddScoped<IITRepository, ITRepository>();
builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
builder.Services.AddScoped<INurseRepository, NurseRepository>();
builder.Services.AddScoped<IParamedicRepository, ParamedicRepository>();
builder.Services.AddScoped<IPorterRepository, PorterRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRolesRepository>();
builder.Services.AddScoped<IWorkInformationRepository, WorkInformationRepository>();
builder.Services.AddScoped<IFinancialInformationRepository, FinanctialInformationRepository>();
builder.Services.AddScoped<IHabitRepository, HabitRepository>();
builder.Services.AddScoped<ITreatmentsRepository, TreatmentRepository>(); 
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IMedicalRecordsRepository, MedicalRecordsRepository>();
builder.Services.AddScoped<IMedicationRepository, MedicationRepository>();
builder.Services.AddScoped<IPatient_FileRepository, Patient_FileRepository>();
builder.Services.AddScoped<IChronic_DeseaseRepository, Chronic_DiseaseRepository>();
builder.Services.AddScoped<IPatient_of_HospitalRepository, Patient_Of_HospitalRepository>();
builder.Services.AddScoped<IPuckUpMedicationRepository, PickUpMMedicationRepository>();
builder.Services.AddScoped<IInComplteRepository, InCompleteRepository>();
builder.Services.AddScoped<IMaleWardRepository, MaleWardRepository>();
builder.Services.AddScoped<IFemaleWardRepository, FemaleWardRepository>();
builder.Services.AddScoped<IMetinityWardRepository, MetinityRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();



builder.Services.AddSignalR();

//builder.Services.AddTransient<IEmailSender, ClinicalApp.EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication().AddFacebook(option =>
{
    option.AppId = "VNA73p53HF1CoI3TZi6jFsmkW";
    option.AppSecret = "62504e2ec1fcf208436172f788e87fa0";
});
//.AddTwitter(option =>
//{
//    option.ConsumerKey = "779067119742640";
//    option.ConsumerSecret = "r9EyFk6eBq1SvoDRyr8Pk2Q8leNDOtMHhitTG5y41vfidgUCz2";
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();
app.MapHub<ChatHub>("/chatHub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

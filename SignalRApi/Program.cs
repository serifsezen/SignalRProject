using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IAboutService,AboutManager>();
builder.Services.AddScoped<IAboutDal,EfAboutDal>();

builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();

builder.Services.AddScoped<IDiscountService, DiscountManager>();
builder.Services.AddScoped<IDiscountDal, EfDiscountDal>();

builder.Services.AddScoped<IFeatureService, FeatureManager>();
builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();

builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

builder.Services.AddScoped<ITestoimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

//builder.Services.AddScoped<IOrderService, OrderManager>();
//builder.Services.AddScoped<IOrderDal, EfOrderDal>();

//builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();
//builder.Services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();

//builder.Services.AddScoped<IMoneyCaseService, MoneyCaseManager>();
//builder.Services.AddScoped<IMoneyCaseDal, EfMoneyCaseDal>();

//builder.Services.AddScoped<IMenuTableService, MenuTableManager>();
//builder.Services.AddScoped<IMenuTableDal, EfMenuTableDal>();

//builder.Services.AddScoped<ISliderService, SliderManager>();
//builder.Services.AddScoped<ISliderDal, EfSliderDal>();

//builder.Services.AddScoped<IBasketService, BasketManager>();
//builder.Services.AddScoped<IBasketDal, EfBasketDal>();

//builder.Services.AddScoped<INotificationService, NotificationManager>();
//builder.Services.AddScoped<INotificationDal, EfNotificationDal>();

//builder.Services.AddScoped<IMessageService, MessageManager>();
//builder.Services.AddScoped<IMessageDal, EfMessageDal>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
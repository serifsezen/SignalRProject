using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestoimonialService _testoimonialService;
        private readonly IMapper _mapper;
        public TestimonialController(ITestoimonialService testoimonialService, IMapper mapper)
        {
            _testoimonialService = testoimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testoimonialService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testoimonialService.TAdd(new Testimonial()
            {
                //Comment = createTestimonialDto.Comment,
                TestimonilImageUrl = createTestimonialDto.ImageUrl,
                TestimonialName = createTestimonialDto.Name,
                TestimonialStatus = createTestimonialDto.Status,
                TestimonialTitle = createTestimonialDto.Title
            });
            return Ok("Müşteri Yorum Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testoimonialService.TGetByID(id);
            _testoimonialService.TDelete(value);
            return Ok("Müşteri Yorum Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testoimonialService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testoimonialService.TUpdate(new Testimonial()
            {
                //Comment = updateTestimonialDto.Comment,
                TestimonilImageUrl = updateTestimonialDto.ImageUrl,
                TestimonialName = updateTestimonialDto.Name,
                TestimonialStatus = updateTestimonialDto.Status,
                TestimonialTitle = updateTestimonialDto.Title,
                TestimonialID = updateTestimonialDto.TestimonialID
            });
            return Ok("Müşteri Yorum Bilgisi Güncellendi");
        }
    }
}

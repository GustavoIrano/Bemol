using AutoMapper;
using bemol.App.Models;
using bemol.Business.Interfaces;
using bemol.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bemol.App.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IViaCepService _viaCepService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService,
                                  IViaCepService viaCepService,
                                  IMapper mapper,
                                  INotificator notificator) : base(notificator)
        {
            _customerService = customerService;
            _viaCepService = viaCepService;
            _mapper = mapper;
        }

        public IActionResult Index(bool success = false)
        {
            ViewBag.Success = success;

            return View();
        }

        [Route("Salvar")]
        [HttpPost]
        public async Task<IActionResult> Salvar(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return View(customerViewModel);

            var customer = _mapper.Map<Customer>(customerViewModel);

            await _customerService.Add(customer);

            if (!OperacaoValida()) return View(customerViewModel);

            return RedirectToAction("Index", new { success = true });
        }
        
        [HttpGet]
        public async Task<CepViewModel> BuscaCep(string cep)
        {
            return _mapper.Map<CepViewModel>(await _viaCepService.GetDadosCep(cep));
        }
    }
}

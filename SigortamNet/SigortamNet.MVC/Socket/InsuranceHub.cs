using AutoMapper;
using FormHelper;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using SigortamNet.Application.Contracts.Operations.Bid;
using SigortamNet.Application.Contracts.Operations.Partner;
using SigortamNet.Application.Contracts.Operations.Visitor;
using SigortamNet.Contracts.Enums;
using SigortamNet.Contracts.Results;
using SigortamNet.MVC.ViewModels;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SigortamNet.Integration.Socket
{
    public class InsuranceHub : Hub
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IPartnerService _partnerService;
        private readonly IBidService _bidService;
        private readonly IVisitorService _visitorService;
        private readonly IMapper _mapper;

        public InsuranceHub(IHttpClientFactory clientFactory, IPartnerService partnerService, IVisitorService visitorService, IBidService bidService, IMapper mapper)
        {
            _partnerService = partnerService;
            _clientFactory = clientFactory;
            _visitorService = visitorService;
            _bidService = bidService;
            _mapper = mapper;
        }

        [FormValidator]
        public async Task SendAsync(VisitorViewModel viewModel)
        {
            var input = _mapper.Map<VisitorInput>(viewModel);
            var resultVisitor = await _visitorService.CheckGetAndInsertAsync(input);

            if (!resultVisitor.IsSucceed)
            {
                await Clients.Caller.SendAsync("ReceiveMessage", resultVisitor);
                return;
            }

            var resultPartner = await _partnerService.GetListAsync();

            if (!resultPartner.IsSucceed)
            {
                await Clients.Caller.SendAsync("ReceiveMessage", resultPartner);
                return;
            }

            foreach (var item in resultPartner.Object)
            {
                var apiResult = await ApiRequest(input, item.ApiUrl, item.InsuranceType);
                if (apiResult.IsSucceed)
                {
                    var bidInput = _mapper.Map<BidInput>(apiResult.Object);
                    bidInput.VisitorId = resultVisitor.Object.Id;

                    var bidResult = await _bidService.AddAsync(bidInput);
                    if (bidResult.IsSucceed)
                    {
                        await Clients.Caller.SendAsync("ReceiveMessage", apiResult);
                    }
                }
            }
        }

        //Soap servisler içinde araya bir web api yazar onun içerisinde soap entegresyonu tamalanıp dönüşüm tamamlanabilir
        private async Task<ServiceResult<BidOutput>> ApiRequest(VisitorInput input, string apiUrl, InsuranceType insuranceType)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
            request.Content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var output = new BidOutput();

                //Farklı apilerin farklı dönüş tiplerine göre farklı mappingler oluşturulabilir.
                switch (insuranceType)
                {
                    case InsuranceType.AInsurance:
                        output = JsonConvert.DeserializeObject<BidOutput>(responseString);
                        break;
                    case InsuranceType.BInsurance:
                        output = JsonConvert.DeserializeObject<BidOutput>(responseString);
                        break;
                    case InsuranceType.CInsurance:
                        output = JsonConvert.DeserializeObject<BidOutput>(responseString);
                        break;
                    default:
                        break;
                }

                return new ServiceResult<BidOutput>(Status.Success)
                {
                    Object = output
                };
            }

            return new ServiceResult<BidOutput>(Status.Error)
            {
                Message = "Teklif getirilirken bir hata oluştu"
            };
        }
    }
}

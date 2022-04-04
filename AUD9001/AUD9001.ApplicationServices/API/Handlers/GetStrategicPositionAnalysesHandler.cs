using AUD9001.ApplicationServices.API.Domain;
using AUD9001.DataAccess;
using AUD9001.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Handlers
{
    public class GetStrategicPositionAnalysesHandler : IRequestHandler<GetStrategicPositionAnalysesRequest, GetStrategicPositionAnalysesResponse>
    {
        private readonly IRepository<StrategicPositionAnalysis> strategicPositionAnalysisRepository;
        public GetStrategicPositionAnalysesHandler(IRepository<DataAccess.Entities.StrategicPositionAnalysis> strategicPositionAnalysisRepository)
        {
            this.strategicPositionAnalysisRepository = strategicPositionAnalysisRepository;
        }

        public async Task<GetStrategicPositionAnalysesResponse> Handle(GetStrategicPositionAnalysesRequest request, CancellationToken cancellationToken)
        {
            var strategicPositionAnalyses = await this.strategicPositionAnalysisRepository.GetAll();

            var domainStrategicPositionAnalyses = strategicPositionAnalyses.Select(x => new Domain.Models.StrategicPositionAnalysis()
            {
                CreationDate = x.CreationDate,
                RecordNumber = x.RecordNumber,
                SummaryS = x.SummaryS,
                SummaryW = x.SummaryW,
                SummaryO = x.SummaryO,
                SummaryT = x.SummaryT,
                AR = x.AR,
                PR = x.PR
            });

            var response = new GetStrategicPositionAnalysesResponse()
            {
                Data = domainStrategicPositionAnalyses.ToList()
            };

            return response;
        }
    }
}
